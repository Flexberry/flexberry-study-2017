var timeSpans = {};

function addRow(upTimeH, upTimeM, endTimeH, endTimeM) {
    var table = document.getElementById('TimeSpansTable');
    var i = table.rows.length;
    var tempTr = ('<tr id="tr_' + i + '">\
                                <td class="textMiddle timeCell borderGray">\
                                            <input type="number" value=\"' + upTimeH + '\" name="upTimeH" id="startTime_' + i + '" class="textStandart inputSmall inputHour"/>\
                                            <span style="vertical-align: sub; font-weight:bold;">:</span>\
                                            <input type="number"  value=\"'+ upTimeM +'\" name="upTimeM" id="startTimeM_' + i + '" class="textStandart inputSmall inputMinutes"/>\
                                </td>\
                                <td class="textMiddle timeCell borderGray">\
                                            <input name="endTimeH" type="number" value=\"' + endTimeH + '\"  id="endTime_' + i + '" class="textStandart inputSmall inputHour"/>\
                                            <span style="vertical-align: sub; font-weight:bold;">:</span>\
                                            <input name="endTimeM" type="number" value=\"' + endTimeM + '\" id="endTimeM_' + i + '"  class="textStandart inputSmall inputMinutes"/>\
                                </td>\
                                <td class="textMiddle smallCell borderGray"><button type="button" class="glyphiconStyle glyphicon-minus background-center btnStandart btnSmall delTS" id="workTimeSpan_' + i + '" tabindex="-1"></button></td>\
                            </tr>');
    $("#TimeSpansTable").find('tbody').append(tempTr);
    $("#TimeSpansTable").find('tbody').find('button').on("click",function(){
        $(this).closest('tr').remove();
    })
}