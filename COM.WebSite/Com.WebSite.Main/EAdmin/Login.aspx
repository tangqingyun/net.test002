<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理后台登陆</title>
    <script src="../Script/jQuery1.7.2.js" type="text/javascript"></script>
    <style type="text/css">
        body {
        background:#f7f7f7;
        }
        #login {
        border:5px solid #3c86c5; margin:0 auto;margin-top:15%;
        }
        .text {
         text-align:right; font-weight:bold; font-size:14px;
        }
        img {
        margin:0px;padding:0px;}
        #refreshCode {
            position:absolute;
            /*top:1px;*/
        }
        input[type='text'] {
        height:22px;line-height:22px;
        }
        #btnSubmit {
        width:80px; height:28px; font-size:14px;}
    </style>
</head>
<body>


    <%
        //Com.WebSite.Main.RazorEngine.HtmlEngine.CreateArticelHtml(100);
    %>
    
    <form id="form1" runat="server">
        <table id="login">
            <tr>
                <td colspan="2" style="width:558px;height:48px;"><img src="Images/login-top.jpg" /></td>
            </tr>
            <tr>
                <td class="text">账号：</td>
                <td> <input type="text" name="name" /></td>
            </tr>
         <tr>
             <td class="text">密码：</td>
             <td><input type="text" name="pwd" /></td>
         </tr>

            <tr>
                <td class="text"> 验证码：</td>
                <td valign="bottom" style="position:relative;">
                    <input type="text" name="rndCode" size="8"/>
                    <img src="/Ashx/ValidateCode.ashx?rnd=<%=new DateTime().ToString("yyyyMMddHHmmss") %>" alt="验证码" id="refreshCode"/></td>
            </tr>
            <tr>
                <td></td>
                <td style="padding-top:5px;padding-bottom:10px;"><input type="button" value=" 登 录 " id="btnSubmit"/></td>
            </tr>
        
        </table>
    </form>
    <script src="../Script/web.config.js"></script>
    <script src="../Script/web.string.js"></script>
    <script type="text/javascript">

        $(function () {

            $("#btnSubmit").click(function () {
                var name = $String.Trim($("input[name='name']").val());
                var pwd = $String.Trim($("input[name='pwd']").val());
                var rndCode = $String.Trim($("input[name='rndCode']").val());
                if (name == "") {
                    alert("账号不能为空"); return false;
                } else if (pwd == "") {
                    alert("密码不能为空"); return false;
                } else if (rndCode == "") {
                    alert("验证码不能为空"); return false;
                }

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

            $("#refreshCode").click(function () {
                $(this).attr("src", "/Ashx/ValidateCode.ashx?rnd="+new Date());
            });

        });

    </script>
</body>
</html>
