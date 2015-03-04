<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role_Manage.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Role_Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员角色</title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    <link href="Css/style.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    
    <div class="hbutton">
        <a id="btn_add" href="#" class="easyui-linkbutton"> 新 增 </a>&nbsp;&nbsp;
        <a id="btn_cancel" href="#" class="easyui-linkbutton"  onclick="window.parent.closeSelectedTab();"> 关 闭 </a>
    </div>
    <table id="tt" border="0" >
            <tr class="header">
                <td>ID</td>
                <td>名称</td>
                <td>级别</td>
                <td>权限</td>
                <td>创建人</td>
                <td>操作</td>
            </tr>   
          <tbody>
              <asp:Repeater ID="repData" runat="server">
                  <ItemTemplate>
                      <tr>
                            <td><%#Eval("ID") %></td>
                            <td><%#Eval("TypeName") %></td>
                            <td><%#Eval("Rank") %></td>
                            <td><%#Eval("Purviews") %></td>
                            <td><%#Eval("Name") %></td>
                            <td class="opv">
                                <a href="javascript:void(0);" title="编辑" class="edit"><img src="Easyui/themes/icons/pencil.png" /></a>&nbsp;&nbsp;
                                <a href="javascript:void(0);" title="删除" class="del"><img src="Easyui/themes/icons/cancel.png" /></a>
                            </td>
                      </tr>
                  </ItemTemplate>
              </asp:Repeater>
              
          </tbody>
        </table>

<%--    <div id="win" class="easyui-window" title="新增角色" style="width:400px;height:200px"   
        data-options="iconCls:'icon-save',modal:true">   
       <table style="margin-top:10px;">
           <tr>
               <td>&nbsp;&nbsp;角色名称：</td>
               <td><input type="text" name="" /></td>
           </tr>
       </table>
   </div> --%>

</form>
    <script type="text/javascript">


        $(function () {

            //$(".edit").click(function () {
            //    var tr = $(this).parent().parent();
            //    var aid = tr.find("td:eq(0)").text();
            //    var title = tr.find("td:eq(1)").text();
            //    window.parent.addTab($.trim(title), "arcticle_edit.aspx?aid=" + $.trim(aid), "");
            //});

        })


    </script>
</body>
</html>
