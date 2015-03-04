
usingNamespace("Web.Utils")["String"] = {
    IsNullOrEmpty: function (v) {
        return !(typeof (v) === "string" && v.length != 0);
    },
    Trim: function (v) {
        return v.replace(/^\s+|\s+$/g, "")
    },
    TrimStart: function (v, c) {
        if ($String.IsNullOrEmpty(c)) {
            c = "\\s";
        };
        var re = new RegExp("^" + c + "*", "ig");
        return v.replace(re, "");
    },
    TrimEnd: function (v, c) {
        if ($String.IsNullOrEmpty(c)) {
            c = "\\s";
        };
        var re = new RegExp(c + "*$", "ig");
        return v.replace(re, "");
    },
    Camel: function (str) {
        return str.toLowerCase().replace(/\-([a-z])/g, function (m, c) { return "-" + c.toUpperCase() })
    },
    Repeat: function (str, times) {
        for (var i = 0, a = new Array(times) ; i < times; i++)
            a[i] = str;
        return a.join();
    },
    IsEqual: function (str1, str2) {
        if (str1 == str2)
            return true;
        else
            return false;
    },
    IsNotEqual: function (str1, str2) {
        if (str1 == str2)
            return false;
        else
            return true;
    },
    MaxLengthKeyUp: function (obj, len) {
        var value = $(obj).val();
        if (value.length > len) {
            $(obj).val(value.substring(0, len));
        }
    },
    MaxLengthKeyDown: function (obj, len) {
        if ($(obj).val().length > len) { return false; }
        return true;
    },
    IsTelePhone: function (telStr) {
        var telReg = /^\d{4}-\d{7}$|^\d{3}-\d{8}$|^\d{7}$|^\d{8}$/;
        return telReg.test(telStr);
    },
    IsMobile: function (phoneStr) {
        var phoneReg = /^\d{11}$|^\d{13}$/;
        return phoneReg.test(phoneStr);
    },
    IsEmail: function (emailStr) {
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        return filter.test(emailStr);
    },
    IsCard: function (cardReg) {
        var cardReg = /^\d{17}[\d|X|x]$|^\d{14}$/;
        return cardReg.test(cardStr);
    },
    OnlyEng: function () { //只能是英文
        if (!(event.keyCode >= 65 && event.keyCode <= 90))
            event.returnvalue = false;
    },
    IsDecimal: function (str) {//验证decimal类型
        return (/^(([1-9]\d*)|\d)(\.\d{1,5})?$/).test(str.toString());
    },
    ForDight: function (Dight, How) { //四舍五入 Dight要格式化的数字，How要保留的小数位数。
        Dight = Math.round(Dight * Math.pow(10, How)) / Math.pow(10, How);
        return Dight;
    },
    IsNumber: function (str) { //是否是数字
        var reg = /^\d+$/;
        return reg.test(str);
    },
    NewGuid: function () { //生成Guid
        var guid = "";
        for (var i = 1; i <= 32; i++) {
            var n = Math.floor(Math.random() * 16.0).toString(16);
            guid += n;
            if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                guid += "-";
        }
        return guid;
    }
};

var $String = Web.Utils.String;