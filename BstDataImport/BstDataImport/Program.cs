using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basement.Framework;
using Basement.Framework.Data;
using Bst.Model;
using System.Data.Common;
namespace BstDataImport
{
    class Program
    {
        static IDatabase databaseBst = Database.LocalLife_Bst;
        static IDatabase databaseImport = Database.LocalLife_Import;
        static void Main(string[] args)
        {
            List<ShopEntity> shopList = databaseImport.ExecuteList<ShopEntity>("SELECT TOP 1 * FROM dbo.SP_Shop WHERE ShopId='EA34F4DE-0AD1-4EF8-8A5C-001B9DEA6B2D' ORDER BY CreateTime DESC").ToList();
            shopList.ForEach(model =>
            {
                model.IsUseCard = false;
                model.BSTShortName = string.Empty;
                string script = string.Format("SELECT * FROM dbo.SP_ShopImg WHERE ShopId='{0}'", model.ShopId);
                IEnumerable<ShopImgEntity> imgList = databaseImport.ExecuteList<ShopImgEntity>(script);
                StringBuilder sb = new StringBuilder();
                try
                {
                    int n = databaseBst.Insert<ShopEntity>(model);
                    if (n == 0)
                    {
                        sb.AppendFormat("商户:{0}SP_Shop表数据插入失败", model.ShopName);
                    }

                    if (imgList.Count() > 0)
                    {
                        int num = databaseBst.Insert<ShopImgEntity>(imgList);
                        if (num == 0)
                            sb.AppendFormat("| SP_ShopImg表数据插入失败");
                    }

                    if (!string.IsNullOrWhiteSpace(sb.ToString()))
                        Console.WriteLine(sb.ToString());
                    else 
                        Console.WriteLine("商户："+model.ShopName+"导入成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("商户：" + model.ShopName + "导入失败：" + ex.Message);
                }
               
            });
            Console.ReadKey();
            #region MyRegion
            ShopEntity shop = new ShopEntity
               {
                   ShopId = Guid.NewGuid(),
                   Address = "",
                   BankBranchId = new Guid(),
                   BeyondMoney = 0,
                   BigImage = "",
                  // BSTShortName = "",
                   BusinessAreaId = Guid.NewGuid(),
                   BusinessHoursFrom = 0,
                   BusinessHoursTo = 0,
                   CityId = -1,
                   Description = "",
                   DetailDescription = "",
                   DistrictId = -1,
                   ExternalID = 0,
                   FeeAvgFrom = 1,
                   FeeAvgTo = 100,
                   FreeDeliveryMoney = 100,
                   IsBankShop = false,
                   IsBST = false,
                   IsGather = false,
                   IsOpen = false,
                   IsOpenBooking = false,
                   IsOpenExpress = false,
                   IsOpenTakeOut = false,
                   IsOpenToHome = false,
                   IsRooms = false,
                   Latitude = 0,
                   Longitude = 0,
                   MidImage = "",
                   OpenBookingDiscount = 1,
                   OpenBookingFrom = 1,
                   OpenBookingLimitTime = 0,
                   OpenBookingTo = 100,
                   OrderNum = 0,
                   Phone = "",
                   ProvinceId = -1,
                   ShopCategoryID = Guid.NewGuid(),
                   ShopCode = string.Empty,
                   ShopName = "",
                   ShopPId = Guid.NewGuid(),
                   SmallImage = "",
                   StarLevel = 2,
                   SubstractMoney = 100,
                   VisitCount = 100
               };
            #endregion

          
        }


    }


    public class ShopModel
    {
        public ShopEntity shop { set; get; }
        public IEnumerable<ShopImgEntity> imgList { set; get; }
    }

}
