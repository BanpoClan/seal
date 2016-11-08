//建立页面视图模型
var ViewModel = {
    //侦测和响应集合变化
    accountList: ko.observableArray(),

    add: function () {
        this.accountList.push({ ID: "", Age: "", Name: "", Sex: "" });
    },

    remove: function (account) {
        this.accountList.remove(account);
    },

    save: function () {
        //alert("transmit to server: " + ko.utils.stringifyJson(this.accountList));
        var postdata = ko.utils.stringifyJson(this.accountList);
        $.ajax({
            url: "/api/Account/ReceiveData",
            type: "post",
            contentType: "application/json",
            data: postdata,
            dataType: "json",
            success: function (result) {
                debugger;
            }
        });
    },

    getAll: function () {
        $.ajax({
            url: "/api/Account/GetAll",
            type: "get",
            data: {},
            dataType: "json",
            success: function (result) {
                ViewModel.accountList(result);
            }
        });

    }
}




$(function () {
    ViewModel.getAll();
    ko.applyBindings(ViewModel);
    $("form").validate({ submitHandler: function () { ViewModel.save() } });
});