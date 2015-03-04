
//加油卡充值Step1
var BizRechargeStep1 = {
    Param: {
        cardNumberRegExp: function (areaValue) {
            if (areaValue) {
                areaValue = $.trim(BizRechargeStep1.UI.area().val());
                return new RegExp("^[0-9]{4}11" + areaValue + "[0-9]{11}$");
            } else {
                return new RegExp("^[0-9]{19}$");
            }
        },
        mobilePhoneRegExp: function () {
            return new RegExp("^1[0-9]{10}$");
        }
    },
    Action: {
        //初始表单
        initForm: function () {
            //地区
            BizRechargeStep1.UI.areas().val(resources_RechargeStep1.RechargeInfo.areaID);
            //充值金额
            BizRechargeStep1.UI.orderAmt().val(resources_RechargeStep1.RechargeInfo.orderAmt);
            //支付方式
            var payTypes = BizRechargeStep1.UI.payTypes();
            payTypes.filter("[value=" + resources_RechargeStep1.RechargeInfo.payTypeSysNo + "]").attr("checked", true);
            if (payTypes.filter(":checked").length == 0) {
                payTypes.filter(":first").attr("checked", true);
            }
        },

        //选择加油卡号
        selectCardNumber: function (obj) {
            var card = $(obj);
            var cardNumber = BizRechargeStep1.UI.cardNumber();
            cardNumber.val($.trim(card.text()));
            var cardValue = $.newegg.cookie.get("Cards", cardNumber.val());
            $('#txtCardPwd').val(cardValue);
        },

        //刷新验证码
        refreshValidateCode: function () {
            var img = BizRechargeStep1.UI.validatorImage();
            var url = img.attr("src");
            url = url.replace(new RegExp("&r=.+"), "") + "&r=" + Math.random();
            img.attr("src", url);
        },

        //下一步操作
        next: function () {
            //js验证数据
            var validSuccess = BizRechargeStep1.Validate.validateAllData();
            if (!validSuccess) { return; }

            // ajax验证，并处理
            $.ajax({
                url: $.newegg.buildCurrent("Ajax/Order/AjaxRecharge.aspx"),
                type: "post",
                dataType: "json",
                timeout: 20000,
                data: {
                    action: "checkPostStep2",
                    validateCode: $.trim(BizRechargeStep1.UI.validateCode().val()),
                    cardNumber: $.trim(BizRechargeStep1.UI.cardNumber().val()),
                    areaID: $.trim(BizRechargeStep1.UI.area().val()),
                    payTypeSysNo: $.trim(BizRechargeStep1.UI.payType().val())
                },
                beforeSend: function (XMLHttpRequest) {
                    BizRechargeStep1.UI.showProcessing(true);
                },
                success: function (data, textStatus) {
                    BizRechargeStep1.Action.nextAjaxProcess(data);
                },
                error: function () {
                    alert($Resource.BuildContent("SystemErrorInfo"));
                },
                complete: function (data, textStatus) {
                    //显示 处理中。。。
                    BizRechargeStep1.UI.showProcessing(false);
                }
            });
        },
        //下一步Ajax验证结果Process
        nextAjaxProcess: function (data) {
            if (data.Type == 2) {
                //error
                var showPosition = null;
                var showMessage = null;
                if (data.Description == "validCodeError") {
                    //验证码错误
                    showPosition = BizRechargeStep1.UI.changeValidateCode();
                    showMessage = resources_RechargeStep1.errorValidateCode;
                } else if (data.Description == "secondCardCanNotRecharge") {
                    //副卡不能充值
                    showPosition = BizRechargeStep1.UI.cardNumber();
                    showMessage = resources_RechargeStep1.secondCardCanNotRecharge;
                } else if (data.Description == "validCardError") {
                    //卡号验证错误
                    showPosition = BizRechargeStep1.UI.cardNumber();
                    showMessage = resources_RechargeStep1.errorCardNumberFailed;
                } else if (data.Description == "validFaild") {
                    //卡号验证失败
                    showPosition = BizRechargeStep1.UI.cardNumber();
                    showMessage = resources_RechargeStep1.validFaild;
                } else {
                    //其他验证失败或功能关闭
                    showMessage = data.Description;
                }

                if (showMessage == null) { return false; }
                if (showPosition != null) {
                    BizRechargeStep1.Message.showLabelError(showMessage, showPosition);
                    BizRechargeStep1.Anchor(showPosition.attr("id"));
                } else {
                    alert(showMessage);
                }

            } else {
                //Sucess
                //Post Form To RechargeStep2
                BizRechargeStep1.Action.postFormToStep2();
            }
        },
        //Post表单到第二步
        postFormToStep2: function () {
            var form = BizRechargeStep1.UI.createForm("recharge", $.newegg.buildSSL("recharge/RechargeStep2.aspx"), "POST");

            BizRechargeStep1.UI.appendFormParam(form, "cardNumber", $.trim(BizRechargeStep1.UI.cardNumber().val()));
            var area = BizRechargeStep1.UI.area();
            BizRechargeStep1.UI.appendFormParam(form, "areaID", $.trim(area.val()));
            BizRechargeStep1.UI.appendFormParam(form, "areaName", escape($.trim(area.text())));
            BizRechargeStep1.UI.appendFormParam(form, "mobilePhone", $.trim(BizRechargeStep1.UI.mobilePhone().val()));
            BizRechargeStep1.UI.appendFormParam(form, "orderAmt", $.trim(BizRechargeStep1.UI.orderAmt().val()));
            BizRechargeStep1.UI.appendFormParam(form, "payTypeSysNo", $.trim(BizRechargeStep1.UI.payType().val()));

            form.submit();
        }
    },

    Validate: {
        //验证全部数据(不进行Ajax验证)
        validateAllData: function () {
            var errorObj = null;

            //验证卡号
            if (!BizRechargeStep1.Validate.validateCardNumber()) {
                errorObj = BizRechargeStep1.UI.cardNumber();
            }
            //验证确认卡号
            if (!BizRechargeStep1.Validate.validateConfirmCardNumber()) {
                if (errorObj == null) { errorObj = BizRechargeStep1.UI.confirmCardNumber(); }
            }
            //验证手机
            if (!BizRechargeStep1.Validate.validateMobilePhone()) {
                if (errorObj == null) { errorObj = BizRechargeStep1.UI.mobilePhone(); }
            }
            //验证码
            if (!BizRechargeStep1.Validate.validateCode()) {
                if (errorObj == null) { errorObj = BizRechargeStep1.UI.validateCode(); }
            }

            //定位错误信息
            if (errorObj != null && errorObj.length > 0) {
                BizRechargeStep1.Anchor(errorObj.attr("id"));
            }

            return errorObj == null;
        },

        //验证加油卡号
        validateCardNumber: function () {
            var cardNumber = BizRechargeStep1.UI.cardNumber();

            //验证非空
            var isNotNull = BizRechargeStep1.Validate.validateInputNotNull(cardNumber);
            if (!isNotNull) { return false; }

            //本地验证格式 19位数字
            var cardReg = BizRechargeStep1.Param.cardNumberRegExp();
            if (!cardReg.test($.trim(cardNumber.val()))) {
                BizRechargeStep1.Message.showLabelError(resources_RechargeStep1.errorCardNumber, cardNumber);
                return false;
            }

            //clear error info
            BizRechargeStep1.Message.showLabelError(null, cardNumber);
            return true;
        },
        //确认卡号
        validateConfirmCardNumber: function () {
            var confirmCardNumber = BizRechargeStep1.UI.confirmCardNumber();

            //验证非空
            var isNotNull = BizRechargeStep1.Validate.validateInputNotNull(confirmCardNumber);
            if (!isNotNull) { return false; }

            //验证确认卡号
            var cardNumberValue = $.trim(BizRechargeStep1.UI.cardNumber().val());
            if ($.trim(confirmCardNumber.val()) != cardNumberValue) {
                BizRechargeStep1.Message.showLabelError(resources_RechargeStep1.errorCardNumberConfrimFailed, confirmCardNumber);
                return false;
            }

            return true;
        },

        //验证手机号码
        validateMobilePhone: function () {
            var mobilePhone = BizRechargeStep1.UI.mobilePhone();

            //验证非空
            var isNotNull = BizRechargeStep1.Validate.validateInputNotNull(mobilePhone);
            if (!isNotNull) { return false; }

            //验证格式
            var reg = BizRechargeStep1.Param.mobilePhoneRegExp();
            if (!reg.test($.trim(mobilePhone.val()))) {
                BizRechargeStep1.Message.showLabelError(resources_RechargeStep1.errorMobilePhone, mobilePhone);
                return false;
            }

            return true;
        },

        //验证码
        validateCode: function () {
            var validateCode = BizRechargeStep1.UI.validateCode();
            var showPosition = BizRechargeStep1.UI.changeValidateCode();

            //验证非空
            var isNotNull = BizRechargeStep1.Validate.validateInputNotNull(validateCode, showPosition);
            if (!isNotNull) { return false; }

            //clear error info
            BizRechargeStep1.Message.showLabelError(null, showPosition);
            return true;
        },

        //验证InputValue非空
        validateInputNotNull: function (input, showPosition) {
            var errorMessage = null;

            if ($.trim(input.val()).length == 0) {
                errorMessage = resources_RechargeStep1.errorNotNull;
            }

            if (showPosition == null) { showPosition = input; }
            BizRechargeStep1.Message.showLabelError(errorMessage, showPosition);

            return errorMessage == null || errorMessage.length == 0;
        }
    },
    UI: {
        rechargeStep1Content: function () { return $("#rechargeStep1Content"); },
        next: function () { return $("#next"); },
        areas: function () { return $("#area"); },
        area: function () { return $("#area option:selected"); },
        cardNumber: function () { return $("#cardNumber"); },
        confirmCardNumber: function () { return $("#confirmCardNumber"); },
        cardAutoFilled: function () { return $(".cardno .autoFilled"); },
        mobilePhone: function () { return $("#mobilePhone"); },
        orderAmt: function () { return $("#orderAmt"); },
        validateCode: function () { return $("#validateCode"); },
        validatorImage: function () { return $("#validatorImage"); },
        payTypes: function () { return $(":radio[name=payTypeSysNo]"); },
        payType: function () { return BizRechargeStep1.UI.payTypes().filter(":checked"); },
        changeValidateCode: function () { return $("#changeValidateCode"); },
        labelError: function (label) {
            var objID = "error" + label.attr("id");
            var obj = label.nextAll("#" + objID);
            if (obj.length == 0) {
                obj = $("<span id=" + objID + "></span>");
                label.after(obj);
            }
            return obj;
        },
        btnProcessing: function () {
            var obj = $("#processing");
            if (obj.length == 0) {
                obj = $('<span id="processing" class="cmnLoadB"><img align="absmiddle" src="' + resources_RechargeStep1.processingImage + '"/>' + resources_RechargeStep1.processingText + '</span>');
                BizRechargeStep1.UI.next().after(obj);
            }
            return obj;
        },

        createForm: function (id, action, method) {
            var form = $("<form id='" + id + "' action='" + action + "' method='" + method + "' ></form>");
            BizRechargeStep1.UI.rechargeStep1Content().append(form);

            return form;
        },
        appendFormParam: function (form, name, value) {
            form.append($("<input name='" + name + "' value='" + value + "' type='hidden' />"));
        },

        //显示|隐藏 处理中进度框
        showProcessing: function (isShow) {
            var btnProcessing = BizRechargeStep1.UI.btnProcessing();
            var next = BizRechargeStep1.UI.next();

            if (isShow) {
                btnProcessing.show();
                next.hide();
            } else {
                btnProcessing.hide();
                next.show();
            }
        },

        //显示|隐藏 卡号智能提示框
        showCardAutoFilled: function (isShow) {
            var autoFilled = BizRechargeStep1.UI.cardAutoFilled();
            var orderAmt = BizRechargeStep1.UI.orderAmt();

            if (isShow) {
                if ($.trim(autoFilled.html()).length > 0) {
                    //显示当前地区卡号，隐藏非当前地区卡号
                    var cardReg = BizRechargeStep1.Param.cardNumberRegExp();
                    var needShow = false;
                    autoFilled.find("a").each(function () {
                        var jThis = $(this);
                        if (cardReg.test($.trim(jThis.text()))) {
                            jThis.show();
                            needShow = true;
                        } else {
                            jThis.hide();
                        }
                    });
                    //有当前地区卡号则显示
                    if (needShow) {
                        autoFilled.show();
                        if (autoFilled.position().top + autoFilled.height() > orderAmt.position().top + orderAmt.height()) {
                            orderAmt.css("visibility", "hidden");
                        }
                    }
                }
            } else {
                autoFilled.hide();
                if (orderAmt.css("visibility") != "") {
                    orderAmt.css("visibility", "visible");
                }
            }
        }
    },

    Message: {
        showLabelError: function (message, label) {
            var error = BizRechargeStep1.UI.labelError(label);

            if (message != null && message.length > 0) {
                error.html(message);
                error.css("display", "inline-block");   //如果用show()，结果是style="display:inline", UI显示效果不正确
            } else {
                error.html("");
                error.hide();
            }
        }
    },

    Anchor: function (anchor) {
        var url = window.location.href;
        window.location.href = window.location.href.replace(new RegExp("#\\w+$", "i"), "") + "#" + anchor;
    }
};

