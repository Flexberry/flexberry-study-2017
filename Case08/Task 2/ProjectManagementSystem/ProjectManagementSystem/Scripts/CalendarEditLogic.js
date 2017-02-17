var days = {};
var idButton;
var dayId;
$(document).ready(function () {

    $('.calendarDay').click(function () {
        id = $(this).attr('exceptionDayId');
    });
})
function getId(obj) {
    idButton = obj.id;
    var data = obj.dataset;
    dayId = data['currentdate'];

    if (dayId in days) {
        showDayInformation(dayId);
    } else {
        clearEditView(dayId);
    }
    return;
}
function clearEditView(date) {
    $('#tableAddRow').find('tbody').remove();
    $('#tableAddRow').show();
    $('input[name=iterType]')[0].checked = true;
    $('input[name=choiseDayTipe]')[1].checked = true;
    $('#startDate').val(date);
    $('input[name=choiseMethod]')[0].checked = true;
    $('#repeatCountEnd').removeAttr("disabled").val("");
    $('#endDateInput').attr("disabled", "disabled");
    $('#endDateInput').val("");
    $('#repeatCount').val("");
}
function showDayInformation(dayId) {
    var currentDay = days[dayId];

    if (currentDay !== undefined) {
        $('input[name=iterType]')[currentDay.iterationType].checked = true;
        $('input[name=choiseDayTipe]')[currentDay.dayType].checked = true;
        $('#repeatCount').val(currentDay.repeatCount);
        $('input[name=choiseMethod]')[currentDay.checkedChoiseMethod].checked = true;
        if (currentDay.workTimeSpansCount > 0) {
            var j;
            for (j = 0; j < currentDay.workTimeSpansCount; j++) {
                displayRow(currentDay.workTimeSpans[j].upTime,
                    currentDay.workTimeSpans[j].endTime);
            }
        }
        if (currentDay.endDate == null) {

            $('#endDateInput').attr("disabled", "disabled").val("");
            $('#repeatCountEnd').removeAttr("disabled");

            $('#repeatCountEnd').val(currentDay.repeatCountEnd);
        } else {
            $('#repeatCountEnd').attr("disabled", "disabled").val("");
            $('#endDateInput').removeAttr("disabled");

            $('#endDateInput').val(currentDay.endDate);
        }

        $('#startDate').val(currentDay.dateStart);

        if (currentDay.dayType === 0) {
            $('#noWorkTimeCheck').attr("checked", "checked");
            $('#tableAddRow').hide().find("input").attr("disabled", "disabled");
        } else {
            $('#workTimeCheck').attr("checked", "checked");
        }
    } else {
        clearEditView(dayId);
    }
}
function AddCalendarDay() {

    var iterType = $('input[name=iterType]');
    var checkedIterType = 0;
    var j;
    for (j = 0; j < iterType.length; j++) {
        if (iterType[j].checked) {
            checkedIterType = j;
        }
    }
    var choiseDayTipe = $('input[name=choiseDayTipe]');
    var checkedChoiseDayTipe;
    for (j = 0; j < choiseDayTipe.length; j++) {
        if (choiseDayTipe[j].checked) {
            checkedChoiseDayTipe = j;
        }
    }
    var workTimeSpans = {};
    var workTimeSpansCount = 0;
    if (checkedChoiseDayTipe === 1) {
        var table = document.getElementById('tableAddRow');
        for (j = 1; j < table.rows.length; j++){
            var upTime = $(table.rows[j]).find('input[name=upTime]').val();
            var endTime = $(table.rows[j]).find('input[name=endTime]').val();
            if ((upTime !== "")&&(endTime !== "")) {
                workTimeSpans[workTimeSpansCount] = {
                    upTime: upTime,
                    endTime: endTime
                }
                workTimeSpansCount++;
            }
        }
    }
    var endDate;
    var repeatCountEnd;
    var repeatCount = $('#repeatCount').val();
    var choiseMethod = $('input[name=choiseMethod]');
    var checkedChoiseMethod = 0;
    for (j = 0; j < choiseMethod.length; j++) {
        if (choiseMethod[j].checked) {
            checkedChoiseMethod = j;
        }
    }
    if (checkedChoiseMethod === 1) {
        endDate = $('#endDateInput').val();
        repeatCountEnd = null;
    } else {
        endDate = null;
        repeatCountEnd = $('#repeatCountEnd').val();
    }

    days[dayId] = {
        dateStart: dayId,
        workTimeSpans: workTimeSpans,
        workTimeSpansCount: workTimeSpansCount,
        iterationType: checkedIterType,
        dayType: checkedChoiseDayTipe,
        repeatCount: repeatCount,
        repeatCountEnd: repeatCountEnd,
        checkedChoiseMethod: checkedChoiseMethod,
        endDate: endDate
    }


    $('#' + idButton).addClass('holiday');
    clearEditView(dayId);
    return;
}