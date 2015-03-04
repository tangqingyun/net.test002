<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhoneCall.aspx.cs" Inherits="TestPhoneCall.PhoneCall" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #phoneBox {  position:relative; background:black;
        width:350px;height:550px; margin:0 auto; padding:10px;padding-top:0px;}
        #phone {
        width:95%; 
        position:absolute;bottom:0px;
        }
            #phone td {
            text-align:center; font-size:40px;font-weight:bold;color:white;
            }

        .button td {
        background:url("Images/p_bt.png") no-repeat center center; height:75px; cursor:pointer;
        }
        .call span { display:inline-block;
         width:135px;height:50px; background:url("/Images/CallOut.png");font-size:20px; text-align:center; line-height:50px;
         cursor:pointer;
        }
        #textPhone {
        width:100%; height:80px; border:none; line-height:80px;font-size:35px;}
        #phonetop tr td img { 
        width:346px;}
    </style>
</head>
<body>
    <%--<img src="Images/phone4.jpg" alt="" width="350"/> --%>
    <div id="phoneBox">
        <table id="phonetop">
            <tr>
                <td align="center"><img src="Images/p_top.png" alt=""/></td>
            </tr>
        </table>

        <table id="phone" cellspacing="3">
            <tr>
                <td colspan="3"><input type="text" value="" name="textPhone" id="textPhone"/></td>
            </tr>
            <tr class="button">
                <td>1</td>
                <td>2</td>
                <td>3</td>
            </tr>
            <tr class="button">
                <td>4</td>
                <td>5</td>
                <td>6</td>
            </tr>
             <tr class="button">
                <td>7</td>
                <td>8</td>
                <td>9</td>
            </tr>
             <tr class="button">
                <td>*</td>
                <td>0</td>
                <td>#</td>
            </tr>

              <tr >
                <td colspan="3" class="call">
                    <span>呼 叫</span>
                    <span>挂 断</span>
                </td>
            </tr>
        </table>
    </div>

    <script src="jquery-1.6.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //MobilePhoneEnulator
        $(function () {
            var textPhone ="";
            $(".button td").click(function () {                
                var value = $(this).text();
                var textPhone = $("#textPhone").val() + value;
                $("#textPhone").val(textPhone);
                setCaretPosition(document.getElementById("textPhone"), textPhone.length);
            });
            
        });

        function setCaretPosition(ctrl, pos) {
            if (ctrl.setSelectionRange) {
                ctrl.focus();
                ctrl.setSelectionRange(pos, pos);
            }
            else if (ctrl.createTextRange) {
                var range = ctrl.createTextRange();
                range.collapse(true);
                range.moveEnd('character', pos);
                range.moveStart('character', pos);
                range.select();
            }
        }

    </script>
</body>
</html>
