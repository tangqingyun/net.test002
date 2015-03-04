﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EnterpriseMall.WebAPI.Filter
{
    public class CorsMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            //得到描述目标Action的HttpActionDescriptor
            HttpMethod originalMethod = request.Method;
            bool isPreflightRequest = request.IsPreflightRequest();
            if (isPreflightRequest)
            {
                string method = request.Headers.GetValues("Access-Control-Request-Method").First();
                request.Method = new HttpMethod(method);
            }
            HttpConfiguration configuration = request.GetConfiguration();
            HttpControllerDescriptor controllerDescriptor = configuration.Services.GetHttpControllerSelector().SelectController(request);
            HttpControllerContext controllerContext = new HttpControllerContext(request.GetConfiguration(), request.GetRouteData(), request)
            {
                ControllerDescriptor = controllerDescriptor
            };
            HttpActionDescriptor actionDescriptor = configuration.Services.GetActionSelector().SelectAction(controllerContext);

            //根据HttpActionDescriptor得到应用的CorsAttribute特性
            CorsAttribute corsAttribute = actionDescriptor.GetCustomAttributes<CorsAttribute>().FirstOrDefault() ??
                controllerDescriptor.GetCustomAttributes<CorsAttribute>().FirstOrDefault();
            if (null == corsAttribute)
            {
                return base.SendAsync(request, cancellationToken);
            }

            //利用CorsAttribute实施授权并生成响应报头
            IDictionary<string, string> headers;
            request.Method = originalMethod;
            bool authorized = corsAttribute.TryEvaluate(request, out headers);
            HttpResponseMessage response;
            if (isPreflightRequest)
            {
                if (authorized)
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, corsAttribute.ErrorMessage);
                }
            }
            else
            {
                response = base.SendAsync(request, cancellationToken).Result;
            }

            //添加响应报头
            foreach (var item in headers)
            {
                response.Headers.Add(item.Key, item.Value);
            }
            //-----------.net 4.5----------------
            //return Task.FromResult<HttpResponseMessage>(response); 

            //-----------.net 4.0----------------
            var taskSource = new TaskCompletionSource<HttpResponseMessage>();
            taskSource.SetResult(message);
            return taskSource.Task;

        }
    }

}