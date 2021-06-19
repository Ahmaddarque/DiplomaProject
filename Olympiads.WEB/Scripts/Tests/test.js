$(function ()
{
    let optionTask = $("#option-task");
    if (optionTask.exists()) {
        var options = optionTask.find(".option");
        options.each(function () {
            $(this).change(function () {
                if (this.checked) {
                    for (let i = 0; i < options.length; i++) {
                        let input = $(options[i]).get(0);
                        let this_inp = $(this).get(0);
                        if (input != this_inp) {
                            $(input).prop("checked", false);
                        }
                    }
                }
            })
        })
    }
    
    $('#task-form').submit(function (event)
    {
        let userAnswer = $("#UserAnswer");
        if (optionTask.exists()) {
            let options = optionTask.find(".option");

            for (let i = 0; i < options.length; i++) {
                let optionInput = $(options[i]);
                let optionLabel = $(options[i]).siblings("label");

                if (optionInput.is(":checked")) {
                    let optionText = optionLabel.text();
                    userAnswer.val(optionLabel.text());
                    break;
                }

            }
        }

        else {
            let inputTask = $("#input-task");
            if (inputTask != null) {
                let userInput = inputTask.find("input[name='user-input']").first().val();
                userAnswer.val(userInput);
            }
        }

        let taskNumber = parseInt($("#TaskNumber").val());
        userAnswer = $("#UserAnswer").val();
        let data = { TaskNumber: taskNumber, UserAnswer:userAnswer }

        $.ajaxSettings.traditional = true;
        $.ajax
            (
                {
                    url: '/Tests/Submit',
                    type: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(data),
                    dataType: "html"
                }
            ).fail(function () {
            
            }).done(function () {
                let last = $("#IsLast").val() == 'True' ? true: false;
                if (last) {
                    window.location.href = "/Tests/Result";
                }
                else {
                    window.location.href = "/Tests/Test?Number=" + (taskNumber + 1);
                }
            });

        return false;
        
    })
})