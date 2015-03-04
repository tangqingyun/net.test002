<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardDelivery.aspx.cs" Inherits="UniCardWeb.CardDelivery" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <style type="text/css">
        body {
            font-size: 13px;
        }

        table {
            border-collapse: collapse;
            border: 0px;
        }

            table td {
                padding: 3px;
                border: 1px solid #ccc;
                font-size: 13px;
            }

        .head {
            background: #9ccdf1;
        }

        .group {
            margin-top: 10px;
        }

        dl {
            float: left;
            width: 50%;
            margin: 0px;
            padding: 0px;
            /*height:45px;*/
        }
        dl dt { float: left;
            padding:0px;margin:0px;}
        dl dd {margin:0px; float: left;
            text-align: left;padding:5px 0px;width:90%;
        }
       
        .atp {
            text-align: center;
        }
    


    </style>

</head>

<body>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="3">云购物卡信息确认</td>
        </tr>
        <tr>
            <td>卡号：<input type="text" /></td>
            <td>密码：<input type="text" /></td>
            <td>
                <input type="button" value="转IVR输入密码" />
                <input type="button" value="获取密码" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <input type="button" value="查询卡信息" />
                <input type="button" value="历史提货记录" /></td>
            <td>
                <select name="">
                    <option value="">北京</option>
                </select></td>
        </tr>
        <tr>
            <td colspan="3">
                <p>提货有效期：2014年12月31号 激活日期：2014年5月3号</p>
                <p>
                    历史提货清单：解决方案产品（剩余3/8件）
米油（剩余39/42件）
水果（剩余30/36件）
蔬菜（剩余52/60件）
                </p>
            </td>
        </tr>
    </table>

    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="group">
        <tr class="head">
            <td>解决方案产品</td>
        </tr>
        <tr>
            <td>

                <dl><dt><input type="checkbox" /></dt>
                    <dd>极草经典含片（0.25克/片×30片/瓶×1瓶/盒）</dd>
                </dl>

                <dl>
                  <dt><input type="checkbox" /></dt>
                    <dd>极草经典含片（0.25克/片×30片/瓶×1瓶/盒）</dd>
                </dl>

                <dl>
                    <dt><input type="checkbox" /></dt>
                    <dd>极草经典含片（0.25克/片×30片/瓶×1瓶/盒）</dd>
                </dl>

                <dl>                    
                       <dt><input type="checkbox" /></dt>
                    <dd>极草经典含片（0.25克/片×30片/瓶×1瓶/盒）</dd>
                </dl>
            </td>
        </tr>
    </table>

    <asp:Repeater ID="BindDelivery" runat="server" OnItemDataBound="BindDelivery_ItemDataBound">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="group">
                <tr class="head">
                    <td colspan="3"><%#Eval("Group.GroupName") %></td>
                </tr>
                <asp:Repeater runat="server" ID="rpquestionlist">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("GoodsName") %> </td>
                            <td>数量：-
                                <input type="text" size="2" value="<%#Eval("Count") %>" class="atp" />
                                +</td>
                            <td>剩余5件 </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <td colspan="3">备注：<br />
                    <textarea style="width: 90%;" rows="3"></textarea>
                </td>
                </tr>
            </table>

        </ItemTemplate>
    </asp:Repeater>

    <p style="text-align: center; width: 100%;">
        <input type="submit" value=" 提交 " style="width: 80px;" />
    </p>

 


    <script src="jquery-1.6.2.min.js"></script>
    <script type="text/javascript">


        $(function () {
            //$("dl").tooltip({
            //    width: 100,
            //    height:100,
            //    callback: function () {
            //        return "";
            //    },
            //    event: "hover"
            //});
        });

        (function ($) {
            $.fn.tooltip = function (options) {
                var defaults = {
                    id: "tooltip",
                    width: 300,
                    height: 300,
                    border: "1px solid #999",
                    background: "#eee",
                    padding: "5px",
                    event:"hover",
                    callback: function () {
                        return "";
                    }
                };
                options = $.extend(defaults, options);
                var obj = null;

                this.each(function () {
                    var _this = $(this);
                    _this.css({ "cursor": "pointer" });

                    switch (options.event) {
                        case "hover":
                                _this.hover(
                                        function (e) {
                                            tipbox(e);
                                        },
                                        function () {
                                            obj.remove();
                                        }
                                 );
                            break;
                        case "click":                          
                            _this.click(function (e) {                             
                                if (obj == null) {
                                    tipbox(e);
                                } else {
                                    obj.remove();
                                    obj = null;
                                }
                            });
                            break;
                        default:
                    }

                    
                });

                function tipbox(e){
                    var x = e.pageX + 5;
                    var y = e.pageY - 2;
                    var html = "<div id=\"" + options.id + "\"></div>";
                    $("body").append(html);
                    obj = $("#" + options.id + "");
                    obj.css({
                        "position": "absolute",
                        "left": x + "px",
                        "top": y + "px",
                        "width": options.width+"px",
                        "height": options.height+"px",
                        "border": options.border,
                        "background": options.background,
                        "padding": options.padding
                    });
                    obj.html(options.callback());
                }
               
            }

        })(jQuery);
    </script>
</body>
</html>

