<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppClient.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {          
            $("#ButtonSubmit").click(function () {
                $.post("Login.ashx", { "action": "Login", "uname": "zhang", "upwd": "123456" }, function (result) {
                    document.write(result);
                });
                return false;
            });
        });

    </script>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <p>用户名：<input type="text" name="uName" /></p>
     <p>密   码：<input type="text" name="uPwd" /></p>
    <p><input type="submit" id="ButtonSubmit" value="登 录"/></p>
    </div>
    </form>
  
</body>
</html>