usingNamespace("Biz.Recharge")["Step2"] = {
    accept: function () {
        var accepted = $("#accept").attr("checked");
        var next = $("#next");
        if (accepted) {
            next.removeClass("supplementdisable");
            next.bind("click", Biz.Recharge.Step2.next);
        } else {
            next.addClass("supplementdisable");
            next.unbind("click");
        }
    },
    back: function () {
        var frm = $("#rechargeConfirm");
        frm.attr("action", "RechargeStep1.aspx");
        frm.attr("method", "post");
        frm.submit();
    },
    next: function () {
        var frm = $("#rechargeConfirm");
        var areaID = $("#areaID").val();
        var areaName = $("#areaName").val();
        var cardNumber = $("#cardNumber").val();
        var mobilePhone = $("#mobilePhone").val();
        var orderAmt = $("#orderAmt").val();
        var payTypeSysNo = $("#payTypeSysNo").val();
        var userName = $("#userName").val();

        var jsonData = {
            "areaID": areaID,
            "areaName": areaName,
            "cardNumber": cardNumber,
            "mobilePhone": mobilePhone,
            "orderAmt": orderAmt,
            "payTypeSysNo": payTypeSysNo,
            "userName": userName
        };
        //send data
        $.ajax({
            url: $.newegg.buildSSL("Ajax/Recharge/AjaxCreateSGCardOrder.aspx"),
            dataType: "html",
            data: jsonData,
            type: "POST",
            cache: false,
            beforeSend: function (XMLHttpRequest) {
                var btnObj = $("#btns");
                var displayContent = $Resource.BuildContent("PopupInfo");
                btnObj.after('<p id="divLoading" class="process" style="width:150px;margin-right: 5px; margin-left: 100px;" ><span>' + displayContent + '</span></p>');
                btnObj.hide();
            },
            success: function (d, textStatus) {
                var resultObj = $(d);
                var error = $.trim(resultObj.find("#errorInfo").val());
                if (resultObj.length > 0 && error == "") {
                    var soSysNo = $.trim(resultObj.find("#SOSysNo").val());
                    window.location.href = "rechargestep3.aspx?sosysno=" + soSysNo;
                }
                else {
                    alert(error);
                    $("#divLoading").hide();
                    $("#btns").show();
                }
            },
            complete: function (XMLHttpRequest, textStatus) {

            },
            error: function () {

            }


        });
    }
};

var BizRechargeStep3 = {
    PaymentCard: function () {
        //send data
        $.ajax({
            url: $.newegg.buildSSL("Ajax/Order/AjaxRecharge.aspx"),
            dataType: "html",
            data: { Action: "checkStopTime" },
            type: "POST",
            cache: false,
            success: function (data, textStatus) {
                try {
                    data = eval("(" + data + ")");
                    if (data.Data == "Error") {
                        alert(data.Description);
                    }
                    else {
                        $('#chargeForm').submit();
                    }
                }
                catch (e) { }
            },
            complete: function (XMLHttpRequest, textStatus) { },
            error: function () { }
        });
    }
}