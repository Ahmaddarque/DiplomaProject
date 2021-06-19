function renderRestore() {
    let selectedOption = $("#restorePasswordSelect").val();
    $.ajax(
        {
            url: '/Home/RenderRemindPassword',
            contentType: 'application/html; charset=utf-8',
            type: 'get',
            data: { restoreMethod: selectedOption },
            success: function (res) {
                $("#restorePasswordArea").append(res);
                let sendPhone = $("#sendPhone");
                if (sendPhone.exists()) {
                    sendPhone.on("click", function () {
                        let phone = $("#phone").val();
                        $.ajax({
                            url: "/Home/TryRestoreByPhone",
                            data: JSON.stringify({phone: phone}),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            type: 'post',
                            success: function (hasPhone) {
                                if (!hasPhone) {
                                    $("#phoneError").removeClass("d-none");
                                }
                                else {
                                    $("#phoneError").addClass("d-none");
                                    $("#sendPhone").addClass("d-none");
                                    $("#codeSubmit").removeClass("d-none");
                                }
                            },
                            });
                    });
                }  
            },
            error: function (r) {
                let res = r;
            }
        }
    );
}
$(function () {
    renderRestore();

    $("#restorePasswordSelect").change(function (e) {
        renderRestore();
    });
})