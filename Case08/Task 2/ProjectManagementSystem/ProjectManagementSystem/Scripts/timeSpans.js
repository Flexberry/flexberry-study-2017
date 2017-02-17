$(document).ready(function () {
    $('.addBtn').on('click', function () {
        addTableRow();
    });
    $('.addBtnRemove').click(function () {
        $(this).closest('tr').remove();
    })
    $(document.body).closest('.addBtnRemove').click(function () {
        $(this).closest('tr').remove();
    })
    
    function deleteAllRows() {
        $('#tableAddRow').find('tr').remove();
    }
})
function addTableRow() {
    var table = document.getElementById('tableAddRow');
    var i = table.rows.length;
    var tempTr = $('<tr id="tr_' + i + '"><td><input type="text" name="upTime" id="startTime_' + i + '" class="form-control"/></td><td><input name="endTime" type="text" id="endTime_' + i + '" class="form-control" /></td><td><span class="glyphicon glyphicon-minus addBtnRemove" id="addBtnRemove_' + i + '"></span></td></tr>').on('click', function () {
        $(this).find('.addBtnRemove').on('click', function (e) {
            $(this).closest('tr').remove();
        });
    });
    $("#tableAddRow").append(tempTr);
}
function displayRow(upTime, endTime) {
    var table = document.getElementById('tableAddRow');
    var i = table.rows.length;
    var tempTr = $('<tr id="tr_' + i + '"><td><input type="text" name="upTime" value=' + upTime + ' id="startTime_' + i + '" class="form-control"/></td><td><input type="text" name="endTime" value=' + endTime + ' id="endTime_' + i + '" class="form-control" /></td><td><span class="glyphicon glyphicon-minus addBtnRemove" id="addBtnRemove_' + i + '"></span></td></tr>').on('click', function () {
        $(this).find('.addBtnRemove').on('click', function (e) {
            $(this).closest('tr').remove();
        });
    });
    $("#tableAddRow").append(tempTr)
}