using Com.WebSite.DataAccess;
using Com.WebSite.Models.Entity;
using Com.WebSite.Models.ParamterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.WebSite.Services
{
    public class AdminService
    {
        private readonly AdminDataProvider dbProvider = new AdminDataProvider();
        public AdminService() { 
        
        }

        public bool AddAdmin(Entity_Admin entity)
        {
            return dbProvider.AddAdmin(entity);
        }

        public bool AddAdminType(Entity_AdminType entity)
        {
            return dbProvider.AddAdminType(entity);
        }

        public bool UpdateAdminByID(Entity_Admin entity)
        {
            return dbProvider.UpdateAdminByID(entity);
        }

        public bool UpdateAdminTypeByID(Entity_AdminType entity)
        {
            return dbProvider.AddAdminType(entity);
        }

        public bool DeleteAdmin(Guid id)
        {
            return dbProvider.DeleteAdmin(id);
        }

        public Entity_Admin GetAdminByID(Guid id)
        {
            return dbProvider.GetAdminByID(id);
        }
        public IEnumerable<Entity_AdminExt> GetAdminPager(AdminQueryParam query, int index, int size, out int total)
        {
            return dbProvider.GetAdminPager( query,  index,  size, out  total);
        }

        public IEnumerable<Entity_Role> GetAdminTypeList()
        {
            return dbProvider.GetAdminTypeList();
        }

        public Entity_Admin AdminLogin(string name,string pwd) {
            return dbProvider.GetAdminByNameAndPwd(name,pwd);
        }

    }
}
