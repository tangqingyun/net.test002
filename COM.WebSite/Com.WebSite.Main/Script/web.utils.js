var $Converter = Web.Utils.Converter;
var $HttpUtility = Web.HttpUtility;
var $State = Web.State.Cookies;
var $Url = Web.Url;
var $QueryString = Web.QueryString;
var $Form = Web.Form;

usingNamespace("Web.Utils")["Converter"] = {
    ToFloat: function (v) {
        if (!v || (v.length == 0)) {
            return 0;
        };
        return parseFloat(v);
    },
    Demo: function (message) {
        alert(message);
    }
};

usingNamespace("Web")["HttpUtility"] = {
    UrlEncode: function (str) {
        return escape(str).replace(/\*/g, "%2A").replace(/\+/g, "%2B").replace(/-/g, "%2D").replace(/\./g, "%2E").replace(/\//g, "%2F").replace(/@/g, "%40").replace(/_/g, "%5F");
    },
    UrlDecode: function (str) {
        return unescape(str);
    }
};

usingNamespace("Web")["Url"] = {
    BuildCurrentUrl: function (relativePath) {
        return Environment.Url + "/" + $String.TrimStart(relativePath, '\/');
    },
    BuildUrl: function (relativePath, type) {
        var rootPath = "";
        if (type.toLowerCase() == "www") {
            rootPath = $WebsiteConfig.UrlPathMappings.WWWSite[0];
        } else if (type.toLowerCase() == "shopper") {
            rootPath = $WebsiteConfig.UrlPathMappings.ShopperSite[0];
        } else if (type.toLowerCase() == "secure") {
            rootPath = $WebsiteConfig.UrlPathMappings.SSLSite[0];
        }
        return rootPath + "/" + $String.TrimStart(relativePath, '\/');
    }
};

usingNamespace("Web")["QueryString"] = {
    Get: function (key) {
        key = key.toLowerCase();
        var qs = Web.QueryString.Parse();
        var value = qs[key];
        return (value != null) ? value : "";
    },
    Set: function (key, value) {
        key = key.toLowerCase();
        var qs = Web.QueryString.Parse();
        qs[key] = $HttpUtility.UrlEncode(value);
        return Web.QueryString.ToString(qs);
    },
    Parse: function (qs) {
        var params = {};

        if (qs == null) qs = location.search.substring(1, location.search.length);
        if (qs.length == 0) return params;

        qs = qs.replace(/\+/g, ' ');
        var args = qs.split('&');
        for (var i = 0; i < args.length; i++) {
            var pair = args[i].split('=');
            var name = pair[0].toLowerCase();

            var value = (pair.length == 2)
				? pair[1]
				: name;
            params[name] = value;
        }

        return params;
    },
    ToString: function (qs) {
        if (qs == null) qs = Web.QueryString.Parse();

        var val = "";
        for (var k in qs) {
            if (val == "") val = "?";
            val = val + k + "=" + qs[k] + "&";
        }
        val = val.substring(0, val.length - 1);
        return val;
    }
};

usingNamespace("Web")["Form"] = {
    reset: function (form) {
        var f = $("#" + form); f.reset();
    },
    submit: function (form) {
        var f = $("#" + form); f.submit();
    }
};

usingNamespace("Web")["State"] = {
    Cookies: {
        SaveWithCopyName: function (name, value, copyName) {
            var cv = "";
            if (typeof (value) == "string") {
                cv = escape(value).replace(/\+/g, "%2b");
            } else if (typeof (value) == "object") {
                var jsonv = Web.State.Cookies.ToJson(Web.State.Cookies.GetValue(name));
                if (jsonv == false) jsonv = {};
                for (var k in value) {
                    eval("jsonv." + k + "=\"" + value[k] + "\"");
                }
                for (var k in jsonv) {
                    cv += k + '=' + escape(jsonv[k]).replace(/\+/g, "%2b") + '&';
                }
                cv = cv.substring(0, cv.length - 1);
            }

            var expires, path, domain, secure;
            try {
                if (null != (c = $CookieConfig[copyName])) {
                    domain = $WebsiteConfig.Domain;
                    if (c.TopLevelDomain == false) { domain = ""; }
                    var ad = $Converter.ToFloat(c.Expires);
                    if (ad > 0) {
                        var d = new Date();
                        d.setTime(d.getTime() + ad * 1000);
                        expires = d;
                    };
                    path = c.Path;
                    secure = c.SecureOnly;
                }
            } catch (ex) { };

            var cok = name + "=" + cv +
			   ((expires) ? "; expires=" + expires.toGMTString() : "") +
			   ((path) ? "; path=" + path : "") +
				((domain) ? "; domain=" + domain : "") +
				((secure) ? "; secure" : "");

            document.cookie = cok;
        },
        Save: function (name, value) {
            Web.State.Cookies.SaveWithCopyName(name, value, name);
        },
        Remove: function (n, k) {

        },
        Clear: function (n) {
            var domain, path, secure;
            try {
                var c;
                if (null != (c = Web.Config.CookieConfig[n])) {
                    domain = $WebsiteConfig.Domain;
                    path = c.Path;
                    secure = c.SecureOnly;
                };
            } catch (ex) { };

            document.cookie = n + "=" +
            ((path) ? ";path=" + path : "") +
            ((domain) ? ";domain=" + domain : "") +
            ";expires=Thu, 01-Jan-1900 00:00:01 GMT";
        },
        GetValue: function (n, k) {
            var reg = new RegExp("(^| )" + n + "=([^;]*)(;|$)");
            var arr = document.cookie.match(reg);
            if (arguments.length == 2) {
                if (arr != null) {
                    var kArr, kReg = new RegExp("(^| |&)" + k + "=([^&]*)(&|$)");
                    var c = arr[2];
                    var c = c ? c : document.cookie;
                    if (kArr = c.match(kReg)) {
                        return unescape(kArr[2].replace(/\+/g, "%20"));
                    } else {
                        return "";
                    }
                } else {
                    return "";
                }
            } else if (arguments.length == 1) {
                if (arr != null) {
                    return unescape(arr[2].replace(/\+/g, "%20"));
                } else {
                    return "";
                }
            }
        },
        ToJson: function (cv) {
            var cv = cv.replace(new RegExp("=", "gi"), ":'").replace(new RegExp("&", "gi"), "',").replace(new RegExp(";\\s", "gi"), "',");
            return eval("({" + cv + (cv.length > 0 ? "'" : "") + "})");
        }
    }
};



