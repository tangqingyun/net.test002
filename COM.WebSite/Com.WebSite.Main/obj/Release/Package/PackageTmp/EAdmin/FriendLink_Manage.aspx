<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLink_Manage.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.FriendLink_Manage" %>
<%@ Import Namespace="Com.WebSite.Services" %>
<%@ Import Namespace="Com.WebSite.Models" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>友情链接管理</title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    <link href="Css/style.css" rel="stylesheet" />
</head>
<body>
      <div class="hbutton">
        <a id="btn_add" href="#" class="easyui-linkbutton" onclick="window.parent.addTab('添加友情链接', 'FriendLink_Edit.aspx');">添加友情链接</a>&nbsp;&nbsp;
        <a id="btn_cancel" href="#" class="easyui-linkbutton" onclick="window.parent.closeSelectedTab();"> 关 闭 </a>
    </div>
    <form id="form1" enctype="multipart/form-data" runat="server">
     <table id="tt" border="0" >
            <tr class="header">
                <td>网站名称</td>
                <td>网站Logo</td>
                <td>站长Email</td>
                <td>时间</td>
                <td>顺序</td>
                <td>管理</td>
            </tr>   
          <tbody>
            <% 
                var list=InstanceService.GetFriendLinkInstance().GetFriendLinkList(10);
                if(list!=null && list.Count()>0) {
                    foreach(var model in list) {
                %>
              <tr>
                <td><%=model.WebName %></td>
                <td><%=string.IsNullOrWhiteSpace(model.Logo)?"无图标":"<img src='"+model.Logo+"' width='88' height='30'/>" %></td>
                <td><%=model.Email %></td>
                <td><%=model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") %></td>
                <td><%=model.SortRank %></td>
                 <td class="opv">
                        <a href="javascript:void(0);" alt="编辑" title="编辑" onclick="edit(this,'<%=model.ID %>')"><img src="Easyui/themes/icons/pencil.png" /></a>&nbsp;&nbsp;
                        <a href="javascript:void(0);" alt="删除" title="删除" onclick="del(this,'<%=model.ID %>')"><img src="Easyui/themes/icons/cancel.png" /></a>
                    </td>
              </tr>
              <%  } }%>
          </tbody>
        </table>

    </form>
    <script type="text/javascript">

        function edit(obj,id) {
            var tr = $(obj).parent().parent();
            var title = tr.find("td:eq(0)").text();
            window.parent.addTab($.trim(title), "friendLink_edit.aspx?id=" + id, "");
        }

        function del(obj, id) {
            if (!confirm("确定要删除吗？")) {
                return false;
            }
            var $this = $(obj);
            $.post("friendLink_manage.aspx", { "action": "del", "id": id }, function (data) {
                if (data == "Y") {
                    alert("删除成功");
                    $this.parent().parent().remove();
                    return false;
                }
                alert("删除失败");
            });
        }
    </script>
</body>
</html>
