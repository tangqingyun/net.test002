<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arcticle_Manage.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Arcticle_Manage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>文章管理</title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <link href="Css/style.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    <style type="text/css">
        #tbody tr:hover{
        background:#fcfdee;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
      
<div>
    <table style="padding:10px 0px;width:100%;">
        <tr>
            <td>
                  <span style="float:right;">
                     <a id="btn_save" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'"> 查 询 </a>&nbsp;&nbsp;
                 <a id="btn_reset" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-reload'"> 重 置 </a>
                </span>

                <span> 所属栏目：
                <select name="ChannelID" runat="server" id="ChannelID">
                </select></span>
              
                <span>标题：
                    <input type="text" name="Title" value="" size="30"/>
                </span>
              
            </td>
        </tr>
    </table>
</div>
<table id="tt" style="width:100%;height:auto; border="0" >
    <tr class="header">
        <td>选择</td>
        <td>ID</td>
        <td>文章标题</td>
        <td>所属频道</td>
        <td>来源</td>
        <td>属性</td>
        <td>浏览数</td>
        <td>发布人</td>
        <td>发布时间</td>
        <td>操作</td>
    </tr>   
    <tbody id="tbody">
        <asp:Repeater ID="rpData" runat="server">
            <ItemTemplate>
                 <tr>
                    <td><input type="checkbox" name="" value="<%#Eval("ArcticleID") %>" /></td>
                    <td><%#Eval("ArcticleID") %></td>
                    <td><span class="title"><%#Eval("Title") %></span>
                    <%#!string.IsNullOrWhiteSpace(Eval("LitPic").ToString())?" <span style='color:red;'>[图片]</span>":string.Empty %></td>
                    <td><%#Eval("ChannelName") %></td>
                    <td><%#Eval("Source") %></td>
                    <td>属性</td>
                    <td><%#Eval("Click") %></td>
                    <td>发布人</td>
                    <td><%#Eval("CreateTime","{0:yyyy-MM-dd HH:mm}") %></td>
                    <td class="opv">
                        <a href="javascript:void(0);" title="编辑" class="edit"><img src="Easyui/themes/icons/pencil.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" title="删除" class="del"><img src="Easyui/themes/icons/cancel.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" title="浏览" onclick="window.open('/newsdetail.aspx?aid=<%#Eval("ArcticleID") %>')"><img src="Easyui/themes/icons/part-list.gif" /></a>
                    </td>
                </tr>   
             </ItemTemplate>
        </asp:Repeater>
    </tbody>  
    
     <tr class="pager">
     <td colspan="10">
        <webdiyer:AspNetPager ID="AspNetPager"  runat="server" PageSize="14" FirstPageText="第一页"
                    LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" OnPageChanged="AspNetPager_PageChanged">
        </webdiyer:AspNetPager>
     </td>
     </tr>

    
</table>
</form>
 
    <script type="text/javascript">

        $(function () {

            $("#btn_save").click(function () {
                $("#form1").submit();
            });

            $(".edit").click(function () {
                var tr=$(this).parent().parent();
                var aid = tr.find("td:eq(1)").text();
                var title = tr.find("td:eq(2)").find(".title").text();
                window.parent.addTab($.trim(title), "arcticle_edit.aspx?aid=" + $.trim(aid), "");
            });

            $(".del").click(function () {
                if (!confirm("确定要删除吗？")) {
                    return false;
                }
                var $this = $(this);
                var aid = $(this).parent().parent().find("td:eq(1)").text();
                $.post("/Ashx/arcticle_manage.ashx", { "ACTION": "del", "AId": $.trim(aid) }, function (data) {
                    if (data == "True") {
                        $this.parent().parent().remove();
                        alert("删除成功");
                        return false;
                    }
                    alert("删除失败");
                });
            });

        });

    </script>
</body>
</html>
