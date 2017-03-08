$(document).ready(function () {
    $('#repeatCounterCheck').attr("checked", "checked");
    $('#endDateInput').attr("disabled", "disabled").attr("value", "");
    $('#repeatCounterCheck').click(function () {
        $('#endDateInput').attr("disabled", "disabled").val("");
        $('#endDateInput').removeClass('inputError');
        $('#endDateErr').css('display','none');
        $('#repeatCountEnd').removeAttr("disabled");
    })
    $('#endDateCheck').click(function () {
        $('#repeatCountEnd').attr("disabled", "disabled").val("");
        $('#repeatCountEnd').removeClass('inputError');
        $('#repeatCountEndErr').css('display','none');
        $('#endDateInput').removeAttr("disabled");
    })
    $('#noWorkTimeCheck').click(function () {
        $('#WorkTimeSpansTable').hide().find("input").attr("disabled", "disabled");
        $('#WorkTimeSpansTable').find('tbody').find('tr').remove();
    })
    $('#workTimeCheck').click(function () {
        $('#WorkTimeSpansTable').show().find("input").removeAttr("disabled");
    })
    $('#businessCalendar').BusinessCalendar();
    $('#dayTitle').on("blur",function(){
        var valid = $(this).validate('testForEmpty');
        if(!valid){
            $(this).addClass('inputError');
            $("#dayTitleErr").css("display","block");
        } else {
            $(this).removeClass('inputError');
            $("#dayTitleErr").css("display","none");
        }
    })
    $('#startDate').on("blur",function(){
        var valid = $(this).validate('testForDate');
        if(!valid){
            $(this).addClass('inputError');
            $("#startDateErr").css("display","block");
        } else {
            $(this).removeClass('inputError');
            $("#startDateErr").css("display","none");
        }
    })
    $("#endDateInput").on("blur",function(){
        if(!this.hasAttribute("disabled")){
            var valid = $(this).validate('testForDate');
            if(!valid){
                $(this).addClass('inputError');
                $("#endDateErr").css("display","block");
            } else {
                $(this).removeClass('inputError');
                $("#endDateErr").css("display","none");
            }
        }     
    })
    $("#repeatCount").on("blur",function(){
        var valid = $(this).validate('testForPositiveInt');
        if(!valid){
            $(this).addClass('inputError');
            $("#repeatCountErr").css("display","block");
        } else {
            $(this).removeClass('inputError');
            $("#repeatCountErr").css("display","none");
        }
    })
    $("#repeatCountEnd").on("blur",function(){
        if(!this.hasAttribute("disabled")){
            var valid = $(this).validate('testForPositiveInt');
            if(!valid){
                $(this).addClass('inputError');
                $("#repeatCountEndErr").css("display","block");
            } else {
                $(this).removeClass('inputError');
                $("#repeatCountEndErr").css("display","none");
            }
        }  
    })
    $('#btnAddTS').on("click",function(){
        $("#WorkTimeSpansTable").BusinessCalendar("addTableRow","","","","");
        $("#WorkTimeSpansTable").find('.inputHour').on("blur",function(){
                var valid = $(this).validate("testForHour");
                if(!valid){
                    $(this).addClass("inputError");
                } else {
                    $(this).removeClass("inputError");
                }
        })
        $("#WorkTimeSpansTable").find('.inputMinutes').on("blur",function(){
            var valid = $(this).validate("testForMinutes");
            if(!valid){
                $(this).addClass("inputError");
            } else {
                $(this).removeClass("inputError");
            }
        })
    });
    $('#btnStoreDay').on("click",function(){
        var valid = false;
        var modal = document.getElementById('myModal');
        $(modal).find('input').blur();
        if($(modal).find('.inputError').length > 0){
            valid = false;
        } else {
            valid = true;
        }
        if(valid){
            $().BusinessCalendar("storeDay");
            $('#myModal').modal('hide');
        }
    })
    $('#btnDeleteDay').on("click",function(){
        $().BusinessCalendar("removeDay");
    })
})
