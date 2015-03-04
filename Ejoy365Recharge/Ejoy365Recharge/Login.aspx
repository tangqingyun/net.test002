<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ejoy365Recharge.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $("#LoginForm").submit();
        });

    </script>
</head>
<body>
    <form  method="post" action="http://secure.ejoy365.com/Customer/Login.aspx?ReturnUrl=http%3a%2f%2fsecure.ejoy365.com%2fRecharge%2fRechargeStep1.aspx" id="LoginForm">
     <input type="hidden" id="action" name="action" value="Get" />
     <table>
         <tr>
             <td>您的用户名：</td>
             <td><input  type="text" name="name" value="qingyun"/></td>
         </tr>
            <tr>
             <td>您的密码：</td>
             <td><input  type="text" name="pwd" value="123456"/></td>
         </tr>
          <%--  <tr>
             <td colspan="2"><input  type="submit" name="" value="登陆"/></td>
         </tr>--%>
     </table>
    </form>
</body>
</html>
