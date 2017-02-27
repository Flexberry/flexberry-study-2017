var days = {};

var idButton;
var dayId;
var curDay;

$(document).ready(function () {
    $('.calendarDay').click(function () {
        id = $(this).attr('exceptionDayId');
    });
})

function getId(obj) {
    idButton = obj.id;
    var data = obj.dataset;
    dayId = $(obj).data('dayid');
    curDay = $(obj).data('currentdate');
    if (dayId in days) {
        showDayInformation(dayId);
        $('#btnDeleteDay').prop("disabled", false);
    } else {
        clearEditView(curDay);
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
    $('#dayTitle').val("");
    $('#btnDeleteDay').prop("disabled", true);
}

function showDayInformation(dayId) {
    var currentDay = days[dayId];

    $('#dayTitle').val(currentDay.dayTitle);
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
        if (currentDay.dayEnd === null) {
            $('#endDateInput').attr("disabled", "disabled").val("");
            $('#repeatCountEnd').removeAttr("disabled");

            $('#repeatCountEnd').val(currentDay.repeatCountEnd);
        } else {
            $('#repeatCountEnd').attr("disabled", "disabled").val("");
            $('#endDateInput').removeAttr("disabled");

            var dayEnd = new Date(currentDay.dayStart);
            var dayEndString = dayEnd.getDate() + '/' + (dayEnd.getMonth() + 1) + '/' + dayEnd.getFullYear();
            $('#endDateInput').val(dayEndString);
        }

        var day = new Date(currentDay.dayStart);
        var dayString = day.getDate() + '/' + (day.getMonth() + 1) + '/' + day.getFullYear();
        $('#startDate').val(dayString);

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
    var dayEnd;
    var repeatCountEnd;
    var repeatCount = parseInt($('#repeatCount').val());
    var choiseMethod = $('input[name=choiseMethod]');
    var checkedChoiseMethod = 0;
    for (j = 0; j < choiseMethod.length; j++) {
        if (choiseMethod[j].checked) {
            checkedChoiseMethod = j;
        }
    }
    if (checkedChoiseMethod === 1) {
        var dayEndStr = $('#endDateInput').val();
        var dayEndArr = dayEndStr.split('/');
        var dayEndDate = new Date(dayEndArr[2], (dayEndArr[1] - 1), dayEndArr[0]);
        dayEnd = dayEndDate.getTime();
        repeatCountEnd = null;
    } else {
        dayEnd = null;
        repeatCountEnd = $('#repeatCountEnd').val();
    }
    var dayTitle = $('#dayTitle').val();

    var dayStartString = String($('#startDate').val());
    var dayStartArr = dayStartString.split('/');
    var dayStart = new Date(dayStartArr[2], (dayStartArr[1] - 1), dayStartArr[0]);
    dayStart = dayStart.getTime();

    if (dayId in days) {
        deleteDay(dayId);
        delete days[dayId];
    } else {
        var dayIdStr = String(curDay);
        var dayIdArr = dayIdStr.split('/');
        var dayIdDate = new Date(dayIdArr[2], (dayIdArr[1] - 1), dayIdArr[0]);
        dayId = dayIdDate.getTime();
    }

    days[dayId] = {
        dayStart: dayStart,
        dayEnd: dayEnd,
        workTimeSpans: workTimeSpans,
        workTimeSpansCount: workTimeSpansCount,
        iterationType: checkedIterType,
        dayType: checkedChoiseDayTipe,
        repeatCount: repeatCount,
        repeatCountEnd: repeatCountEnd,
        checkedChoiseMethod: checkedChoiseMethod,
        dayTitle: dayTitle
    }

    splitDay(dayId);
    clearEditView(dayId);
    return;
}
function DeleteCalendarDay() {
    deleteDay(dayId);
    clearEditView(curDay);
    delete days[dayId];
    return;
}
function splitDay(dayId) {
    var date = new Date(parseInt(days[dayId].dayStart));
    var dayEnd = new Date(parseInt(days[dayId].dayEnd));

    if (days[dayId].dayEnd === null) {
        for (i = 0; i < days[dayId].repeatCountEnd; i++){
            markDay(date, dayId, true);
        }
    } else {
        while (date < dayEnd) {
            markDay(date,dayId, true);
        }
    }
    return;
}

function deleteDay(dayId) {
    var date = new Date(parseInt(days[dayId].dayStart));
    var dayEnd = new Date(parseInt(days[dayId].dayEnd));

    if (days[dayId].dayEnd === null) {
        for (i = 0; i < days[dayId].repeatCountEnd; i++) {
            markDay(date, dayId, false);
        }
    } else {
        while (date <= dayEnd) {
            markDay(date, dayId, false);
        }
    }
    return;
}

function markDay(date, dayId, Option) {
    var stringDate = date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear();
    if (Option) {
        $("input[data-currentDate=\"" + stringDate + "\"]").data("dayid", dayId);
        $("input[data-currentDate=\"" + stringDate + "\"]").addClass("holiday");
    } else {
        $("input[data-currentDate=\"" + stringDate + "\"]").data("dayid", "");
        $("input[data-currentDate=\"" + stringDate + "\"]").removeClass("holiday");
    }
    switch (days[dayId].iterationType) {
        case 0:
            date.setDate(date.getDate() + days[dayId].repeatCount);
            break
        case 1:
            date.setDate(date.getDate() + days[dayId].repeatCount * 7);
            break
        case 2:
            date.setMonth(date.getMonth() + days[dayId].repeatCount);
            break
        case 3:
            date.setFullYear(date.getFullYear() + days[dayId].repeatCount);
            break
        default:
    }

    return;
}

