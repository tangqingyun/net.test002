using Basement.Framework.Data.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace Bst.Model
{
    [Serializable]
    [Table("SP_Shop")]
    public class ShopEntity : StandardEntity
    {

        /// <summary>
        /// 主键
        /// </summary>
        [Column("ShopId", DbType.Guid, true, false)]
        public Guid ShopId { get; set; }


        /// <summary>
        /// 商户所属总店ID
        /// </summary>
        [Column("ShopPId", DbType.Guid, false, false)]
        public Guid ShopPId { get; set; }


        /// <summary>
        /// 网点Id
        /// </summary>
        [Column("BankBranchId", DbType.Guid, false, false)]
        public Guid BankBranchId { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Column("ShopCategoryID", DbType.Guid, false, false)]
        public Guid ShopCategoryID { get; set; }

        /// <summary>
        /// 商圈ID
        /// </summary>
        [Column("BusinessAreaId", DbType.Guid, false, false)]
        public Guid BusinessAreaId { get; set; }

        /// <summary>
        /// 店铺名
        /// </summary>
        [Column("ShopName", DbType.String, false, false)]
        public string ShopName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Column("Phone", DbType.String, false, false)]
        public string Phone { get; set; }

        /// <summary>
        /// 简要描述
        /// </summary>
        private string description;
        [Column("Description", DbType.String, false, false)]
        public string Description
        {
            get { if (string.IsNullOrEmpty(description)) { return ""; } return description; }
            set { description = value; }
        }



        /// <summary>
        /// 详细描述
        /// </summary>
        private string detailDescription;
        [Column("DetailDescription", DbType.String, false, false)]
        public string DetailDescription
        {
            get { if (string.IsNullOrEmpty(detailDescription)) { return ""; } return detailDescription; }
            set { detailDescription = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        [Column("Address", DbType.String, false, false)]
        public string Address { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Column("ProvinceId", DbType.Int32, false, false)]
        public int ProvinceId { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Column("CityId", DbType.Int32, false, false)]
        public int CityId { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [Column("DistrictId", DbType.Int32, false, false)]
        public int DistrictId { get; set; }

        /// <summary>
        /// 大图
        /// </summary>
        [Column("BigImage", DbType.String, false, false)]
        public string BigImage { set; get; }


        /// <summary>
        ///中图
        /// </summary>
        [Column("MidImage", DbType.String, false, false)]
        public string MidImage { set; get; }

        /// <summary>
        /// 小图
        /// </summary>
        [Column("SmallImage", DbType.String, false, false)]
        public string SmallImage { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        [Column("Longitude", DbType.Decimal, false, false)]
        public Decimal Longitude { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [Column("Latitude", DbType.Decimal, false, false)]
        public Decimal Latitude { get; set; }

        /// <summary>
        /// 人均消费从
        /// </summary>
        [Column("FeeAvgFrom", DbType.Int32, false, false)]
        public int FeeAvgFrom { get; set; }

        /// <summary>
        /// 人均消费至
        /// </summary>
        [Column("FeeAvgTo", DbType.Int32, false, false)]
        public int FeeAvgTo { get; set; }

        /// <summary>
        /// 是否预订
        /// </summary>
        [Column("IsOpenBooking", DbType.Boolean, false, false)]
        public Boolean IsOpenBooking { get; set; }

        /// <summary>
        /// 是否快递
        /// </summary>
        [Column("IsOpenExpress", DbType.Boolean, false, false)]
        public Boolean IsOpenExpress { get; set; }

        /// <summary>
        /// 是否外卖
        /// </summary>
        [Column("IsOpenTakeOut", DbType.Boolean, false, false)]
        public Boolean IsOpenTakeOut { get; set; }

        /// <summary>
        /// 是否上门服务
        /// </summary>
        [Column("IsOpenToHome", DbType.Boolean, false, false)]
        public bool IsOpenToHome { get; set; }

        /// <summary>
        /// 是否Bst商户
        /// </summary>
        [Column("IsBST", DbType.Boolean, false, false)]
        public bool IsBST { get; set; }

        /// <summary>
        /// 访问次数统计
        /// </summary>
        [Column("VisitCount", DbType.Int32, false, false)]
        public int VisitCount { get; set; }

        /// <summary>
        /// 星级
        /// </summary>
        [Column("StarLevel", DbType.Int32, false, false)]
        public int StarLevel { get; set; }

        /// <summary>
        /// 营业开始时间
        /// </summary>
        [Column("BusinessHoursFrom", DbType.Decimal, false, false)]
        public Decimal BusinessHoursFrom { get; set; }

        /// <summary>
        /// 营业结束时间
        /// </summary>
        [Column("BusinessHoursTo", DbType.Decimal, false, false)]
        public Decimal BusinessHoursTo { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        [Column("IsOpen", DbType.Boolean, false, false)]
        public bool IsOpen { set; get; }
        /// <summary>
        /// 是否外部采集数据
        /// </summary>
        [Column("IsGather", DbType.Boolean, false, false)]
        public bool IsGather { set; get; }

        /// <summary>
        /// 是否是银行实体店
        /// </summary>
        [Column("IsBankShop", DbType.Boolean, false, false)]
        public Boolean IsBankShop { set; get; }
        [Column("OpenBookingDiscount", DbType.Int32, false, false)]
        public int OpenBookingDiscount { get; set; }
        [Column("OpenBookingFrom", DbType.Int32, false, false)]
        public int OpenBookingFrom { get; set; }
        [Column("OpenBookingTo", DbType.Int32, false, false)]
        public int OpenBookingTo { get; set; }
        [Column("OpenBookingLimitTime", DbType.Decimal, false, false)]
        public decimal OpenBookingLimitTime { get; set; }
        [Column("IsRooms", DbType.Boolean, false, false)]
        public bool IsRooms { get; set; }
        [Column("ExternalID", DbType.Int32, false, false)]
        public int ExternalID { set; get; }
        [Column("OrderNum", DbType.Int32, false, false)]
        public int OrderNum { set; get; }

        /// <summary>
        /// 店铺编码
        /// </summary>
        [Column("ShopCode", DbType.AnsiString, false, false)]
        public string ShopCode { get; set; }
        /// <summary>
        /// 满(满多少才能减)
        /// </summary>
        [Column("BeyondMoney", DbType.Decimal, false, false)]
        public decimal BeyondMoney { get; set; }
        /// <summary>
        /// 减(超过额度后减多少)
        /// </summary>
        [Column("SubstractMoney", DbType.Decimal, false, false)]
        public decimal SubstractMoney { get; set; }
        /// <summary>
        /// 满多少包邮
        /// </summary>
        [Column("FreeDeliveryMoney", DbType.Decimal, false, false)]
        public decimal FreeDeliveryMoney { get; set; }


        [Column("BSTShortName", DbType.String, false, false)]
        public string BSTShortName
        {
            set;
            get;
        }

        [Column("IsUseCard", DbType.Int32, false, false)]
        public bool IsUseCard
        {
            set;
            get;
        }
    }
}
