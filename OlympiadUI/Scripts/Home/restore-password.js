var select = $("#restorePasswordSelect");
var hiddenRestore = $("#hiddenRestore");

$(function () {
    hiddenRestore.prop("value", select.val());
    select.change(function () {
        hiddenRestore.prop("value",select.val());
    });
})