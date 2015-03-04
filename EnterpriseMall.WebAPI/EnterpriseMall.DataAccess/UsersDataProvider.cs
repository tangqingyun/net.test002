using EnterpriseMall.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni2uni.Framework.Data;


namespace EnterpriseMall.DataAccess
{

    public class UsersDataProvider
    {
        IDatabase database;
        public UsersDataProvider()
        {
            database = Database.User;
        }

        public int InsertUser(User model)
        {
            return database.Insert<User>(model);
        }

        public User GetUserByNameAndPwd(string name,string pwd)
        { 
            User user=null;
            database.Execute(() =>
            {
                user = database.Single<User>(m => m.Name == name && m.Pwd == pwd);
            });
            return user;
        }
    }
}
