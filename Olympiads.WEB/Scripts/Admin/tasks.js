$(function () {
    var activityId = parseInt($("#activity-id").val());
    var $tasks = $("#tasks");
    var $addEditTasks = $("#addEditTasks");
    function showEditPanel() {
        $tasks.removeClass("col-md-12");
        $tasks.addClass("col-md-8");
        $addEditTasks.removeClass("d-none");
        $addEditTasks.addClass("col-md-4");
    }
    function hideEditPanel() {
        $addEditTasks.empty();
        $tasks.removeClass("col-md-8");
        $tasks.addClass("col-md-12");
        $addEditTasks.removeClass("col-md-4");
        $addEditTasks.addClass("d-none");
    }
    function loadTasks() {
        $.get('/Tasks/GetTasks', { ActivityId: activityId }, function (tasks) {
            $tasks.empty();
            $tasks.append(tasks);
            $(".btn-edit").each(function () {
                $(this).click(function () {
                    let taskNumber = parseInt($(this).attr("data-id"));
                    $.get("/Tasks/GetTask", { "ActivityId": activityId, "TaskNumber": taskNumber }, function (task) {
                        $addEditTasks.empty();
                        $addEditTasks.append(task);
                        showEditPanel();
                    }).fail(function (err) {
                        console.log(err);
                    });
                });
            });
            $(".btn-delete").each(function () {
                $(this).click(function () {
                    let taskNumber = parseInt($(this).attr("data-id"));
                    $.get("/Tasks/Delete/", { "ActivityId": activityId, "TaskNumber": taskNumber }, function (s) {
                        
                    }).fail(function (err) {
                        console.log(err);
                    });
                });
            });
        }).fail(function (err) {
            console.log(err);
        });
    }

    $("#addButton").click(function () {
        $.get("/Tasks/Add/", null, function (test) {
            $addEditTasks.append(test);
            showEditPanel();
            $("#cancelEditButton").click(function () {
                hideEditPanel();
            });
            $("#editForm").submit(function (e) {
                e.preventDefault();
                $.post("/Tasks/Save", $(this).serialize(), function (errors) {
                    else {
                        hideEditPanel();
                    }
                }).fail(function (err) {

                });
            });
        }).fail(function (err) {
            console.log(err);
        });
    });
    loadTasks();
});