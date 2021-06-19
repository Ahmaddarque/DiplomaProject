
$(function ()
{
    let optionTask = $("#option-task");
    if (optionTask.exists()) {
        var options = optionTask.find("[name^=task-option]");
        options.each(function () {
            $(this).find("input").change(function () {
                if (this.checked) {
                    for (let i = 0; i < options.length; i++) {
                        let input = $(options[i]).find("input").get(0);
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
        let submit = false;
        let userAnswer = $("#userAnswer");
        if (optionTask.exists()) {
            let options = optionTask.find("[name^=task-option]");

            for (let i = 0; i < options.length; i++) {
                let optionInput = $(options[i]).find("input");
                let optionLabel = $(options[i]).find("label");

                let checked = optionInput.attr('checked')
                if (typeof checked !== "undefined" && checked !== false) {
                    let optionText = optionLabel.text();
                    userAnswer.val(optionLabel.text());
                    break;
                }

            }

            submit = true;
        }

        else {
            let inputTask = $("#input-task");
            if (inputTask != null) {
                let userInput = inputTask.find("input[name='user-input']").first().val();
                userAnswer.val(userInput);
                submit = true;
            }
        }

        return submit;
    })
})