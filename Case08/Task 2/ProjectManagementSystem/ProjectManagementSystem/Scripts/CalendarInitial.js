$(document).ready(function () {
    $('#repeatCounterCheck').attr("checked", "checked");
    $('#endDateInput').attr("disabled", "disabled").attr("value", "");
    $('.datepicker').datepicker();
    $('#repeatCounterCheck').click(function () {
        $('#endDateInput').attr("disabled", "disabled").val("");
        $('#repeatCountEnd').removeAttr("disabled");
    })
    $('#endDateCheck').click(function () {
        $('#repeatCountEnd').attr("disabled", "disabled").val("");
        $('#endDateInput').removeAttr("disabled");
    })
    $('#noWorkTimeCheck').click(function () {
        $('#tableAddRow').hide().find("input").attr("disabled", "disabled");
    })
    $('#workTimeCheck').click(function () {
        $('#tableAddRow').show().find("input").removeAttr("disabled");
    })
})
