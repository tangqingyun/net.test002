<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLink_Edit.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.FriendLink_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加友情链接</title>
    <link href="Css/style.css" rel="stylesheet" />
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    
</head>
<body>
      
    <form id="form1" enctype="multipart/form-data" runat="server">
     <div class="hbutton">
         <input type="hidden" name="ID" value="<%=model.ID %>" />
        <a id="btn_add" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'" onclick="save();">保 存</a>&nbsp;&nbsp;

        <a id="btn_cancel" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'"  onclick="window.parent.closeSelectedTab();"> 关 闭 </a>
    </div>
        <div id="center_tabs" class="easyui-tabs">
            <div title="常规信息" style="padding:10px;">
                <table class="atable">
           <tr>
            <td>网址：</td>
            <td ><input name="url" type="text" id="url" value="<%=!string.IsNullOrWhiteSpace(model.Url)?model.Url:"http://" %>" size="30" class='pubinputs' /></td>
          </tr>
          <tr>
            <td>网站名称：</td>
            <td><input name="webname" type="text" id="webname" size="30" class='pubinputs' value="<%=model.WebName %>"/></td>
          </tr>
          <tr>
            <td>排列位置：</td>
            <td >
            <input name="sortrank" type="text" id="sortrank" value="<%=model.SortRank %>" size="10" class='pubinputs' style='width:60px' />
            (由小到大排列)
            </td>
          </tr>
          <tr>
            <td >网站Logo：</td>
            <td><input name="logo" type="text" id="logo" size="30" class='pubinputs' value="<%=model.Logo %>"/> (88*31 gif或jpg)</td>
          </tr>
          <tr>
            <td >上传Logo：</td>
            <td>
        	    <input name="logoimg" type="file" id="logoimg" size="30" class='pubinputs' />
            </td>
          </tr>
          <tr>
            <td>网站简况：</td>
            <td><textarea name="description" cols="70" rows="4" id="msg"><%=model.Description %></textarea></td>
          </tr>
          <tr>
            <td >站长Email：</td>
            <td>
        	    <input name="email" type="text" id="email" size="30" class='pubinputs' value="<%=model.Email %>"/>
            </td>
          </tr>
          <tr>
            <td >网站类型：</td>
            <td>
            <select name="typeid" id="typeid">
        	    <option value='1'>综合网站</option>
	            <option value='2'>娱乐类</option>
	            <option value='3'>教育类</option>
	            <option value='4'>计算机类</option>
	            <option value='5'>电子商务</option>
	            <option value='6'>网上信息</option>
	            <option value='7'>论坛类</option>
	            <option value='8'>其它类型</option>
            </select>
            </td>
          </tr>
          <tr>
            <td >链接位置：</td>
            <td>
            <input type='radio' name='ischeck' value="1" checked='checked' /> 内页
            <input type='radio' name='ischeck' value="2"/> 首页
            </td>
          </tr>
        </table>

     </div>
</div>
  
    </form>
    <script type="text/javascript">
        $(function () {
            $("#typeid option[value='<%=model.TypeID%>']").attr("selected", true);
            $("input[name='ischeck'][value='<%=model.Ischeck%>']").attr("checked", true);
        });
        function save() {
            if ($.trim($("input[name='webname']").val()) == "") {
                alert("网站名称不能为空！"); return false;
            }
            
            $('#form1').submit();
        }

    </script>
</body>
</html>
