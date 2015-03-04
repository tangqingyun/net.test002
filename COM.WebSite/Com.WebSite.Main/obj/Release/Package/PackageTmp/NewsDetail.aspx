<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="Com.WebSite.Main.NewsDetail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=model.Title %></title>
<meta name="description" content="<%=model.Description %>" />
<meta name="keywords" content="<%=model.Keywords %>" />

<!--#include file="Head.html"--> 
</head>
<body>

<!--#include file="Header.aspx"--> 
<div id="body">
<!--#include file="MediaFlash.aspx"--> 
<div class="sidebar inner">
    <!--#include file="LeftNav.aspx"--> 
    <div class="sb_box">
	    <h3 class="title">
			<div class="position">当前位置：<a href="../" title="首页">首页</a> &gt; <a href=""><%=model.ChannelName %></a></div>
			<span><%=model.ChannelName %></span>
		</h3>
	   <div class="clear"></div>
      <div class="active" id="shownews">
        <h1 class="title"><%=model.Title %>
        <p  class="acp">
            <span>发布时间：<%=model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") %></span>
            <span><%=!string.IsNullOrWhiteSpace(model.Writer)?"作 者："+model.Writer:string.Empty%></span>
        </p>
        </h1>
        
     <div class="editor">
         <%=!string.IsNullOrWhiteSpace(model.LitPic)?string.Format("<div class='litpic'><img src='{0}'/></div>",model.LitPic):string.Empty %>
         <%=model.Body %><div class="clear"></div></div>
	 <div class="met_hits">
        <div class='metjiathis'>
        <div class="jiathis_style">
            <span class="jiathis_txt">分享到：</span>
            <a class="jiathis_button_icons_1"></a><a class="jiathis_button_icons_2"></a>
            <a class="jiathis_button_icons_3"></a><a class="jiathis_button_icons_4"></a>
            <a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis" target="_blank"></a>
        </div>
        <script type="text/javascript" src="http://v3.jiathis.com/code/jia.js?uid=1346378669840136" charset="utf-8"></script>
        </div>
        点击次数：<span><%=model.Click %></span>&nbsp;&nbsp;
        更新时间：<%=model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") %>&nbsp;&nbsp;
        【<a href="javascript:window.print()">打印此页</a>】&nbsp;&nbsp;
        【<a href="javascript:self.close()">关闭</a>】</div>
<div class="met_page">&nbsp;&nbsp;
<%
var acticle=  _ArcticleService.GetArcicleScroll(model.ArcticleID, Com.WebSite.Models.Enum.EnumArticlePlace.Next);
if (acticle != null) {
    Response.Write("下一篇：<a href='newsdetail.aspx?aid="+acticle.ArcticleID+"' >" + acticle .Title+ "</a>");
}
 %></div>
</div>
 
    </div>
    <div class="clear"></div>
</div>

<!--#include file="Footer.aspx"--> 
        </div>
</body>
</html>
