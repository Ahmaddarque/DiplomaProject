$(function () {
    let items = $(".main-menu-item");
        
    items.each(function () {
        $(this).removeClass("active");
        let href = $(this).find("a").attr("href");
        currentHref = window.location.pathname;

        if (currentHref == href) {
            $(this).addClass("active");
        }
    });
})