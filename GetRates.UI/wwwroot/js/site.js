$(".show-quote").click(function () {
    var icon = $(this).find(".fa");
    if ($(this).closest(".card").find(".collapse.show").length) {        
        icon.removeClass("fa-minus").addClass("fa-plus");
    }
    else {
        icon.removeClass("fa-plus").addClass("fa-minus");
    }
});

$(".show-details").click(function () {
    var displayText = $(this)[0].innerHTML.trim();
    console.log(displayText);
    if (displayText == "Show Details") {
        $(this)[0].innerHTML = "Hide Details";
    }
    else {
        $(this)[0].innerHTML = "Show Details";
    }
});