using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Uni2uni.UniCard.ClientAPI;
using Uni2uni.UniCard.ClientAPI.Model;

namespace UniCardWeb
{
    public partial class CardDelivery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CardTypeTree tree = CardService.GetCardGroup("3001010000000032");
            BindDelivery.DataSource = tree.Nodes;
            BindDelivery.DataBind();
        }

        protected void BindDelivery_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rpquestionlist") as Repeater;//找到里层的repeater对象
                GroupNode groupNode = (GroupNode)e.Item.DataItem;//找到分类Repeater关联的数据项                 
                rep.DataSource = groupNode.ChildGoods;                
                rep.DataBind();
            }

        }

    }
}