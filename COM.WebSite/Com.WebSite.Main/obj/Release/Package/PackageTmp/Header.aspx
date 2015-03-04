<%@ Import Namespace="Com.WebSite.Models" %>
<%@ Import Namespace="Com.WebSite.Services" %>


<div id="header">
    <div id="hd_top">
        <p id="logo">石家庄盈诺科技有限公司</p>
        <p id="rgo">
            <a href='#' onclick='SetHome(this,window.location,"非IE浏览器不支持此功能，请手动设置！");' style='cursor:pointer;' title='设为首页'  >设为首页</a> <span>|</span>
            <a href='#' onclick='addFavorite("非IE浏览器不支持此功能，请手动设置！");' style='cursor:pointer;' title='收藏本站'  >收藏本站</a>
        </p>
    </div>
    <div id="nav">
        <ul>
            <% 
                        IEnumerable<Entity_Channel> List=new ChannelService().GetChannelListByReid(0);
                        int len=List.Count();
                        if (len > 0) {
                            foreach(var itm in List){
                        %>
                        <li><a href="<%=itm.IndexPage %>"><%=itm.ChannelName %></a> </li>
                <% 
                       
                        } }%>
        </ul>

    </div>
</div>
<div class=clear></div>