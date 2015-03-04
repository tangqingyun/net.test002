
var sheight = window.screen.height;
var iframeHeight = sheight - 340;

function addTab(subtitle, url, icon) {
    var obj = $("#center_tabs");
    var isExites = obj.tabs('exists', subtitle);
    var iframe = "<iframe id='miframe' scrolling='auto' frameborder='0' src='" + url + "' style='padding:10px;width:98%;height:" + iframeHeight + "px'/>";
    if (isExites == false) {
        obj.tabs("add", {
            title: subtitle,
            content: iframe,
            closable: true,
            icon: icon,
            tools: [{
                //iconCls: 'icon-reload',
                closable: true,
                handler: function () {
                    //$("#miframe").attr("src", url);
                }
            }]
        });
    }
    else {
        obj.tabs('select', subtitle);
    }
}

function closeTab(subtitle) {
    $("#center_tabs").tabs('close', subtitle);
}

function closeSelectedTab() {
    var obj = $("#center_tabs");
    var tab = obj.tabs('getSelected');
    var index = obj.tabs('getTabIndex', tab);
    obj.tabs('close', index);
}

