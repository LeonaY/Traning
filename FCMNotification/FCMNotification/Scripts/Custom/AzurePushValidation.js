$.validator.addMethod("dategreaterthan", function (value, element, params) {
    return Date.parse(value) > Date.parse($(params).val());
});

$.validator.addMethod("myCheckContentRequire", function (value, element, params) {
    if (value == "1") {
        return false
    }
    else {
        return true
    }
});


$.validator.unobtrusive.adapters.add("CheckContentRequire", [], function (options) {
    options.rules["myCheckContentRequire"] = true;
    options.messages["myCheckContentRequire"] = options.message;
});


$.validator.unobtrusive.adapters.add("dategreaterthan", ["otherpropertyname2"], function (options) {
    options.rules["dategreaterthan"] = "#" + options.params.otherpropertyname2;
    options.messages["dategreaterthan"] = options.message;
});