$(function () {
    ByTokenChange();

    $(".ByTokenChange").click(function () {
        ByTokenChange();
    })

    function ByTokenChange()
    {
        var selected = $("#IsByTokenDiv input[type='radio']:checked");
        if (selected.val() == "True") {
            $("#ByToken").show();
            $("#ByTopic").hide();
            $("#Topics").val('');
        }
        else {
            $("#ByTopic").show();
            $("#ByToken").hide();
            $("#RegistrationToken").val('');
        }
    }
})