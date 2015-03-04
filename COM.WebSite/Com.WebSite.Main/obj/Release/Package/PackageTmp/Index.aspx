<%@ Page Language="C#" autoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Com.WebSite.Main.Index" %>
<%@ Import Namespace="Com.WebSite.Models.Entity" %>
<%@ Import Namespace="Com.WebSite.Main.Utils" %>
<%
   ArcticleService _ArcticleService = InstanceService.GetArcticleServiceInstance();
   ChannelService _ChannelService = InstanceService.GetChannelServiceInstance();
   SysInfoService _SysInfoService=InstanceService.GetSysInfoInstance();
   IEnumerable<Entity_Arcticle> imglist=_ArcticleService.GetArcticleListByFlag(new string[] { "p"}, 0);
   var EnterpriseNews=_ArcticleService.GetArcticleListByChannelID(4, 1010);
   var IndustryNews = _ArcticleService.GetArcticleListByChannelID(4, 1011);
   var Channel = _ChannelService.GetChannelByChannelID(1003);
   var config = new SiteConfig();
%>
<!DOCTYPE HTML PUBliC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
 <head>
 <title>石家庄盈诺科技有限公司</title>
<meta name="renderer" content="webkit">
<meta charset="utf-8"> 
<meta content=IE=edge,chrome="1" http-equiv="X-Ua-Compatible">
<meta name="description" content="<%=config["cfg_description"].Value %>">
<meta name="keywords" content="<%=config["cfg_keywords"].Value  %>">
<meta name="GENERaTOR" content="MSHTML 8.00.7601.17514">
<!--#include file="Head.html"--> 
</head>

<BODY>

<!--#include file="Header.aspx"--> 

<div id="body">

<!--#include file="MediaFlash.aspx"--> 

<div class="index inner">
         
<div class="aboutus style-1">
<h3 class="title"><span class="myCorner" data-corner="top 5px">公司简介</span> <a 
class="more" href="/about.aspx">更多&gt;&gt;</a> </h3>
<div class="active editor clear contour-1">
<%=Channel.Content %>
<div class=clear></div></div></div>

<div class="index-conts style-2" >
<h3 class="title myCorner" data-corner="top 5px">服务中心 <a class="more" title="" href="/contract.aspx">更多&gt;&gt;</a> </h3>
<div class="active clear listel service" style="padding:0px;">
<ol class="list-none metlist">
<%=Channel.Description %>
</ol></div></div>
<div class=clear></div>


<div class="index-news style-1">
<h3 class="title"><span class="myCorner" data-corner="top 5px">企业新闻</span> <a 
class="more" title="更多" href="/news.aspx?tid=1010">更多&gt;&gt;</a> </h3>
<div class="active clear listel contour-2">
<ol class="list-none metlist">
<%
if (EnterpriseNews != null && EnterpriseNews.Count()>0){
    foreach(var news in EnterpriseNews) {
%>
  <li class="list"><span class=time><%=news.CreateTime.ToString("yyyy-MM-dd") %></span>
 <a  title="<%=news.Title %>" href="<%=news.DetailPage %>?aid=<%=news.ArcticleID %>" target="_self"><%=Basement.Framework.Utility.CharTool.Truncate(news.Title,30)%></a></li>
 <% }
 }%>
 </ol>
</div></div>

<div class="index-news style-1" style="margin-left:19px;">
<h3 class="title"><span class=myCorner data-corner="top 5px">行业信息</span> <a 
class=more title="" href="/news.aspx?tid=1011">更多 >></a> </h3>

<div class="active clear listel contour-2">
<ol class="list-none metlist">
<%
if (IndustryNews != null && IndustryNews.Count() > 0)
{
    foreach (var news in IndustryNews)
    {
%>
  <li class="list"><span class=time><%=news.CreateTime.ToString("yyyy-MM-dd") %></span>
 <a  title="<%=news.Title %>" href="<%=news.DetailPage %>?aid=<%=news.ArcticleID %>" target="_self"><%=Basement.Framework.Utility.CharTool.Truncate(news.Title,30)%></a></li>
<% }
 }%>
</ol></div>

</div>


<div class="clear p-line"></div>
<div class="index-product style-2">
<h3 class="title myCorner" data-corner="top 5px"><span>产品信息</span> 
<div class=flip>
<P id=trigger></P><a id=car_prev class=prev href="javascript:void(0);"></a><a 
id=car_next class=next href="javascript:void(0);"></a></div><a class=more href="products.aspx">更多&gt;&gt;</a> 
</h3>
<div class="active clear">
<div id=indexcar class=profld data-listnum="5">
<ol class="list-none metlist">
<%
if (imglist != null && imglist.Count()>0)
{
    foreach(var model in imglist) {
    %>
<li class=list><a class=img href="newsdetail.aspx?aid=<%=model.ArcticleID %>" target="_self"><img alt=""  src="<%=model.ThumPic %>" width="150"/></a></li>
<%
    } 
}%>

</ol></div></div></div>
<div class=clear></div>

<div class=index-links>
<h3 class=title>友情链接 <a class="more" href="http://www.metinfo.cn/demo/metv5/link/">更多&gt;&gt;</a> </h3>
<div class="active clear">
<div class=img>
<UL class=list-none></UL></div>
<div class=txt>
<UL class=list-none>
  <li><a title="" href="http://www.365yama.cn/" target=_blank>长沙雅玛信息</a></li>
  <li><a title="" href="http://www.gxbaidu.net/" target=_blank>南宁市网大网络</a></li>
  <li><a title="" href="http://www.topsi.net.cn/" target=_blank>托普斯网络</a></li>
  <li><a title="" href="http://www.lygseo.com/" target=_blank>连云港网站建设</a></li>
  <li><a title="" href="http://www.seocool.cn/" target=_blank>杭州网络建设</a></li>
  <li><a title="" href="http://www.fenghuangit.com/" 
  target=_blank>烟台网络公司</a></li>
  <li><a title="" href="http://www.52lefen.com/" target=_blank>大连网络公司</a></li>
  <li><a title="" href="http://www.nbwangzhan.com/" 
target=_blank>宁波网络公司</a></li></UL></div></div>
<div class=clear></div></div></div>
    
<!--#include file="Footer.aspx"--> 
</div>

<script type=text/javascript src="Script/fun.inc.js"></script>
</BODY></HTML>

