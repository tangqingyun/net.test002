using MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TestGoodsWin
{
    /// <summary>
    /// 商品SQL脚本生成
    /// </summary>
    public class GoodsScriptBuilder
    {
        private const string connectionStringTest = "Uni2uni_GoodsInfoTest";
        static MSSQL.DatabaseHelper db;
        StringBuilder sb = new StringBuilder();
        string opreatorId = "D8235F2B-1B55-47C6-AB5D-41908E52CE84";
        public GoodsScriptBuilder()
        {
            db = new DatabaseHelper(connectionStringTest);
        }

        public string BuilderSQLScript(string productCategoryID)
        {
            
            BuilderProductCategorySQL(productCategoryID);

            return sb.ToString();
        }

        public void BuilderProductCategorySQL(string productCategoryID)
        {
            string sqlCategory = "SELECT * FROM dbo.GM_ProductCategory WHERE ProductCategoryID='" + productCategoryID + "'";
            DataTable dt = db.GetDataTable(sqlCategory, CommandType.Text, null);
            DataRow dr = dt.Rows[0];
            sb.AppendFormat(@"INSERT INTO uni2uni_Goodsinfo.dbo.GM_ProductCategory (ProductCategoryID , CategoryCode ,CategoryName ,CategoryURL ,CategoryPinyin ,CategoryType,CategorySort ,CategoryParenID ,CategorySaleService , BankDiscountType ,CreateBy ,CreateTime ,UpdateBy ,UpdateTime ,isValid ) VALUES ('{0}' , {1} ,'{2}' ,'{3}' ,'{4}' ,{5},{6} ,'{7}' ,'{8}' , {9} ,'{10}' ,'{11}' ,'{12}' ,'{13}' ,{14})

",
                Guid.Parse(dr["ProductCategoryID"].ToString()),
                Convert.ToInt64(dr["CategoryCode"]),
                dr["CategoryName"],
                dr["CategoryURL"],
                dr["CategoryPinyin"],
                Convert.ToInt32(dr["CategoryType"]),
                Convert.ToInt32(dr["CategorySort"]),
                Guid.Parse(dr["CategoryParenID"].ToString()),
                dr["CategorySaleService"],
                Convert.ToInt32(dr["BankDiscountType"]),
                opreatorId,
                dr["CreateTime"],
                opreatorId,
                dr["UpdateTime"],
                Convert.ToInt32(dr["isValid"]));

            BuilderProductCategoryRelPropertySQL(dr["ProductCategoryID"].ToString());
        }

        private void BuilderProductCategoryRelPropertySQL(string ProductCategoryID)
        {
            string sql = "SELECT * FROM uni2uni_Goodsinfo.dbo.GM_ProductCategoryRelProperty WHERE ProductCategoryID='" + ProductCategoryID + "'";
            DataTable dt = db.GetDataTable(sql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendFormat(@" INSERT INTO uni2uni_Goodsinfo.dbo.GM_ProductCategoryRelProperty( ProductCategoryRelPropertyID , ProductCategoryID ,ProductPropertysID,PropertySort ,PropertyType ,PropertyUnit ,PropertyValueType ,SystemKeyWork ,IsSearch)
 VALUES('{0}' , '{1}' , '{2}' , {3} ,{4} ,'{5}' ,{6} ,'{7}' ,{8})

",
                                        Guid.Parse(dr["ProductCategoryRelPropertyID"].ToString()),
                                        Guid.Parse(dr["ProductCategoryID"].ToString()),
                                        Guid.Parse(dr["ProductPropertysID"].ToString()),
                                        Convert.ToInt32(dr["PropertySort"]),
                                        Convert.ToInt32(dr["PropertyType"]),
                                        dr["PropertyUnit"],
                                        Convert.ToInt32(dr["PropertyValueType"]),
                                        dr["SystemKeyWork"],
                                        Convert.ToInt32(dr["IsSearch"]));
                BuilderProductPropertyKeyworkSQL(dr["ProductCategoryRelPropertyID"].ToString());
            }

        }

        private void BuilderProductPropertyKeyworkSQL(string ProductCategoryRelPropertyID)
        {
            string sql = "SELECT * FROM uni2uni_Goodsinfo.dbo.GM_ProductPropertyKeywork WHERE ProductCategoryRelPropertyID='" + ProductCategoryRelPropertyID + "'";
            DataTable dt = db.GetDataTable(sql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendFormat(@"INSERT INTO uni2uni_Goodsinfo.dbo.GM_ProductPropertyKeywork(ProductPropertyKeyworkID ,ProductCategoryRelPropertyID ,ProValue ,ProValueLevel ,ProValueDescribe , CreateBy ,CreateTime ,UpdateBy ,UpdateTime ,isValid)
VALUES  (ProductPropertyKeyworkID ,ProductCategoryRelPropertyID ,ProValue ,ProValueLevel ,ProValueDescribe , CreateBy ,CreateTime ,UpdateBy ,UpdateTime ,isValid) ",
                Guid.Parse(dr["ProductPropertyKeyworkID"].ToString()),
                Guid.Parse(dr["ProductCategoryRelPropertyID"].ToString()),
                dr["ProValue"],
                Convert.ToInt32(dr["ProValueLevel"]),
                dr["ProValueDescribe"],
                opreatorId,
                dr["CreateTime"],
                opreatorId,
                dr["UpdateTime"],
                Convert.ToInt32(dr["isValid"]));
            }
        }

    }
}
