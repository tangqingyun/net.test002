<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Manage.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Admin_Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理员列表</title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    <link href="Css/style.css" rel="stylesheet" />
</head>
<body>
     <div class="hbutton">
        <a id="btn_add" href="#" class="easyui-linkbutton" onclick="$('#win').window('open');">新增管理员</a>&nbsp;&nbsp;
        <a id="btn_cancel" href="#" class="easyui-linkbutton" onclick="window.parent.closeSelectedTab();"> 关 闭 </a>
    </div>

<form id="form1" runat="server">
     <table id="tt" border="0" >
            <tr class="header">
                <td>账号</td>
                <td>所属角色</td>
                <td>邮箱</td>
                <td>登录时间</td>
                <td>操作</td>
            </tr>   
          <tbody>
              <asp:Repeater ID="repData" runat="server">
                  <ItemTemplate>
                      <tr>
                            <td><%#Eval("Name") %></td>
                            <td><%#Eval("TypeName") %></td>
                            <td><%#Eval("Email") %></td>
                            <td><%#Eval("LastLoginTime") %></td>
                            <td class="opv">
                                <a href="javascript:void(0);" title="编辑" onclick="editAdmin(this,'<%#Eval("ID") %>')"><img src="Easyui/themes/icons/pencil.png" /></a>&nbsp;&nbsp;
                                <a href="javascript:void(0);" title="删除" onclick="delAdmin(this,'<%#Eval("ID") %>')"><img src="Easyui/themes/icons/cancel.png" /></a>
                            </td>
                      </tr>
                  </ItemTemplate>
              </asp:Repeater>
              
          </tbody>
        </table>
    </form>


<div id="win" class="easyui-dialog" style="padding:5px;width:400px;height:200px;" title="新增管理员" iconCls="icon-save" buttons="#dlg-buttons">
<form id="ff" action="admin_manage.aspx"  method="post">	
    <table>
        <tr>
            <td>角   色：</td>
            <td><select name="TypeID" id="TypeID" runat="server"></select></td>
        </tr>
        <tr>
            <td>账   号：</td>
            <td><input type="text" name="Name" id="Name"/></td>
        </tr>
         <tr>
            <td>密   码：</td>
            <td><input type="text" name="Pwd" id="Pwd"/></td>
        </tr>
         <tr>
            <td>邮   箱：</td>
            <td><input type="text" name="Email" id="Email"/></td>
        </tr>
        
    </table>
    <input type="hidden" id="adminId" name="ID" value="<%=Guid.Empty %>" />
 </form>
<div id="dlg-buttons">
		<a href="#" class="easyui-linkbutton" iconCls="icon-save" onclick="addAdmin();">Save</a>
		<a href="#" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#win').window('close')">Cancel</a>
	</div>
</div>
    <script src="Script/jquery.form.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#win').window('close');
        })

        function editAdmin(obj, id) {
            var $this = $(obj);
            var row = $this.parent().parent();
            var name = $.trim(row.find("td:eq(0)").text());
            var typeName = $.trim(row.find("td:eq(1)").text());
            var email = $.trim(row.find("td:eq(2)").text());
            $("#TypeID option").each(function () {
                if ($(this).text() == typeName)
                    $(this).attr("selected",true);
            });
            $("#Name").val(name);
            $("#Email").val(email);
            $("#adminId").val(id);
            $('#win').window('open');
        }

        function delAdmin(obj, id) {
            if (!confirm("确定要删除吗？")) {
                return false;
            }
            $.post("admin_manage.aspx", { "id": id, "action": "del" }, function (data) {
                if (data == "N") {
                    alert("删除失败！");
                    return false;
                }
                alert("删除成功！");
                $(obj).parent().parent().remove();
            });
        }

        function addAdmin() {
            $('#ff').form('submit',{
                url: "admin_manage.aspx",
                onSubmit: function(param){    
                    param.action = "edit";
                    if ($("#TypeID").val() == "0") {
                        alert("请选择角色"); return false;
                    } else if ($.trim($("#Name").val()) == "") {
                        alert("账号不能为空"); return false;
                    } else if ($.trim($("#Pwd").val()) == "") {
                        alert("密码不能为空"); return false;
                    }
                },
                success: function (data) {
                    if (data == "N") {
                        alert("新增管理员失败");
                    } else {
                        alert("新增成功");
                    }
                    location.reload();
                }
            });
           
        }

    </script>
</body>
</html>
