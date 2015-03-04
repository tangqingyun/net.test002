using Basement.Framework.Data;
using Com.WebSite.Models;
using Com.WebSite.Models.Entity;
using Com.WebSite.Models.ParamterEntity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Com.WebSite.DataAccess
{
    public class AdminDataProvider
    {
        IDatabase database = Database.DbConnection;
        public AdminDataProvider()
        {

        }

        public bool AddAdmin(Entity_Admin entity)
        {
            int n = database.Insert<Entity_Admin>(entity);
            return n > 0 ? true : false;
        }

        public bool AddAdminType(Entity_AdminType entity)
        {
            int n = database.Insert<Entity_AdminType>(entity);
            return n > 0 ? true : false;
        }

        public bool UpdateAdminByID(Entity_Admin entity)
        {
            string script = "UPDATE YN_Admin SET TypeID=@TypeID, Name=@Name, Pwd=@Pwd, Email=@Email WHERE ID=@ID";
            IList<DbParameter> paramsList = new List<DbParameter>(){
              new SqlParameter("TypeID",entity.TypeID),
              new SqlParameter("Name",entity.Name),
              new SqlParameter("Pwd",entity.Pwd),
              new SqlParameter("Email",entity.Email),
              new SqlParameter("ID",entity.ID)
            };
            return database.ExecuteNoQuery(script, paramsList);
        }

        public bool UpdateAdminTypeByID(Entity_AdminType entity)
        {
            string script = "UPDATE YN_AdminType SET Rank=@Rank, TypeName=@TypeName    WHERE ID=@ID";
            IList<DbParameter> paramsList = new List<DbParameter>(){
              new SqlParameter("Rank",entity.Rank),
              new SqlParameter("TypeName",entity.TypeName),
              new SqlParameter("ID",entity.ID)
            };
            return database.ExecuteNoQuery(script, paramsList);
        }

        public bool DeleteAdmin(Guid id)
        {
            string script = "DELETE FROM YN_Admin WHERE ID=@ID";
            IList<DbParameter> paramsList = new List<DbParameter>(){
              new SqlParameter("ID",id),
            };
            return database.ExecuteNoQuery(script, paramsList);
        }

        public Entity_Admin GetAdminByID(Guid id)
        {
            string sql = "SELECT * FROM YN_Admin  WHERE ID=@ID";
            IList<DbParameter> paramsList = new List<DbParameter>(){
              new SqlParameter("ID",id)
            };
            return database.SingleAsModel<Entity_Admin>(sql, paramsList);
        }

        public IEnumerable<Entity_AdminExt> GetAdminPager(AdminQueryParam query, int index, int size, out int total)
        {
            string script = @"SELECT  AD.*,AT.TypeName FROM YN_Admin AD WITH(NOLOCK)
INNER JOIN dbo.YN_AdminType AT WITH(NOLOCK) ON AD.TypeID=AT.ID";
            total = 0;
            return database.GetPageList<Entity_AdminExt>(script, "", "CreateTime", index, size);
        }

        public IEnumerable<Entity_Role> GetAdminTypeList()
        {
            string script = @"SELECT  AT.*,AD.Name FROM YN_AdminType AT WITH(NOLOCK)
INNER JOIN dbo.YN_Admin AD WITH(NOLOCK) ON AT.CreateBy=AD.ID";
            return database.ExecuteList<Entity_Role>(script);
        }

        public Entity_Admin GetAdminByNameAndPwd(string name, string pwd)
        {
            string script = "SELECT * FROM YN_Admin WHERE Name=@Name AND Pwd=@Pwd";
            IList<DbParameter> paramsList = new List<DbParameter>(){
              new SqlParameter("Name",name),
              new SqlParameter("Pwd",pwd),
            };
            return database.SingleAsModel<Entity_Admin>(script, paramsList);
        }

    }
}
