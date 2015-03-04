<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Com.WebSite.Main.About" %>

 <% Entity_Channel channel = InstanceService.GetChannelServiceInstance().GetChannelByChannelID(1006);%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
<title><%=channel.ChannelName %>--石家庄盈诺科技有限公司</title>
<meta name="description" content="<%=channel.Description %>" />
<meta name="keywords" content="<%=channel.Keywords %>" />
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
			<div class="position">当前位置：<a href="/index.aspx" title="首页">首页</a> &gt; <a href="about.aspx" ><%=channel.ChannelName %></a></div>
			<span><%=channel.ChannelName %></span>
		</h3>
		<div class="clear"></div>
 
        <div class="editor active" id="showtext">
            <%=channel.Content %>
			<div class="clear"></div>
		</div>
 
    </div>
    <div class="clear"></div>
</div>
     <!--#include file="Footer.aspx"--> 
</div>

</body>
</html>
