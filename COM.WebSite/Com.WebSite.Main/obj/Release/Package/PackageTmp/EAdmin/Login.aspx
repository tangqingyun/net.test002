<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理后台登陆</title>
    <script src="../Script/jQuery1.7.2.js"></script>
</head>
<body>


    <%
        //Com.WebSite.Main.RazorEngine.HtmlEngine.CreateArticelHtml(100);
    %>
    
    <form id="form1" runat="server">
        <div>
         账号：<input type="text" name="name" /><br />
         密码：<input type="text" name="pwd" /><br />
         验证码：<input type="text" name="rndCode" /><img src="/Ashx/ValidateCode.ashx?rnd=<%=new DateTime().ToString("yyyyMMddHHmmss") %>" /><br />
         <input type="button" value="提交" id="btnSubmit"/>
        </div>
    </form>

    <script type="text/javascript">

        $(function () {

            $("#btnSubmit").click(function () {
                var name = $.trim($("input[name='name']").val());
                var pwd = $.trim($("input[name='pwd']").val());
                var rndCode = $.trim($("input[name='rndCode']").val());
                $.post("Login.aspx", { "action": "LOGIN", "name": name, "pwd": pwd, "rndCode": rndCode }, function (result) {
                    switch (result) {
                        case "-1":
                            alert("验证码不正确");
                            break;
                        case "0":
                            alert("用户名不存在");
                            break;
                        default:
                            location.href = "Default.aspx";
                    }
                    
                });
            });
        });

    </script>
</body>
</html>
