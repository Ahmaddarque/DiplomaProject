

$(function () {
    var $olympiads = $("#olympiads");
    var $addEditOlympiads = $("#addEditOlympiads");
    var $search = $("search");
    function expandList() {
        $olympiads.removeClass("col-md-8");
        $olympiads.addClass("col-md-12");
        $addEditOlympiads.empty();
        $addEditOlympiads.removeClass("col-md-4");
        $addEditOlympiads.addClass("d-none");
    }
    function collapseList() {
        $olympiads.removeClass("col-md-12");
        $olympiads.addClass("col-md-8");
        $addEditOlympiads.removeClass("d-none");
        $addEditOlympiads.addClass("col-md-4");
    }
    function saveOlympiads() {
        $.get('/Olympiads/Save/', $("#editForm").serialize(), function (errors) {
            if (errors.length > 0) {
                for (let i = 0; i < errors.length; i++) {
                    let field = $("#editForm").find(`#${errors[i].Property.toLowerCase()}`).first();
                    if (field.exists()) {
                        let errorField = field.siblings(".error").first();
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
    }
    $("#addButton").click(function () {
        collapseList();
        $addEditOlympiads.load('/Olympiads/Add', function () {
            $("#cancelEditButton").click(function () {
                $addEditOlympiads.empty();
                expandList();
            });
            $("#editForm").submit(function (e) {
                saveOlympiads(e);
            });
            $("#minutes").change(function () {
                let minutes = parseInt($(this).val());
                if (minutes >= 60) {
                    let hours = parseInt($("#hours").val());
                    hours = hours + parseInt(minutes / 60);
                    minutes = minutes % 60;
                    $("#hours").val(hours);
                    $(this).val(minutes);
                }
            });
        });
    });
    function loadOlympiads() {
        let search = $("#search").val();
        let isActive = false;
        if ($("#active").is(":checked")) {
            isActive = true;
        }
        
        
        $.get("/Olympiads/GetOlympiads", { "Search": search, "IsActive": isActive }).done(function (olymps) {
            $olympiads.empty();
            $olympiads.append(olymps);
            $(".btn-activate").each(function () {
                let olympiadId = $(this).attr("data-id");
                $(this).click(function () {
                    $.get("/Olympiads/Activate", { "OlympiadId": olympiadId }).done(function (e) {
                        loadOlympiads();
                    }).fail(function (err) {
                        console.log(err);
                    });
                });
            });
            $(".btn-deactivate").each(function () {
                $(this).click(function () {
                    let olympiadId = $(this).attr("data-id");
                    $.get("/Olympiads/Deactivate", { "OlympiadId": olympiadId }).done(function (e) {
                        loadOlympiads();
                    }).fail(function (err) {
                        console.log(err);
                    });
                });
            });
            $(".btn-edit").each(function () {
                let olympiadId = $(this).attr("data-id");
                $(this).click(function () {
                    $.get("/Olympiads/GetOlympiad", { "OlympiadId": olympiadId }).done(function (olympiad) {
                        $addEditOlympiads.empty();
                        $addEditOlympiads.append(olympiad);
                        collapseList();
                        $("#editForm").submit(function (e) {
                            e.preventDefault();
                            saveOlympiads(e);
                        });
                        $("#cancelEditButton").click(function () {
                            $addEditOlympiads.empty();
                            expandList();
                        });

                    }).fail(function (err) {
                        console.log(err);
                    });
                });
            });
            expandList();
        }).fail(function (err) {
            console.log(err);
        });
    }
    $("#searchOlympiads").click(function () {
        loadOlympiads();
    });
});