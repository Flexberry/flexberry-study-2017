$(window).on("load", function () {

    var tsView = document.getElementsByClassName('TimeSpanView')[0];

    if (dropDownDayType.value === "Выходной") {
        $(tsView).TimeSpans("hide");
    }
  
    dropDownDayType.onchange = function(){
        if (dropDownDayType.value === "Выходной") {
            $(tsView).TimeSpans("dispose").TimeSpans("hide");
        }
        else if (dropDownDayType.value === "Рабочий") {
            $(tsView).TimeSpans("show");
        }
        return;
    };

    txtRepStep.onchange = function () {
        ReCalculateValues();
    };

    txtStartDate.onchange = function () {
        ReCalculateValues();
    }
   
    dropDownRecType.onchange = function () {
        ReCalculateValues();
    }
    txtEndDate.onchange = function () {
        if ($(txtEndDate).validate("testForDate") && ($(txtStartDate).validate("testForEmpty")) && ($(txtRepStep).validate("testForPositiveInt"))) {
            var startDateArr = txtStartDate.value.split('.');
            var startDate = new Date(startDateArr[2], (startDateArr[1] - 1), startDateArr[0]);

            var endDateArr = txtEndDate.value.split('.');
            var endDate = new Date(endDateArr[2], (endDateArr[1] - 1), endDateArr[0]);

            var repStep = parseInt(txtRepStep.value);

            txtRecCount.value = CalculateRepCount(startDate, endDate, repStep, GetRecType());
        }
    }

    txtRecCount.onchange = function () {
        if (($(txtStartDate).validate("testForDate")) && ($(txtRepStep).validate("testForPositiveInt")) && ($(txtRecCount).validate("testForPositiveInt"))) {
            var startDateArr = txtStartDate.value.split('.');
            var startDate = new Date(startDateArr[2], (startDateArr[1] - 1), startDateArr[0]);

            var recCount = parseInt(txtRecCount.value);

            var repStep = parseInt(txtRepStep.value);

            txtEndDate.value = CalculateEndDate(startDate, recCount, repStep, GetRecType());
        }
    }
})
/**
* Метод перевычисляет поля для ввода даты начала, окончания, конечного числа повторений, в случае изменения одного из них
*/
function ReCalculateValues() {
    if ($(txtEndDate).validate("testForDate") && ($(txtStartDate).validate("testForDate")) && ($(txtRepStep).validate("testForPositiveInt"))) {
        var startDateArr = txtStartDate.value.split('.');
        var startDate = new Date(startDateArr[2], (startDateArr[1] - 1), startDateArr[0]);

        var endDateArr = txtEndDate.value.split('.');
        var endDate = new Date(endDateArr[2], (endDateArr[1] - 1), endDateArr[0]);

        var repStep = parseInt(txtRepStep.value);

        txtRecCount.value = CalculateRepCount(startDate, endDate, repStep, GetRecType());
    } else if (($(txtStartDate).validate("testForDate")) && ($(txtRepStep).validate("testForPositiveInt")) && ($(txtRecCount).validate("testForPositiveInt"))) {
        var startDateArr = txtStartDate.value.split('.');
        var startDate = new Date(startDateArr[2], (startDateArr[1] - 1), startDateArr[0]);

        var recCount = parseInt(txtRecCount.value);

        var repStep = parseInt(txtRepStep.value);

        txtEndDate.value = CalculateEndDate(startDate, recCount, repStep, GetRecType());
    }
}
/**
 * Функция считывает текущий тип повторения дня-исключения и приводит его к целочисленному эквиваленту
 * @returns {Int} тип повторения
 */
function GetRecType() {
    var recType = 0;
    switch (dropDownRecType.value) {
        case "Ежедневно": recType = 0;
            break;
        case "Еженедельно": recType = 1;
            break;
        case "Ежемесячно": recType = 2;
            break;
        case "Ежегодно": recType = 3;
            break;
        default:
    }
    return recType;
}
/**
 * Функция вычисляет конечную дату на основе заданного количества повторений
 * @param {Date} startDate Дата начала
 * @param {Int} RecCount Число повторений
 * @param {Int} RepStep Шаг повторений
 * @param {Int} RecType Тип повторения
 * @returns {Date} конечная дата 
 */
function CalculateEndDate(StartDate, RecCount, RepStep, RecType) {
    var resultDate = StartDate;
    for(var i = 0;i<RecCount;i++)
    {
        switch (RecType) {
            case 0:
                resultDate.setDate(resultDate.getDate() + RepStep);
                break;
            case 1:
                resultDate.setDate(resultDate.getDate() + RepStep * 7);
                break;
            case 2:
                resultDate.setMonth(resultDate.getMonth() + RepStep);
                break;
            case 3:
                resultDate.setFullYear(resultDate.getFullYear() + RepStep);
                break;
            default:
        }
    }
    return resultDate;
}
/**
 * Функция вычисляет конечное число повторений на основе заданной даты окончания
 * @param {type} StartDate Дата начала
 * @param {type} EndDate Дата окончания
 * @param {type} RepStep Шаг повторения
 * @param {type} RecType Тип повторения
 * @returns {Int} RecCount Количество повторений
 */
function CalculateRepCount(StartDate, EndDate, RepStep, RecType)
{
    var RecCount = 0;
    while(StartDate <= EndDate)
    {
        switch (RecType) {
            case 0:
                StartDate.setDate(StartDate.getDate() + RepStep);
                break;
            case 1:
                StartDate.setDate(StartDate.getDate() + RepStep * 7);
                break;
            case 2:
                StartDate.setMonth(StartDate.getMonth() + RepStep);
                break;
            case 3:
                StartDate.setFullYear(StartDate.getFullYear() + RepStep);
                break;
            default:
        }
        RecCount++;
    }
    return RecCount;
}