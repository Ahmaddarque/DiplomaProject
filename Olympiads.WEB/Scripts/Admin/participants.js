$(function () {
    function clearEditErrors() {
        $("#editParticipantForm > .error").each( function (r) {
            $(this).hide();
        });
    }
    function expandList() {
        $("#participants").removeClass("col-md-8");
        $("#participants").addClass("col-md-12");
        $("#addEditParticipants").empty();
        $("#addEditParticipants").removeClass("col-md-4");
        $("#addEditParticipants").addClass("d-none");
    }
    function collapseList() {
        $("#participants").removeClass("col-md-12");
        $("#participants").addClass("col-md-8");
        $("#addEditParticipants").removeClass("d-none");
        $("#addEditParticipants").addClass("col-md-4");
    }
    function searchParticipants() {
        expandList();
        let search = $("#search").val();
        $.ajax(
            {
                url: '/Participants/SearchParticipants',
                type: 'get',
                contentType: "application/json; charset=utf-8",
                data: { "search": search },
                dataType: "html",
                success: function (result) {
                    $("#participants").empty();
                    $("#participants").append(result);
                    $(".btn-unblock-participant").each(function () {
                        $(this).on("click", function () {
                            let participantId = $(this).attr("data-id");
                            $.ajax
                                (
                                    {
                                        url: "/Participants/Unblock",
                                        type: "get",
                                        contentType: "application/json; charset=utf-8",
                                        data: { "id": parseInt(participantId) },
                                        dataType: "html",
                                        success: function () {
                                            searchParticipants();
                                        },
                                    }
                                );
                        });
                    });
                    $(".btn-block-participant").each(function () {
                        $(this).on("click", function () {
                            let participantId = $(this).attr("data-id");
                            $.ajax
                                (
                                    {
                                        url: "/Participants/Block",
                                        type: "get",
                                        contentType: "application/json; charset=utf-8",
                                        data: { "id": parseInt(participantId) },
                                        dataType: "html",
                                        success: function () {
                                            searchParticipants();
                                        }
                                    }
                                );
                        });
                    });
                    $(".btn-edit-participant").on("click", function () {
                        collapseList();
                        let participantId = $(this).attr("data-id");
                        $.ajax
                            (
                                {
                                    url: "/Participants/Edit/" + participantId,
                                    type: "post",
                                    dataType: "html",
                                    success: function (result) {
                                        $("#addEditParticipants").empty();
                                        $("#addEditParticipants").append(result);
                                        $("#cancelEditButton").on("click", function () {
                                            expandList();
                                        });
                                        var $editForm = $("#editParticipantForm");
                                        $editForm.on("submit",function (event) {
                                            event.preventDefault();
                                            clearEditErrors();
                                            $.get("/Participants/Save", $(this).serialize())
                                                .done(function (errors) {
                                                    if (errors.length > 0) {
                                                        for (var i = 0; i < errors.length; i++) {
                                                            var field = $editForm.find(`#${errors[i].Property.toLowerCase()}`).first();
                                                            if (field.exists()) {
                                                                var errorField = field.siblings(".error").first();
                                                                if (errorField.exists()) {
                                                                    errorField.text(errors[i].Error);
                                                                    errorField.show();
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else {
                                                        expandList();
                                                    }
                                                });
                                            return false;
                                        }); 
                                    }
                                }
                            );
                    });

                }
            });
    }
    $("#addButton").on("click", function () {
        collapseList();
        $("#addEditParticipants").load("/Participants/Add", function () {
            var $editForm = $("#editParticipantForm");
            $("#cancelEditButton").on("click", function () {
                expandList();
            });
            $editForm.on("submit", function (event) {
                event.preventDefault();
                clearEditErrors();
                $.get("/Participants/Save", $(this).serialize())
                    .done(function (errors) {
                        if (errors.length > 0) {
                            for (var i = 0; i < errors.length; i++) {
                                var field = $editForm.find(`#${errors[i].Property.toLowerCase()}`).first();
                                if (field.exists()) {
                                    var errorField = field.siblings(".error").first();
                                    if (errorField.exists()) {
                                        errorField.text(errors[i].Error);
                                        errorField.show();
                                    }
                                }
                            }
                        }
                        else {
                            expandList();
                        }
                    });
                return false;
            }); 
        }); 
    }); 
    $("#searchParticipants").on("click", function () {
        searchParticipants();
    });
});