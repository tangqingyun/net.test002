window.usingNamespace = function (a) {
    var ro = window;
    if (!(typeof (a) === "string" && a.length != 0)) {
        return ro;
    }
    var co = ro;
    var nsp = a.split(".");
    for (var i = 0; i < nsp.length; i++) {
        var cp = nsp[i];
        if (!ro[cp]) {
            ro[cp] = {};
        };
        co = ro = ro[cp];
    };
    return co;
};

//document.write("<script language='javascript' src='b.js'></script>");

