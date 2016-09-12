$(function () {
    if ($('#FCMResult').text() != '') {
        var content = JSON.stringify(jQuery.parseJSON($('#FCMResult').text()), null, 2);
        $("#FormatResult").html("<pre>" + content + "</pre>");
    }
})