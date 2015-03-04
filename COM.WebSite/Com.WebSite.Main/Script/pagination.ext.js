
$(function () {


});

function initPagination(pageIndex,pageSize,pageNum) {
    //加入分页的绑定   
    $("#pagination").pagination(pageNum, {
        callback: pageselectCallback,
        prev_text: '< 上一页', next_text: '下一页 >',
        items_per_page: pageSize,
        num_display_entries: 6,
        current_page: pageIndex,
        num_edge_entries: 0,
        link_to: "#"
    });
}
