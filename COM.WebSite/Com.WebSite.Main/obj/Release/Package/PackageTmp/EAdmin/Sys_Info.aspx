<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Info.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Sys_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>基本参数设置</title>
 <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
<link href="Easyui/themes/icon.css" rel="stylesheet" />
<script src="../Script/jQuery1.7.2.js"></script>
<script src="Script/jquery.easyui.min.js"></script>
<link href="Css/style.css" rel="stylesheet" />
    <style type="text/css">
        table tr td {
        text-align:center;
        }
        .ml {
        text-align:left;}
        .inp {
        width:350px;}
    </style>
</head>
<body>

<form id="form1" runat="server" >
     <div class="hbutton">
        <a id="btn_add" href="#" class="easyui-linkbutton" onclick="$('#form1').submit();">保 存</a>&nbsp;&nbsp;
        <a id="btn_cancel" href="#" class="easyui-linkbutton" onclick="window.parent.closeSelectedTab()"> 关 闭 </a>
    </div>
    <div id="center_tabs" class="easyui-tabs">   
    <div title="站点设置" style="padding:10px;">
         <table class="tt" style="border:none;">
             <tr class="header">
                 <td style="width:15%">参数说明</td>
                 <td>参数值</td>
                 <td>变量名</td>
             </tr>
              <tr>
                 <td>站点根网址：</td>
                 <td class="ml"><input type="text" class="inp" name="cfg_basehost" value="<%=config["cfg_basehost"].Value %>"/></td>
                 <td>cfg_basehost</td>
             </tr>
              <tr>
                 <td>网页主页链接：</td>
                 <td class="ml"><input type="text" class="inp" name="cfg_indexurl" value="<%=config["cfg_indexurl"].Value %>"/></td>
                 <td>cfg_indexurl</td>
             </tr>
              <tr>
                 <td>网站名称：</td>
                 <td class="ml"><input type="text" class="inp" name="cfg_webname" value="<%=config["cfg_webname"].Value %>"/></td>
                 <td>cfg_webname</td>
             </tr>
              <tr>
                 <td>文档HTML默认保存路径： </td>
                 <td class="ml"><input type="text" class="inp"  name="cfg_arcdir" value="<%=config["cfg_arcdir"].Value %>"/></td>
                 <td>cfg_arcdir</td>
             </tr>
              <tr>
                 <td>图片/上传文件默认路径：</td>
                 <td class="ml"><input type="text" class="inp"  name="cfg_medias_dir" value="<%=config["cfg_medias_dir"].Value %>"/></td>
                 <td>cfg_medias_dir</td>
             </tr>
              <tr>
                 <td>缩略图默认宽度：</td>
                 <td class="ml"><input type="text" class="inp"  name="cfg_ddimg_width" value="<%=config["cfg_ddimg_width"].Value %>"/></td>
                 <td>cfg_medias_dir</td>
             </tr>
              <tr>
                 <td>缩略图默认高度：</td>
                 <td class="ml"><input type="text" class="inp"  name="cfg_ddimg_height" value="<%=config["cfg_ddimg_height"].Value %>"/></td>
                 <td>cfg_medias_dir</td>
             </tr>
              <tr>
                 <td>网站版权信息：</td>
                 <td class="ml"><textarea name="cfg_powerby" cols="80" rows="2" ><%=config["cfg_powerby"].Value %></textarea></td>
                 <td>cfg_powerby</td>
             </tr>
              <tr>
                 <td>图片/站点默认关键字：</td>
                 <td class="ml"><input type="text" class="inp" name="cfg_keywords" value="<%=config["cfg_keywords"].Value %>"/></td>
                 <td>cfg_keywords</td>
              </tr>
             <tr>
                 <td>站点描述：</td>
                 <td class="ml"><textarea name="cfg_description" cols="80" rows="2"><%=config["cfg_description"].Value %></textarea></td>
                 <td>cfg_description</td>
              </tr>
             <tr>
                 <td>网站备案号：</td>
                 <td class="ml"><input type="text" class="inp"  name="cfg_beian" value="<%=config["cfg_beian"].Value %>"/></td>
                 <td>cfg_beian</td>
              </tr>
         </table>
    </div>

     <div title="其它选项" style="padding:10px;">
        <table class="tt" style="border:none;">
        <tr class="header">
            <td style="width:15%">参数说明</td>
            <td>参数值</td>
            <td>变量名</td>
        </tr>
            <tr>
            <td>公司地址：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_address" value="<%=config["cfg_address"].Value %>"/></td>
            <td>cfg_address</td>
        </tr>
             <tr>
            <td>邮 编：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_zipcode" value="<%=config["cfg_zipcode"].Value %>"/></td>
            <td>cfg_zipcode</td>
        </tr>

        <tr>
            <td>联系人：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_linkman" value="<%=config["cfg_linkman"].Value %>"/></td>
            <td>cfg_linkman</td>
        </tr>
        <tr>
            <td>邮 箱：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_email" value="<%=config["cfg_email"].Value %>"/></td>
            <td>cfg_email</td>
        </tr>
        <tr>
            <td>Q Q：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_qq" value="<%=config["cfg_qq"].Value %>"/></td>
            <td>cfg_qq</td>
        </tr>
         <tr>
            <td>联系电话：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_telphone" value="<%=config["cfg_telphone"].Value %>"/></td>
            <td>cfg_telphone</td>
        </tr>
          <tr>
            <td>传 真：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_fax" value="<%=config["cfg_fax"].Value %>"/></td>
            <td>cfg_fax</td>
        </tr>
             <tr>
            <td>手机号：</td>
            <td class="ml"><input type="text" class="inp" name="cfg_mobile" value="<%=config["cfg_mobile"].Value %>"/></td>
            <td>cfg_mobile</td>
        </tr>
        </table>
     </div>
    </div>
</form>
</body>
</html>
