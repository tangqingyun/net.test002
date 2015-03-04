<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Com.WebSite.Main.Products" %>
<%@ Import Namespace="Com.WebSite.Models.Entity" %>
<%@ Import Namespace="Com.WebSite.Models.ParamterEntity" %>

<%
    ChannelService _ChannelService = InstanceService.GetInstance<ChannelService>();
    int channelId = 1009;
    Entity_Pager pager;
    ArticleQueryParam query = new ArticleQueryParam() { ChannelID = channelId };
    int size = 10;
    IEnumerable<Entity_FullArcticle> list = InstanceService.GetArcticleServiceInstance().GetArcticlePager(query, Index, size, out pager);
    var Channel = _ChannelService.GetChannelByChannelID(channelId);
%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<title><%=Channel.ChannelName %>--石家庄盈诺科技有限公司</title>
<meta name="description" content="<%=Channel.Description %>" />
<meta name="keywords" content="<%=Channel.Keywords %>" />
<!--#include file="Head.html"--> 
<link href="Style/pagination.css" rel="stylesheet" />
<script src="Script/jquery.pagination.js"></script>
</head>
<body>
 <!--#include file="Header.aspx"--> 
<div id="body">
<!--#include file="MediaFlash.aspx"--> 

<div class="sidebar inner">
    <!--#include file="LeftNav.aspx"--> 
    <div class="sb_box">
	    <h3 class="title">
			<div class="position">当前位置：<a href="../" title="首页">首页</a> &gt; <a href="/products.aspx?tid=<%=channelId %>" ><%=Channel.ChannelName %></a></div>
			<span><%=Channel.ChannelName %></span>
		</h3>
		<div class="clear"></div>
 
        <div class="active" id="productlist">
			<ul class='list-none metlist'></ul>
		<div class="clear"></div>
		</div>
		<div id="pagination" class="pagination" ></div>
    </div>
    <div class="clear"></div>
</div>

<!--#include file="Footer.aspx"--> 
</div>

    <script src="Script/pagination.ext.js"></script>
    <script type="text/javascript">
        var pageIndex = 0;
        var pageSize = "<%=size%>";
        var pageNum = "<%=pager.PageCount%>";
        $(function () {
            //加入分页的绑定   
            initPagination(pageIndex, pageSize, pageNum);
        });

        function pageselectCallback(page_index) {
            LoadPagerData(page_index);
        }

        function LoadPagerData(pageIndex) {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: '/Ashx/Article.ashx',
                data: { "index": (pageIndex + 1), "channel": "<%=channelId%>", "size": pageSize },
                success: function (result) {
                    $("#productlist ul").html("");
                    var html = "";
                    $.each(result, function (i, n) {
                        html += "<li class='list'><a href='/newsdetail.aspx?aid=" + result[i].ArcticleID + "' title='" + result[i].Title + "' target='_self' class='img'>";
                        html += "<img src='" + result[i].ThumPic + "'  width='160' height='120' /></a>";
                        html += "<h3><a href='product5.html' target='_self'>" + result[i].Title + "</a></h3>";
                        html += "</li>\r\n";
                    });
                    $("#productlist ul").append(html);
                }
            });
        }

    </script>
</body>
</html>
