<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Source_Main.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Source_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>网站文件管理</title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    <link href="Css/style.css" rel="stylesheet" />
</head>
<body>
 <form id="form1" runat="server">
     <div id="center_tabs" class="easyui-tabs">   
          <div title="文件管理" style="padding:10px;">
              <table id="tt" border="0" >
            <tr class="header">
                <td>文件名</td>
                <td>文件描述</td>
                <td>修改时间</td>
                <td>操作</td>
            </tr>   
          <tbody>
              <asp:Repeater ID="repList" runat="server">
                  <ItemTemplate>
                        <tr  class="opv">
                            <td><%#Eval("Name") %></td>
                            <td></td>
                            <td><%#Eval("LastWriteTime","{0:yyyy-MM-dd HH:mm:ss}") %></td>
                            <td>
                            <a href="javascript:void(0);" title="编辑" class="edit" onclick="window.parent.addTab('编辑-<%#Eval("Name") %>','source.aspx')"><img src="Easyui/themes/icons/pencil.png"/></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" title="删除" class="del"><img src="Easyui/themes/icons/cancel.png" /></a>&nbsp;&nbsp;
                            </td>
                         </tr>
                  </ItemTemplate>
              </asp:Repeater>
           
          </tbody>
</table>
</div>
</div>
  
    </form>
</body>
</html>
