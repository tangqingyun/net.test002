using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSSQL;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace TestGoodsWin
{
    class Program
    {
        private const string connectionZS= "Uni2uni_GoodsInfoZS";
        private const string connectionCS = "Uni2uni_GoodsInfoCS";
        static MSSQL.DatabaseHelper dbZS = new DatabaseHelper(connectionZS);
        static MSSQL.DatabaseHelper dbCS = new DatabaseHelper(connectionCS);

        static void Main(string[] args)
        {
            string script = @"SELECT ROW_NUMBER() OVER(ORDER BY InfoCode) AS number,MarketPrice,SalePrice,PurchasePrice,InfoCode,InfoTitle FROM uni2uni_Goodsinfo.dbo.CollectionInfo WHERE MarketPrice=9999.00 AND SalePrice=6000.00 AND InfoTitle NOT LIKE '联嘉云车友会%' AND InfoTitle NOT LIKE '联嘉云生活会%'";

            DataTable dtable = dbCS.GetDataTable(script, CommandType.Text, null);
            Console.WriteLine("总条数：" + dtable.Rows.Count + "\r\n");
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                string selectSql = "SELECT MarketPrice,SalePrice,PurchasePrice,Discount,[Description],SmallImg,BigImg,IndexImg,Summary,Number,isnull(IsPrepareSale,'') as IsPrepareSale,isnull(IsCodePay,'') as IsCodePay,isnull(CodeValue,'') as CodeValue,InfoCode FROM uni2uni_Goodsinfo.dbo.CollectionInfo WHERE infocode=" + dtable.Rows[i]["infocode"];
                DataTable dt = dbZS.GetDataTable(selectSql, CommandType.Text, null);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string scriptupdate = @" update uni2uni_Goodsinfo.dbo.CollectionInfo set 
                        MarketPrice=" + dt.Rows[0]["MarketPrice"] + 
                                      ",SalePrice=" + dt.Rows[0]["SalePrice"] + 
                                      ",PurchasePrice=" + dt.Rows[0]["PurchasePrice"] + 
                                      ",Discount=" + dt.Rows[0]["Discount"] + 
                                      ", Description='" + dt.Rows[0]["Description"].ToString().Replace("'","") + 
                                      "',SmallImg='" + dt.Rows[0]["SmallImg"] + 
                                      "',BigImg='" + dt.Rows[0]["BigImg"] + 
                                      "',IndexImg='" + dt.Rows[0]["IndexImg"] + 
                                      "',Summary='" + dt.Rows[0]["Summary"].ToString().Replace("'","") + 
                                      "',Number=" + dt.Rows[0]["Number"] + 
                                      ",IsPrepareSale=0" + 
                                      ",IsCodePay=0" + 
                                      ",CodeValue=0"+ 
                                      " where infocode=" + dt.Rows[0]["infocode"];
                    try
                    {
                        int bol = dbCS.ExecuteNonQuery(scriptupdate, CommandType.Text, null);
                        if (bol > 0)
                        {
                            Console.WriteLine(i + ":" + dt.Rows[0]["infocode"] + "成功\r\n");
                        }
                        else
                        {
                            Console.WriteLine(i + ":" + dt.Rows[0]["infocode"] + "失败\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(i + ":" + dt.Rows[0]["infocode"] + "失败\r\n" + ex.Message);
                        continue;
                    }
                   

                }
                
            }


            //GetProductCategory();

            //bool bol = InsertProductPropertys();
            //if (bol)
            //{
            //    Console.WriteLine("导入优惠套餐属性 成功！");
            //}

            //bool bol1=InsertProductCategoryRelProperty();
            //if (bol1)
            //{
            //    Console.WriteLine("导入影友会新添加的属性关系 成功！");
            //}

            //bool bol2 = InsertProductPropertyKeywork();
            //if (bol2)
            //{
            //    Console.WriteLine("导入优惠套餐属性值 成功！");
            //}

            //bool bol3 = InsertGoodsData();
            //if (bol3)
            //{
            //    Console.WriteLine("导入影友会商品数据 成功！");
            //}


            //bool bol4 = InsetMemberProduct();
            //if (bol4)
            //{
            //    Console.WriteLine("导入影友会MemberProduct表关系数据 成功！");
            //}
            //Console.ReadKey();

            //bool bol5 = InsertLifeClubProductRule();
            //if (bol5)
            //{
            //    Console.WriteLine("导入影友会LifeClubProductRule表关系数据 成功！");
            //}

            //InsertCollectionInfo("");

            //string sqlstr=GetGoods();

          //  GoodsScriptBuilder script = new GoodsScriptBuilder();

           // string sql = script.BuilderSQLScript("A75B3CA6-FE8B-4B30-A75B-A29D00B92A69");

          //  Console.ReadKey();
            
        }

        public static void GetProductCategory()
        {
            string sqlCategory = "SELECT * FROM dbo.GM_ProductCategory  where ProductCategoryID='DC0F1CDE-82E7-427D-847E-A277009D440C'";
            DataTable dt = dbZS.GetDataTable(sqlCategory, CommandType.Text, null);
            Guid ProductCategoryID = Guid.Parse(dt.Rows[0]["ProductCategoryID"].ToString());
            Console.WriteLine(ProductCategoryID);
            Console.ReadKey();
        }

        //导入优惠套餐属性
        public static bool InsertProductPropertys()
        {
            string sql = @"INSERT INTO dbo.GM_ProductPropertys
                    ( ProductPropertysID ,
                      PropertyName ,
                      PropertyDescribe ,
                      PropertySort ,
                      PropertyType ,
                      CreateBy ,
                      CreateTime ,
                      UpdateBy ,
                      UpdateTime ,
                      isValid
                    )
            VALUES  ( 'B5C6BAD7-1C61-4454-821C-A26E013B7B28' , -- ProductPropertysID - uniqueidentifier
                      N'优惠套餐' , -- PropertyName - nvarchar(100)
                      N'' , -- PropertyDescribe - nvarchar(500)
                      1 , -- PropertySort - int
                      0 , -- PropertyType - int
                      'EA8262CF-5C96-49AF-8CA7-387493A15BC7' , -- CreateBy - uniqueidentifier
                      '2013-11-06 19:08:37.000' , -- CreateTime - datetime
                      'EA8262CF-5C96-49AF-8CA7-387493A15BC7' , -- UpdateBy - uniqueidentifier
                      '2013-11-06 19:08:37.000' , -- UpdateTime - datetime
                      1  -- isValid - bit
                    )";
            return dbCS.GetExecuteBool(sql, CommandType.Text, null);
        }

        //导入影友会新添加的属性关系
        public static bool InsertProductCategoryRelProperty()
        {
            string sql = @"INSERT INTO dbo.GM_ProductCategoryRelProperty
                        ( ProductCategoryRelPropertyID ,
                          ProductCategoryID ,
                          ProductPropertysID ,
                          PropertySort ,
                          PropertyType ,
                          PropertyUnit ,
                          PropertyValueType ,
                          SystemKeyWork ,
                          IsSearch
                        )
                VALUES  ( '0F1176EB-77DB-4DC5-B40E-A26E013BB2DC' , -- ProductCategoryRelPropertyID - uniqueidentifier
                          'ECF53F1B-A0CA-41B2-BF96-A1FF013D3F8B' , -- ProductCategoryID - uniqueidentifier
                          'B5C6BAD7-1C61-4454-821C-A26E013B7B28' , -- ProductPropertysID - uniqueidentifier
                          0 , -- PropertySort - int
                          1 , -- PropertyType - int
                          N'无' , -- PropertyUnit - nvarchar(10)
                          0 , -- PropertyValueType - bit
                          '' , -- SystemKeyWork - varchar(100)
                          0  -- IsSearch - int
                        )";
            return dbCS.GetExecuteBool(sql, CommandType.Text, null);
        }

        //导入优惠套餐属性值
        public static bool InsertProductPropertyKeywork()
        {
            string sql = @"SELECT * FROM dbo.GM_ProductPropertyKeywork WHERE ProductCategoryRelPropertyID='0F1176EB-77DB-4DC5-B40E-A26E013BB2DC'";
            DataTable dt = dbZS.GetDataTable(sql, CommandType.Text, null);
            if (dt.Rows.Count == 0)
                return false;

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                int isValid = dr["isValid"].ToString() == "True" ? 1 : 0;
                sb.Append(@"INSERT INTO dbo.GM_ProductPropertyKeywork ( ProductPropertyKeyworkID ,ProductCategoryRelPropertyID ,ProValue ,ProValueLevel ,ProValueDescribe ,CreateBy ,CreateTime ,UpdateBy ,UpdateTime ,isValid) VALUES  ( '" + dr["ProductPropertyKeyworkID"] + "' ,'" + dr["ProductCategoryRelPropertyID"] + "' ,  '" + dr["ProValue"] + "' ," + dr["ProValueLevel"] + " , N'' , '" + dr["CreateBy"] + "' ,  '" + dr["CreateTime"] + "' ,'" + dr["UpdateBy"] + "' ,'" + dr["UpdateTime"] + "' , " + isValid + ");");
            }
            return dbCS.GetExecuteBool(sb.ToString(), CommandType.Text, null);
        }

        //导入影友会商品数据
        public static bool InsertGoodsData()
        {
            string sql = @"SELECT top 1 * FROM uni2uni_Goodsinfo.dbo.GM_Goods WHERE ProductsID='0BDF61B2-31DE-4BDC-8841-A1FF014F638A' AND GoodName LIKE '%影友会%'";
            DataTable dt = dbZS.GetDataTable(sql, CommandType.Text, null);
            StringBuilder sb1 = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                string goodsID = dr["GoodsID"].ToString();
                // InsertImages(goodsID);
                // InsertGoodsPropertyValues(goodsID);
                //InsertCollectionInfo(goodsID);

                BuildGoodsSQL(sb1, dr);
            }

            //  db2.GetExecuteBool(sb1.ToString(), CommandType.Text, null);
            return true;
        }

        public static bool InsertImages(string goodsID)
        {
            string sql1 = @"SELECT * FROM uni2uni_Goodsinfo.dbo.GM_Images WHERE GoodsID='" + goodsID + "'";
            DataTable dt1 = dbZS.GetDataTable(sql1, CommandType.Text, null);
            StringBuilder sb1 = new StringBuilder();
            foreach (DataRow dr in dt1.Rows)
            {
                sb1.Append("INSERT INTO dbo.GM_Images( ImagesID ,GoodsID ,ImageName ,SmallImage ,BigImage ,MaxImage ,ImageType ,ImageSort ,ImageDecribe ,Isvalid )VALUES  ( '" + dr["ImagesID"] + "' ,'" + dr["GoodsID"] + "' , '" + dr["ImageName"] + "' , '" + dr["SmallImage"] + "' , '" + dr["BigImage"] + "' , '" + dr["MaxImage"] + "' ,1 , 1 , '' ,1);");
            }
            return dbCS.GetExecuteBool(sb1.ToString(), CommandType.Text, null);

        }

        public static bool InsertGoodsPropertyValues(string goodsID)
        {
            string sql = @"SELECT * FROM uni2uni_Goodsinfo.dbo.GM_ProductPropertyValues WHERE GoodID='" + goodsID + "'";
            DataTable dt = dbZS.GetDataTable(sql, CommandType.Text, null);
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("INSERT INTO dbo.GM_ProductPropertyValues( ProductPropertyValuesID ,GoodID ,ProductCategoryRelPropertyID ,ProductPropertyKeyworkID ,GoodPropertiyName ,GoodPropertiyValue ,GoodPropertiyAttachDes ,CreateBy ,CreateTime ,UpdateBy ,UpdateTime ,isValid) VALUES  ( '" + dr["ProductPropertyValuesID"] + "' , '" + dr["GoodID"] + "' , '" + dr["ProductCategoryRelPropertyID"] + "' ,  '" + dr["ProductPropertyKeyworkID"] + "' , '" + dr["GoodPropertiyName"] + "' , '" + dr["GoodPropertiyValue"] + "' ,  '" + dr["GoodPropertiyAttachDes"] + "' , '" + dr["CreateBy"] + "' ,  '" + dr["CreateTime"] + "' , '" + dr["UpdateBy"] + "' ,  '" + dr["UpdateTime"] + "' ,1)");
            }
            return dbCS.GetExecuteBool(sb.ToString(), CommandType.Text, null);
        }

        private static bool InsertCollectionInfo(string goodsID)
        {
            string sql = @"SELECT * FROM uni2uni_Goodsinfo.dbo.CollectionInfo WHERE InfoCode IN(
    SELECT GoodCode FROM dbo.GM_Goods WHERE ProductsID 
IN('3C59D871-4531-4538-AB07-A27700A17945','FFBD3F90-D81C-4E12-9312-A27700AE66BC')
)";
            DataTable dt = dbZS.GetDataTable(sql, CommandType.Text, null);
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(@"INSERT INTO dbo.CollectionInfo
                        ( InfoID ,
                          InfoCode ,
                          InfoTitle ,
                          Brand ,
                          MarketPrice ,
                          SalePrice ,
                          PurchasePrice ,
                          Discount ,
                          Description ,
                          SmallImg ,
                          BigImg ,
                          IndexImg ,
                          OrderSort ,
                          ChannelID ,
                          ProviderID ,
                          CategoryID ,
                          FullPath ,
                          ExtendFields ,
                          CollectionDate ,
                          InfoLevel ,
                          InsertTime ,
                          CreateOperatorID ,
                          UpdateTime ,
                          UpdateOperatorID ,
                          IsDel ,
                          NeedIntegral ,
                          StartTime ,
                          EndTime ,
                          AddressURL ,
                          Summary ,
                          Number ,
                          ADRecordID ,
                          DisplayStatus ,
                          AduitStatus ,
                          Uni2uniCardPrice ,
                          IsTop ,
                          LimitNumPerPerson ,
                          NewPurchasePrice ,
                          adtitle ,
                          NewGoodsID ,
                          IsPrepareSale ,
                          IsCodePay ,
                          CodeValue
                        ) VALUES  ( '" + dr["InfoID"] + "' , " +
                                  Convert.ToInt64(dr["InfoCode"].ToString()) + " , N'" +
                                  dr["InfoTitle"] + "' , N'" +
                                  dr["Brand"] + "' , " +
                                  Convert.ToDecimal(dr["MarketPrice"].ToString()) + " ,  " +
                                  Convert.ToDecimal(dr["SalePrice"].ToString()) + " , " +
                                  Convert.ToDecimal(dr["PurchasePrice"].ToString()) + ",0 , N'" +
                                  dr["Description"] + "' ,  '" +
                                  dr["SmallImg"] + "' ,  '" +
                                  dr["BigImg"] + "' ,  '" +
                                  dr["IndexImg"] + "' , 0 ,'" +
                                  dr["ChannelID"] + "' ,   '" +
                                  dr["ProviderID"] + "' ,  '" +
                                  dr["CategoryID"] + "' ,  '" +
                                  dr["FullPath"] + "' ,N'" +
                                  dr["ExtendFields"] + "' , '" +
                                  dr["CollectionDate"] + "' ," +
                                  Convert.ToInt32(dr["InfoLevel"].ToString()) + ", '" +
                                  dr["InsertTime"] + "' ,'" +
                                  dr["CreateOperatorID"] + "' ,  '" +
                                  dr["UpdateTime"] + "' ,  '" +
                                  dr["UpdateOperatorID"] + "' , 0 , " +
                                  Convert.ToDecimal(dr["NeedIntegral"].ToString()) + " , '" +
                                  dr["StartTime"] + "' , '" +
                                  dr["EndTime"] + "' , '" +
                                  dr["AddressURL"] + "' , '" +
                                  dr["Summary"] + "' , " +
                                  Convert.ToInt32(dr["Number"].ToString()) + " , '" +
                                  dr["ADRecordID"] + "' , '" +
                                  dr["DisplayStatus"] + "' ,  " +
                                  Convert.ToInt32(dr["AduitStatus"].ToString()) + " , " +
                                  Convert.ToDecimal(dr["Uni2uniCardPrice"].ToString()) + ",0 ,0 , " +
                                  Convert.ToDecimal(dr["NewPurchasePrice"].ToString()) + " , '' ,  '" +
                                  dr["NewGoodsID"] + "' , 0 , 1 , " +
                                  Convert.ToInt32(dr["CodeValue"].ToString()) + ")");
            }

            return dbCS.GetExecuteBool(sb.ToString(), CommandType.Text, null);
        }

        //导入影友会MemberProduct表关系数据
        public static bool InsetMemberProduct()
        {
            string sql = @"SELECT * FROM dbo.GM_MemberProduct WHERE MemberGoodsName LIKE '%影友会%' ORDER BY MemberGoodsName ASC";
            DataTable dt = dbZS.GetDataTable(sql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                string sqlStr=@"INSERT INTO GM_MemberProduct
                            ( MemberProductId ,
                              MemberGoodsID ,
                              MemberGoodsName ,
                              CardTime ,
                              ClubType ,
                              CardCodeRule ,
                              CardMedia ,
                              CardLevel ,
                              BMSortId ,
                              CreateBy ,
                              CreateTime
                            )
                    VALUES  ( @MemberProductId , -- MemberProductId - uniqueidentifier
                              @MemberGoodsID , -- MemberGoodsID - uniqueidentifier
                              @MemberGoodsName , -- MemberGoodsName - nvarchar(500)
                              @CardTime , -- CardTime - int
                              @ClubType , -- ClubType - int
                              @CardCodeRule , -- CardCodeRule - varchar(50)
                              @CardMedia , -- CardMedia - int
                              @CardLevel , -- CardLevel - int
                              @BMSortId , -- BMSortId - uniqueidentifier
                              @CreateBy , -- CreateBy - uniqueidentifier
                              @CreateTime  -- CreateTime - datetime
                            )";
                IList<DbParameter> list = new List<DbParameter>();
                list.Add(new SqlParameter("@MemberProductId", Guid.Parse(dr["MemberProductId"].ToString())));
                list.Add(new SqlParameter("@MemberGoodsID", Guid.Parse(dr["MemberGoodsID"].ToString())));
                list.Add(new SqlParameter("@MemberGoodsName", dr["MemberGoodsName"].ToString()));
                list.Add(new SqlParameter("@CardTime", Convert.ToInt32(dr["CardTime"].ToString())));
                list.Add(new SqlParameter("@ClubType", Convert.ToInt32(dr["ClubType"].ToString())));
                list.Add(new SqlParameter("@CardCodeRule", dr["CardCodeRule"].ToString()));
                list.Add(new SqlParameter("@CardMedia", Convert.ToInt32(dr["CardMedia"].ToString())));
                list.Add(new SqlParameter("@CardLevel", Convert.ToInt32(dr["CardLevel"].ToString())));
                list.Add(new SqlParameter("@BMSortId", Guid.Parse(dr["BMSortId"].ToString())));
                list.Add(new SqlParameter("@CreateBy", Guid.Parse(dr["CreateBy"].ToString())));
                list.Add(new SqlParameter("@CreateTime", Convert.ToDateTime(dr["CreateTime"].ToString())));
                dbCS.GetExecuteBool(sqlStr, CommandType.Text, list);
            }
            return true;
        }

        //导入影友会LifeClubProductRule表关系数据
        public static bool InsertLifeClubProductRule()
        {
            string sql = "SELECT * FROM dbo.GM_LifeClubProductRule WHERE MemberGoodsName LIKE '%影友会%' ORDER BY MemberGoodsName asc";
            DataTable dt = dbZS.GetDataTable(sql, CommandType.Text, null);
            foreach (DataRow dr in dt.Rows)
            {
                string sqlStr = @"INSERT INTO dbo.GM_LifeClubProductRule
                                ( MemberGoodsId ,
                                  MemberGoodsName ,
                                  ServiceGoodsId ,
                                  ServiceGoodsName ,
                                  ProductNumber ,
                                  ExecuteType ,
                                  GoodType 
                                )
                        VALUES  ( @MemberGoodsId , -- MemberGoodsId - uniqueidentifier
                                  @MemberGoodsName , -- MemberGoodsName - nvarchar(200)
                                  @ServiceGoodsId , -- ServiceGoodsId - uniqueidentifier
                                  @ServiceGoodsName , -- ServiceGoodsName - nvarchar(200)
                                  @ProductNumber , -- ProductNumber - int
                                  @ExecuteType , -- ExecuteType - int
                                  @GoodType -- GoodType - int
                                )";
                IList<DbParameter> list = new List<DbParameter>();
                dbCS.AddParameter(list, "MemberGoodsId", DbType.Guid, Guid.Parse(dr["MemberGoodsId"].ToString()));
                dbCS.AddParameter(list, "MemberGoodsName", DbType.String, dr["MemberGoodsName"].ToString());
                dbCS.AddParameter(list, "ServiceGoodsId", DbType.Guid, Guid.Parse(dr["ServiceGoodsId"].ToString()));
                dbCS.AddParameter(list, "ServiceGoodsName", DbType.String, dr["ServiceGoodsName"].ToString());
                dbCS.AddParameter(list, "ProductNumber", DbType.Int32, Convert.ToInt32(dr["ProductNumber"].ToString()));
                dbCS.AddParameter(list, "ExecuteType", DbType.Int32, Convert.ToInt32(dr["ExecuteType"].ToString()));
                dbCS.AddParameter(list, "GoodType", DbType.Int32, Convert.ToInt32(dr["GoodType"].ToString()));
                dbCS.GetExecuteBool(sqlStr, CommandType.Text, list);
            }
            return true;
        }

        //导入影友会SpecialProductCategory表影友会员卡分类数据
        public static bool InsertSpecialProductCategory()
        {
            string sql = @"INSERT INTO uni2uni_Goodsinfo.dbo.SpecialProductCategory
                                ( CategoryID ,
                                  CategoryName ,
                                  Sequence ,
                                  CategoryType ,
                                  CategoryTypeName ,
                                  InsertTime ,
                                  CreateOperatorID ,
                                  UpdateTime ,
                                  UpdateOperatorID ,
                                  IsDel
                                )
                        VALUES  ( 'A5C833F9-8579-4232-8E90-F58C0BC6B734' , -- CategoryID - uniqueidentifier
                                  N'影友会员卡' , -- CategoryName - nvarchar(50)
                                  1 , -- Sequence - int
                                  3 , -- CategoryType - tinyint
                                  '联嘉BST服务' , -- CategoryTypeName - varchar(100)
                                  '2013-11-08 09:00:17.003' , -- InsertTime - datetime
                                  '00000000-0000-0000-0000-000000000000' , -- CreateOperatorID - uniqueidentifier
                                  '2013-11-08 09:00:17.003' , -- UpdateTime - datetime
                                  '00000000-0000-0000-0000-000000000000' , -- UpdateOperatorID - uniqueidentifier
                                  0  -- IsDel - tinyint
                                )";
            return dbCS.GetExecuteBool(sql, CommandType.Text, null);

        }

        private static void BuildGoodsSQL(StringBuilder sb1, DataRow dr)
        {
            sb1.Append(@"INSERT INTO dbo.GM_Goods  ( GoodsID , 
                                        ProductsID ,
                                        GoodCode,
                                        GoodName ,
                                        GoodShopName ,
                                        GoodDetailPath ,
                                        GoodPrice ,
                                        SalePrice ,
                                        Uni2uniCardPrice ,
                                        GoodState ,
                                        ProviderPrice ,
                                        IsMaxSale ,
                                        GoodInfo ,
                                        GoodSpecification , 
                                        GoodService ,
                                        GoodLevel ,
                                        GoodStatus ,
                                        ApproveContent ,
                                        CreateBy ,
                                        CreateTime ,
                                        UpdateBy ,
                                        UpdateTime,
                                        IsValid) VALUES  ( '" +
                                    dr["GoodsID"] + "' , '" +
                                    dr["ProductsID"] + "' , " +
                                    Convert.ToInt64(dr["GoodCode"].ToString()) + ",N'" +
                                    dr["GoodName"] + "' , N'" +
                                    dr["GoodShopName"] + "' ,'" +
                                    dr["GoodDetailPath"] + "' , " +
                                    Convert.ToDecimal(dr["GoodPrice"].ToString()) + " ," +
                                    Convert.ToDecimal(dr["SalePrice"].ToString()) + " ,  " +
                                    Convert.ToDecimal(dr["Uni2uniCardPrice"].ToString()) + " ," +
                                    Convert.ToInt32(dr["GoodState"].ToString()) + " , " +
                                    Convert.ToDecimal(dr["ProviderPrice"].ToString()) + " ,1 ,N'" +
                                    dr["GoodInfo"] + "' , N'" + dr["GoodSpecification"] + "' , N'" +
                                    dr["GoodService"] + "' ,0 , 1 ,N'' , '" + dr["CreateBy"] + "' , '" +
                                    dr["CreateTime"] + "' ,  '" +
                                    dr["UpdateBy"] + "' ,  '" +
                                    dr["UpdateTime"] + "' , 1)");
        }

        public static string GetGoods()
        {
            string sql = @"SELECT GoodsID,GoodName,GoodCode,GoodPrice FROM 
                        uni2uni_Goodsinfo.dbo.GM_Goods WHERE GoodsID IN(
	            SELECT ServiceGoodsId FROM uni2uni_Goodsinfo.dbo.GM_LifeClubProductRule GROUP BY ServiceGoodsId
            ) ";
            // DataTable dt = db2.GetDataTable(sql, CommandType.Text, null);
             DataTable dt = dbZS.GetDataTable(sql, CommandType.Text, null);
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(@"INSERT INTO uni2uni_GoodsinfoDevelop.dbo.GM_MemberCommodity( fID , version ,MemberGoodName ,MemberGoodsCode ,Units ,Price ,IsMy ,StartDate ,EndDate ,Mark) VALUES  ( '" + dr["GoodsID"] + "' , 0 , '" + dr["GoodName"] + "' ,'" + dr["GoodCode"] + "' , '张' ,'" + dr["GoodPrice"] + "' , '1' ,GETDATE() ,'2013-12-31', '')\r\n");
            }
           
            return sb.ToString();
        }

    }
}
