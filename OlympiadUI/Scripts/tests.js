/*/*const { getJSON } = require("jquery");*/

var tests = $(".tests");
tests.setPageCount = function (pageCount) {
    Number.isInteger(pageCount);
    this.attr("pageCount", pageCount);
}
tests.getPageCount = function () {
    return parseInt(this.attr("pageCount"));
}
function getSearchInfo() {
    let search = $("#tests-search").val();
    let categories = [];
    let subjects = [];
    let searchInfo = {};

    $(".filter-selected.subject-filter").each(function (index) {
        let id = parseInt($(this).attr("data-id"));
        subjects.push(id);
    });
    $(".filter-selected.category-filter").each(function (index) {
        let id = parseInt($(this).attr("data-id"));
        categories.push(id);
    });

    searchInfo.Search = search;

    
    if (categories.length == 0) {
        searchInfo.Categories = null;
    }
    else {
        searchInfo.Categories = categories;
    }
    if (subjects.length == 0) {
        searchInfo.Subjects = null;
    }
    else {
        searchInfo.Subjects = subjects;
    }
    
    searchInfo.startIdx = tests.getPageCount();
    return searchInfo;
}

function loadTests() {
    var searchInfoJson = JSON.stringify(getSearchInfo(),null,2);
    $.ajax(
        {
            url: '/Tests/RenderTests',
            contentType: 'application/html; charset=utf-8',
            type: 'get',
            data: { json: searchInfoJson},
            success: function (result) {
                tests.append(result);
                tests.setPageCount(tests.getPageCount() + 10);

                var resultNotFound = $("#resultNotFound");
                if ($("#resultNotFound").exists()) {
                    $("#loadMoreTests").hide();
                }
            },
            error: function(e) {
                
            }
        });

    
}
$(function () {
    tests.setPageCount(0);
    tests.empty();
    loadTests();

    $("#loadMoreTests").on("click", function () {
        loadTests();
    });
    $(".filter").each(function (index) {
        $(this).on("click", function () {
            if ($(this).hasClass("filter-selected")) {
                $(this).removeClass("filter-selected");
            }
            else {
                $(this).addClass("filter-selected");
                if ($(this).hasClass("subject-filter")) {
                    $("#filter-subject-all").prop("checked", false);
                }
                else {
                    if ($(this).hasClass("category-filter")) {
                        $("#filter-category-all").prop("checked", false);
                    }
                }
            }
        });
    });

    $("#filter-subject-all").change(function () {
        if (this.checked) {
            $(".filter-selected.subject-filter").each(function (index) {
                $(this).removeClass("filter-selected");
            });
        }
    });

    $("#filter-category-all").change(function () {
        if (this.checked) {
            $(".filter-selected.category-filter").each(function (index) {
                $(this).removeClass("filter-selected");
            });
        }
    });

    $("#load-tests").on("click", function () {
        
        tests.empty();
        tests.setPageCount(0);
        loadTests();
        if ($("#loadMoreTests").is(":hidden")) {
            $("#loadMoreTests").show();
        }
    });
});


