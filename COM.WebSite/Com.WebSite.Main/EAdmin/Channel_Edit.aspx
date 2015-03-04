<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Channel_Edit.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Channel_Edit" ValidateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
     <script type="text/javascript" src="CkEditor/ckeditor.js"></script>
    <script  type="text/javascript" src="CkFinder/ckfinder.js"></script>
   <link href="Css/style.css" rel="stylesheet" />
    <style type="text/css">
        #folder li {
         list-style:none;
         padding:2px 5px;
         font-size:14px;
        }
        #folder li:hover {
        background:yellow;}
    </style>
</head>
<body>

<form id="form1" method="post" runat="server">
  
<div id="center_tabs" class="easyui-tabs">

     <p style="text-align:right;padding:0px;margin:0px;margin-bottom:5px;">
     <input type="hidden" name="ChannelID" value="<%=channelId %>" />
     <input type="hidden" name="Reid" value="<%=!string.IsNullOrWhiteSpace(GetQueryString("reid")) && GetQueryString("reid")!="0"?GetQueryString("reid"): model.Reid.ToString() %>" />
     <a id="btn_save" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'"> 保 存 </a>&nbsp;&nbsp;
     <a id="btn_close" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'"> 关 闭 </a>
    </p>  

     <div title="常规选项" style="padding:8px;">
            <table class="ftable">
            <tr>
            <td style="width:10%">是否隐藏栏目：</td>
            <td>
                <input type="radio" name="IsHidden" value="0"/> 隐藏
                <input type="radio" name="IsHidden" value="1"/> 显示
            </td>
            </tr>

            <tr>
                <td>栏目名称：</td>
                <td><input type="text" name="ChannelName" value="<%=model.ChannelName %>"/></td>
            </tr>

             <tr>
                <td>内容模型：</td>
                <td>
                    <select name="ModuleID" runat="server" id="ModuleID">
                        <option value='1' selected="selected">普通文章|article</option>
                        <option value='-8'>分类信息|infos</option>
                        <option value='2'>图片集|image</option>
                        <option value='3'>软件|soft</option>
                        <option value='6'>商品|shop</option>
                    </select>
                </td>
            </tr>

            <tr>
                <td>栏目排序：</td>
                <td>
                    <input type="text" name="SortRank"  size="5" value="<%=model.SortRank %>"/>（由低 -> 高）
                </td>
            </tr>

            <tr>
                <td>文件保存目录：</td>
                <td>
                    <input type="text" name="FileDir"  size="30" value="<%=model.FileDir %>"/>
                </td>
            </tr>
          <tr>
                <td>封面模板：</td>
                <td>
                    <input type="text" name="IndexPage"  size="30"  value="<%=model.IndexPage %>"/> <input type="button" value="选择" class="selfile"/>
                </td>
            </tr>

                <tr>
                <td>列表模板：</td>
                <td>
                    <input type="text" name="ListPage"   size="30" value="<%=model.ListPage %>"/> <input type="button" value="选择" class="selfile"/>
                </td>
            </tr>
                <tr>
                <td>文章模板：</td>
                <td>
                    <input type="text" name="DetailPage"  size="30" value="<%=model.DetailPage %>"/> <input type="button" value="选择" class="selfile"/>
                </td>
            </tr>
           <tr>
            <td>SEO标题：</td>
            <td><input type="text" name="SEOTitle" size="35" value="<%=model.SEOTitle %>" /></td>
            </tr>
                 <tr>
                <td>栏目关键字：</td>
                <td><textarea name="Keywords" cols="80" rows="3"><%=model.Keywords %></textarea></td>
            </tr>

              <tr>
                <td>栏目描述：</td>
                <td><textarea name="Description" cols="100" rows="5"><%=model.Description %></textarea></td>
            </tr>
        </table>    
        </div>

     <div title="栏目内容" style="padding:8px;">
         <textarea name="Content" id="Content" cols="80" rows="5"><%=model.Content %></textarea>
         <script type="text/javascript"> var editor = CKEDITOR.replace('Content');</script>
      </div>

</div>
</form>
<div id="win" style="overflow-y:auto;"></div>  

<script type="text/javascript">

        var $currentTr = null;
        $(function () {

            $("#btn_save").click(function () {
                if ($.trim($("input[name='ChannelName']").val()) == "") {
                    alert("栏目名称不能为空！");
                    return false;
                }
                $("#form1").submit();
            });

            $("#btn_close").click(function () {
                window.parent.closeSelectedTab();
            });

            $(".selfile").click(function () {
                $currentTr = $(this).parent().parent();
                $.post("/Ashx/FolderManage.ashx", { "action": "LoadFile" }, function (data) {
                    var json = $.parseJSON(data);
                    var htm = "<ul id='folder'>";
                    $.each(json, function (i) {
                        htm += "<li onclick=\"writePath('" + json[i].FilePath + "');\">" + json[i].FileName + "</li>";
                    });
                    htm += "</ul>";
                    $('#win').window({
                        title:"文件选择",
                        width: 450,
                        height: 260,
                        maximizable: false,
                        resizable: false,
                        minimizable: false,
                        collapsible: false,
                        modal: true
                    });
                    $('#win').html(htm);
                });

            });

            $("#ModuleID option[value='<%=model.ModuleID%>']").attr("selected", true);
            $("input[name='IsHidden'][value='<%=model.IsHidden?"1":"0"%>']").attr("checked", true);

        });

        function writePath(path) {
            $currentTr.find("input[type='text']").val(path);
            $('#win').window('close');
        }

 </script>



</body>
</html>
