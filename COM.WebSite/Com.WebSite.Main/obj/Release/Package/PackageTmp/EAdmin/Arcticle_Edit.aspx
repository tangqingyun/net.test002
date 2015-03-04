<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arcticle_Edit.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Arcticle_Edit" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=aid==0?"添加文章":model.Title %></title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="CkEditor/ckeditor.js"></script>
    <script type="text/javascript" src="CKFinder/ckfinder.js"></script>
    <script src="DatePicker/WdatePicker.js"></script>
    
    <link href="Css/style.css" rel="stylesheet" />
    <style type="text/css">
        table td {
        padding:4px 0px; border-bottom:1px dashed #bcbcbc;}
        .btext span {
        margin-right:15px;}
    </style>
</head>
<body>
    <form id="form1" enctype="multipart/form-data" runat="server" >
     <div id="center_tabs" class="easyui-tabs">
     <p style="text-align:right;padding:0px;margin:0px;margin-bottom:5px;">
     <input type="hidden" value="<%=aid %>" name="ArcticleID" />
     <input type="hidden" value="" name="ACTION" id="ACTION" runat="server"/>
     <a id="btn_save" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'"> 保 存 </a>&nbsp;&nbsp;
     <a id="btn_close" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" onclick="window.parent.closeSelectedTab()"> 关 闭 </a>
    </p>  

     <div title="常规信息" style="padding:10px;">
            <table>
            <tr>
                <td>文章标题：</td>
                <td><input type="text" name="Title" size="80" value="<%=model.Title %>"/></td>
            </tr>

             <tr>
                <td>文章主栏目：</td>
                <td>
                    <select name="ChannelID" runat="server" id="ChannelID">
                    </select>
                </td>
            </tr>

            <tr>
                <td>自定义属性：</td>
                <td>
                    <asp:Repeater ID="repFlag" runat="server">
                        <ItemTemplate>
                            <input class='flag' type='checkbox' name='Flag'  value='<%#Eval("Flag") %>'/><%#Eval("Remark") %>[<%#Eval("Flag") %>]
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </td>
            </tr>

            <tr>
                <td>文章来源：</td>
                <td>
                    <input type="text" name="Source"  value="<%=string.IsNullOrWhiteSpace(model.Source)?"本站":model.Source %>"/>&nbsp;&nbsp;&nbsp;&nbsp;
                    作　者：
                    <input type="text" name="Writer"  size="8" value="<%=model.Writer %>"/>
                </td>
            </tr>
          <tr>
                <td>TAG标签：</td>
                <td><input type="text" name="Tags"  value="<%=model.Tags %>"/></td>
            </tr>
                
            <tr>
                <td>缩略图：</td>
                <td>
                    <input type="hidden" name="hidLitPic" value="<%=model.LitPic %>" />
                    <input type="hidden" name="hidThumPic" value="<%=model.ThumPic %>" />
                    <% if (!string.IsNullOrWhiteSpace(model.ThumPic)) { %>
                    <p><img src="<%=model.ThumPic %>" id="thumpic"/><a href="javascript:;" onclick="delLitPic(this,'<%=model.ArcticleID %>')">删除</a></p>
                    <% } %>
                    <input type="file" name="ImgFile" size="40"/></td>
            </tr>

            <tr>
                <td>跳转网址：</td>
                <td><input type="text" name="RedireUrl" size="40" value="<%=model.RedireUrl %>"/></td>
            </tr>

             <tr>
                <td>关键字：</td>
                <td><input type="text" name="Keywords" size="60" value="<%=model.Keywords %>"/></td>
            </tr>

              <tr>
                <td>内容摘要：</td>
                <td><textarea name="Description" cols="80" rows="3"><%=model.Description %></textarea></td>
            </tr>

            <tr>
                 <td>浏览次数：</td>
                  <td class="btext">
                      <span>
                      <input type="text" name="Click" size="5" value="<%=model.Click %>"/>
                      </span>
                      <span>
                      发布时间：<input type="text" size="18"   class="Wdate" name="CreateTime" value="<%=model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss") %>" onfocus="WdatePicker({isShowClear:true,readOnly:true,dateFmt:'yyyy-MM-dd HH:mm:ss'})"/>
                       </span>
                      <span>
                      发布选项：
                      <input name="IsHtml" type="radio" class="np" value="1"  /> 生成HTML
                      <input type="radio" name="IsHtml" class="np" value="0" checked="checked"/> 仅动态浏览
                       </span>
                      <span>
                         
                      </span>
                  </td>
             </tr>
           <tr>
               <td>自定义文件名：</td>
               <td><input type="text" name="FileName" value="<%=model.FileName %>" /></td>
           </tr>
        </table>    
        </div>

     <div title="文章内容" style="padding:8px;">
         <table style="width:100%;">
               <tr>
                 <td>
                     <textarea name="Body" id="Body" cols="80" rows="5"><%=model.Body %></textarea>
                    <script type="text/javascript"> var editor = CKEDITOR.replace('Body');</script>
                 </td>
             </tr>
         </table>
        
      </div>

</div>

    </form>

     <script type="text/javascript">
         $(function () {

             $("#btn_save").click(function () {
                 $("#form1").submit();
             });

             var arr = "<%=model.Flag%>".split(",");
             for(var i=0;i<arr.length;i++){
                 $("input[name='Flag'][value='"+arr[i]+"']").attr("checked",true);
             }
             
             $("#ChannelID option[value='<%=model.ChannelID%>']").attr("selected", true);
         });

         function delLitPic(obj, aid) {
             if (!confirm("确定删除缩略图吗？")) {
                 return false;
             }
             var $this = $(obj);
             $.post("/Ashx/arcticle_manage.ashx", { "ACTION": "delLitPic", "AId": $.trim(aid) },
                 function (data) {
                 if (data == "True") {
                     alert("删除成功！");
                     $("input[name='hidLitPic'],input[name='hidThumPic']").val("");
                     $this.remove();
                     $this.prev().remove();
                     $("#thumpic").remove();
                     return false;
                 }
                 alert("删除失败！");
             });
         }
    </script>

</body>
</html>
