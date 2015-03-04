<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Channel_Manage.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Channel_Manage" %>
<%@ Import Namespace="Com.WebSite.Models" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>栏目管理</title>
<link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
<link href="Easyui/themes/icon.css" rel="stylesheet" />
<script src="../Script/jQuery1.7.2.js"></script>
<script src="Script/jquery.easyui.min.js"></script>
<link href="Css/style.css" rel="stylesheet" />
<style type="text/css">
    #list li {text-indent:3px;
    border-bottom:1px solid #d6d6d6; padding:5px 0px;}
    #list li .ops {
    float:right;}
    #list li:hover {
        background:#fbfcb2;
    }
</style>
</head>
<body>

 
<form id="form" runat="server">

    <div class="hbutton">
        <a id="btn_add" href="#" class="easyui-linkbutton" onclick="addChannel(0)">增加顶级栏目</a>&nbsp;&nbsp;
        <a id="btn_cancel" href="#" class="easyui-linkbutton"> 关 闭 </a>
    </div>
    
<ul id="list">
<%
   var rootList = _ChannelService.GetChannelListByReid();
    foreach(var root in rootList){
        %>   
        <li>
            <span class="ops">
                <a href="javascript:;" onclick="addChannel(<%=root.ChannelID%>);">增加子类</a> |
                <a href="javascript:;" onclick="editChannel('<%=root.ChannelName %>','<%=root.ChannelID%>')">编辑</a> |
                <a href="javascript:;" onclick="delChannel(this,'<%=root.ChannelID %>')">删除</a>
            </span>
            <span><%=root.ChannelName%></span>
        </li>
    
       <%
        var sub1List = _ChannelService.GetChannelListByReid(root.ChannelID);
        foreach(var sub1 in sub1List){
       %>            
            <li>
            <span class="ops">
                <a href="javascript:;" onclick="addChannel(<%=sub1.ChannelID%>);">增加子类</a> |
                <a href="javascript:;" onclick="editChannel('<%=sub1.ChannelName %>','<%=sub1.ChannelID%>')">编辑</a> |
                <a href="javascript:;" onclick="delChannel(this,'<%=sub1.ChannelID %>')">删除</a>
            </span>
            <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;┠ <%=sub1.ChannelName%></span>
            </li>
         
        <% 
            var sub2List = _ChannelService.GetChannelListByReid(sub1.ChannelID);
            foreach(var sub2 in sub2List){
        %>
            <li>
            <span class="ops">
                <a href="javascript:;" onclick="addChannel(<%=sub2.ChannelID%>);">增加子类</a> |
                <a href="javascript:;" onclick="editChannel('<%=sub2.ChannelName %>','<%=sub2.ChannelID%>')">编辑</a> |
                <a href="javascript:;" onclick="delChannel(this,'<%=sub2.ChannelID %>')">删除</a>
            </span>
            <span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;┠  <%=sub2.ChannelName%></span>
            </li>
        <% }%>

     <%} %>

<% } %>
 </ul>
    
   
</form>
    <script type="text/javascript">

        function editChannel(name,id) {
            window.parent.addTab(name, "channel_edit.aspx?channelID=" + id, "");
        }
        
        function addChannel(channelid) {
            window.parent.addTab("增加栏目", "channel_edit.aspx?reid=" + channelid);
        }

        function delChannel(obj,channelid) {
            if (!confirm("确定要删除吗？")) {
                return false;
            }
            var $this = $(obj);
            $.post("/Ashx/channel_manage.ashx", { "ACTION": "del", "channelid": channelid }, function (data) {
                if (data == "True") {
                    $this.parent().parent().remove();
                    alert("删除成功");
                    return false;
                }
                alert("删除失败");
            });
        }
       
    </script>
</body>
</html>
