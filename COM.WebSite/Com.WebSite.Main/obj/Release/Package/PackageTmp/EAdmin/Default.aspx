﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Com.WebSite.Main.EAdmin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="Easyui/themes/icon.css" rel="stylesheet" />
    <script src="../Script/jQuery1.7.2.js"></script>
    <script src="Script/jquery.easyui.min.js"></script>
    <link href="Css/style.css" rel="stylesheet" />

</head>
<body>
    <div id="cc" class="easyui-layout" style="width: 100%; height: 700px;">
        <div data-options="region:'north',title:'North Title',split:true" style="height: 100px;"></div>
        <div data-options="region:'west',title:'菜单管理',split:true" style="width: 200px;">
            <div id="west_pannel" class="easyui-accordion" data-options="border:false">
                <div title="栏目管理" data-options="iconCls:''">
                    <ul>
                        <li><a href="javascript:;" class="item" url="Channel_Manage.aspx">网站栏目管理</a></li>
                        <li><a href="javascript:;" class="item" url="Arcticle_Manage.aspx">所有文章列表</a></li>
                        <li><a href="javascript:;" class="item" url="Arcticle_Edit.aspx">发布文章</a></li>
                    </ul>
                </div>
              
                <div title="模板管理">
                    <ul>
                         <li><a href="javascript:;" class="item" url="Source_Main.aspx">网站文件管理</a></li>
                         <li><a href="javascript:;" class="item" url="Templets_main.aspx">默认模板管理</a></li>
                     </ul>
                </div>

                 <div title="网站设置">
                    <ul>
                         <li><a href="javascript:;" class="item" url="Sys_Info.aspx">基本参数设置</a></li>
                         <li><a href="javascript:;" class="item" url="Role_Manage.aspx">管理员角色</a></li>
                         <li><a href="javascript:;" class="item" url="Admin_Manage.aspx">管理员列表</a></li>
                         <li><a href="javascript:;" class="item" url="FriendLink_Manage.aspx">友情链接管理</a></li>
                     </ul>
                </div>


            </div>
        </div>

        <div data-options="region:'center',title:''" id="region_center">
            <div id="center_tabs" class="easyui-tabs">
                <%--<div title="Tab1" style="padding: 20px; display: none;">
                    tab1    
                </div>--%>
            </div>

    </div>

<script src="Script/jquery.easyui.ext.js"></script>
    <script type="text/javascript">
        

        $(function () {

            $(".item").click(function () {
                var subtitle = $(this).text();
                var url = $(this).attr("url");
                addTab(subtitle, url, "");
            });

            $('#west_pannel').accordion({
                animate: true,
                fit: false,//true,
                onUnselect: function () {

                }
            });

            $('#center_tabs').tabs({
                border: false,
                onSelect: function (title) {
                    //alert(title + ' is selected');
                },
                onAdd: function () {

                }
            });

        });

        

    </script>
</body>

</html>
