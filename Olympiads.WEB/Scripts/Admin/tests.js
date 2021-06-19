$(function () {
    var $tests = $("#tests");
    var $addEditTests = $("#addEditTests");
    function expandList() {
        $tests.removeClass("col-md-8");
        $tests.addClass("col-md-12");
        $addEditTests.empty();
        $addEditTests.removeClass("col-md-4");
        $addEditTests.addClass("d-none");
    }
    function collapseList() {
        $tests.removeClass("col-md-12");
        $tests.addClass("col-md-8");
        $addEditTests.removeClass("d-none");
        $addEditTests.addClass("col-md-4");
    }
    function searchTests() {
        expandList();
        let search = $("#search").val();
        var isActive = false;
        let isActiveRadio = $("#active");
        
        if (isActiveRadio.is(":checked")) {
            isActive = true;
        }
        $.get('/Testing/SearchTests', { Search: search, IsActive: isActive }, function (tests) {
            $tests.empty();
            $tests.append(tests);

            $(".btn-activate").each(function () {
                let testId = parseInt($(this).attr("data-id"));
                $(this).click(function () {
                    $.get('/Testing/Activate/', { "TestId": testId }).done(function () {
                        searchTests();
                    });
                });
            });
            $(".btn-deactivate").each(function () {
                let testId = parseInt($(this).attr("data-id"));
                $(this).click(function () {
                    $.get('/Testing/Deactivate/', { "TestId": testId }).done(function () {
                        searchTests();
                    });
                });
            });
            $(".btn-edit").each(function () {
                let testId = parseInt($(this).attr("data-id"));
                $(this).click(function () {
                    $.get('/Testing/GetTest/', { "TestId": testId }).done(function (test) {
                        collapseList();
                        $addEditTests.empty();
                        $addEditTests.append(test);
                        $("#editForm").on("submit", function (event) {
                            event.preventDefault();
                            event.stopImmediatePropagation();
                            $.get('/Testing/Save/', $(this).serialize()).done(function (errors) {
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
                            }).fail(function () {

                            });
                            return false;
                        });
                        $("#cancelEditButton").click(function () {
                            $addEditTests.empty();
                            expandList();
                        });
                    }).fail(function (r) {

                    });
                });
            });
        }).fail(function (e) {

        });
    }
    $("#searchTests").on("click", function () {
        searchTests();
    });
    $("#addButton").click(function () {
        $.get('/Testing/Add').done(function (add) {
            collapseList();
            $addEditTests.empty();
            $addEditTests.append(add);
            $("#editForm").on("submit", function (event) {
                $.get('/Testing/Save/', $(this).serialize()).done(function (errors) {
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
                }).fail(function (e) {

                });
                return false;
            });
        }).fail(function (e) {

        });
    });
});