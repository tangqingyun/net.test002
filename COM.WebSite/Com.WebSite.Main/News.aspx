<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Com.WebSite.Main.News" %>

<%@ Import Namespace="Com.WebSite.Models.Entity" %>
<%@ Import Namespace="Com.WebSite.Models.ParamterEntity" %>
<%
    ChannelService _ChannelService=InstanceService.GetInstance<ChannelService>();
    ArticleQueryParam query = null;
    Entity_Pager pager;
    int channelID;
    if (int.TryParse(GetQueryString("tid"), out channelID))
    {
        query = new ArticleQueryParam();
        query.ChannelID = channelID;
    }
    var Channel=_ChannelService.GetChannelByChannelID(channelID);
    if (Channel == null) {
        Channel = new Entity_Channel();
    }
    int size = 10;
    IEnumerable<Entity_FullArcticle> list = InstanceService.GetArcticleServiceInstance().GetArcticlePager(query, Index, size, out pager);
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
                <div class="position">当前位置：<a href="/" title="首页">首页</a> &gt; <a href="/news.aspx?tid=<%=channelID %>"><%=Channel.ChannelName %></a></div>
                <span><%=Channel.ChannelName %></span>
            </h3>
            <div class="clear"></div>

            <div class="active" id="newslist">
                <ul class='list-none metlist'>

                </ul>
                <div id="pagination" class="pagination" ></div>
            </div>

        </div>
        <div class="clear"></div>
    </div>

    <!--#include file="Footer.aspx"-->
</div>

    <script type="text/javascript">
        var pageindex=0;
        var pagesize = "<%=size%>";
        var total = "<%=pager.Total%>";

        $(function () {
          
            var datas = { "do": "pager", "channel": "<%=GetQueryString("tid")%>", "size": pagesize };
            $.paginationExt("pagination",
                pageindex,
                pagesize,
                total,
                "/Ashx/Article.ashx",
                datas,
                function (result) {
                    $("#newslist ul").html("");
                    var html = "";
                    $.each(result, function (i, n) {
                        html += "<li class='list top'>";
                        html += "<span>" + ConvertJSONDatete(result[i].CreateTime) + "</span>";
                        html += "<a href='newsdetail.aspx?aid=" + result[i].ArcticleID + "' title='" + result[i].Title + "' target='_blank'>" + result[i].Title + "</a><p></p>";
                        html += "</li>\r\n";
                    });
                    $("#newslist ul").append(html);
            });

        });

       

        function ConvertJSONDatete(JSONDateString) {
            jsondate = JSONDateString.replace("/Date(", "").replace(")/", "");
            if (jsondate.indexOf("+") > 0) {
                jsondate = jsondate.substring(0, jsondate.indexOf("+"));
            } else if (jsondate.indexOf("-") > 0) {
                jsondate = jsondate.substring(0, jsondate.indexOf("-"));
            }
            var date = new Date(parseInt(jsondate, 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
            var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
            var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
            return date.getFullYear() + "-" + month + "-" + currentDate + " " + hours + ":" + minutes + ":" + seconds;
        }

        


    </script>

</body>
</html>
