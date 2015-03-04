using EnterpriseMall.DataAccess;
using EnterpriseMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMall.Services
{

    public class UsersService
    {
        UsersDataProvider userDao;
        public UsersService()
        {
            userDao = new UsersDataProvider();
        }

        public Result<User> Login(string name, string pwd)
        {
            ResultBase<User> resultBase = new ResultBase<User>();
            User userModel = userDao.GetUserByNameAndPwd(name, pwd);
            resultBase.data = userModel;
            if (userModel == null)
                resultBase.state = "1";
            return new Result<User>() { response = resultBase };
        }

    }
}
