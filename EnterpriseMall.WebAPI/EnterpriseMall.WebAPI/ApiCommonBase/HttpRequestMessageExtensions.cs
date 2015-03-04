using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace EnterpriseMall.WebAPI.ApiCommonBase
{
    /// <summary>
    /// 请求消息-封装
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        private static MethodInfo _createResponse = InitCreateResponse();

        private static MethodInfo InitCreateResponse()
        {
            Expression<Func<HttpRequestMessage, HttpResponseMessage>> expr =
                (request) => request.CreateResponse<object>(HttpStatusCode.OK, default(object));
            return (expr.Body as MethodCallExpression).Method.GetGenericMethodDefinition();
        }

        public static HttpResponseMessage CreateResponse(this HttpRequestMessage request, HttpStatusCode status, Type type, object value)
        {
            return _createResponse.MakeGenericMethod(type).Invoke(null, new[] { request, status, value }) as HttpResponseMessage;
        }
    }
}
