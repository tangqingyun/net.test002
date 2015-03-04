using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace EnterpriseMall.WebAPI.Filter
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext context)
        {
            var message = context.Exception.Message;
            if (context.Exception.InnerException != null)
                message = context.Exception.InnerException.Message;

            EnterpriseMall.Models.ResultBase<object> result = new EnterpriseMall.Models.ResultBase<object>
            {
                data = null,
                state = "-1",
                errmsg = message
            };
            context.Response = new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(result)), StatusCode = System.Net.HttpStatusCode.OK };
            base.OnException(context);
        }
    }

}