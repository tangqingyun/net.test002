using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uni2uni.com.BLL.MemberService;
using uni2uni.com.Model.MemberService.Common;

namespace TestCardJUnit
{
    [TestFixture]
    public class JUnitTest
    {
        public JUnitTest() { }

        [Test]
        public void InsertExecuteDetailWireless()
        {
            MemberExecuteDetailWirelessService bll = new MemberExecuteDetailWirelessService();
            ExecuteDetailWirelessEntity model = new ExecuteDetailWirelessEntity
            {
                CreateBy = Guid.Empty,
                CreateTime = DateTime.Now,
                ExecutePlanId = new Guid("EA9D0C8A-8355-E311-9ADF-00155D02B905"),
                Remark = "",
                ThirdOrderAmount = 500,
                ThirdOrderNo = "464"
            };
            MemberExecutePlanEntity mepEntity = new MemberExecutePlanEntity
            {
                ExecutePlanId = new Guid("EA9D0C8A-8355-E311-9ADF-00155D02B905"),
                ExecuteState = 1
            };
            bool bol = bll.InsertExecuteDetailWireless(model, mepEntity);
            Assert.IsTrue(bol, "添加成功！");
        }

        [Test]
        public void InsertExecuteDetailLifeClub()
        {
            MemberExecuteDetailLifeClubService bll = new MemberExecuteDetailLifeClubService();
            ExecuteDetailLifeClubEntity model = new ExecuteDetailLifeClubEntity
            {
                CreateBy = Guid.Empty,
                CreateTime = DateTime.Now,
                ExecutePlanId = new Guid("EA9D0C8A-8355-E311-9ADF-00155D02B905"),
                Remark = "",
                ThirdOrderAmount = 500,
                ThirdOrderNo = "464",
                CardNo = "8885100000011233",
                CardPassword = "123456",
                ExpressCompany =1,
                ExpressNo = "",
            };

            MemberExecutePlanEntity mepEntity = new MemberExecutePlanEntity
            {
                ExecutePlanId = new Guid("EA9D0C8A-8355-E311-9ADF-00155D02B905"),
                ExecuteState = 1
            };

          //  bool bol = bll.InsertExecuteDetailLifeClub(model, mepEntity);
          //  Assert.IsTrue(bol, "添加成功！");
        }


    }
}
