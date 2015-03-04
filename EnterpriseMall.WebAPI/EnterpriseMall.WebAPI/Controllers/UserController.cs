using EnterpriseMall.Models;
using EnterpriseMall.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Uni2uni.Framework.Net;
using Uni2uni.Framework.Logging;
using EnterpriseMall.Models.InputParame;

namespace EnterpriseMall.WebAPI.Controllers
{
    public class UserController : ApiBaseController
    {
        UsersService userBll = new UsersService();

        [AllowAnonymous]
        [HttpPost]
        public Result<User> Login(UserParame user)
        {
            return userBll.Login(user.Name, user.Pwd);    
        }

        [AllowAnonymous]
        [HttpPost]
        public Result<User> LoginDemo(Models.User user)
        {
            return userBll.Login(user.Name, user.Pwd);    
        }

    }
}
