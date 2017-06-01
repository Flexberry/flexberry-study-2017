(function( $ ) {
    /**
     * атрибуты плагина
     * 
     * @type {object}
     */
    var attributes = {
        /**
         * Список дней
         * 
         * @type {object}
         */
        days : {},
        /**
         * Идентификатор дня-исключения, который храниться в кнопке дня, выбранной пользователем
         * 
         * @type {String}
         */
        dayId : "",
        /**
         * Дата дня, которая храниться в кнопке дня, выбранной пользователем
         * 
         * @type {string}
         */
        curDay : "",
        /**
         * Текущий месяц календаря, который отображён пользотелю
         * 
         * @type {Number}
         */
        curMonth : null,
        /**
         * Текущий год календаря
         * 
         * @type {Number}
         */
        curYear : null,
        /**
         * Название месяцов, для отображения в календаре
         * 
         * @type {Array}
         */
        month : ['Январь','Февраль','Март','Апрель','Май','Июнь',
                'Июль','Август','Сентябрь','Октябрь','Ноябрь','Декабрь']
    }
    /**
     * Методы для работы с плагином
     * 
     * @type {object}
     */
    var methods = {
    
        /**
         * Метод создаёт календарь дней исключений
         * 
         * @param dateStart число с которого будет начинаться построение календаря
         * 
         * @param monthName название месяца, информацию по которому необходимо отобразить
         * 
         * @returns {void}
         */
        createCalendar:function(dateStart,monthName,container,sourceControl){
                var table = document.createElement("table");
                table.setAttribute("class","calendar");
                
                //Формирование шапки календаря
                var trCalendarHead = document.createElement("tr");
                var tdCalendarMonthName = document.createElement("td");
                var tdCalendarYearNumber = document.createElement("td");
                var tdCalendarPrevMonth = document.createElement("td");
                var tdCalendarNextMonth = document.createElement("td");
                
                tdCalendarMonthName.setAttribute("colspan","3");
                tdCalendarMonthName.setAttribute("class","calendarMonthNameCell");
                tdCalendarMonthName.innerText = monthName;
                
                tdCalendarYearNumber.setAttribute("colspan","2");
                tdCalendarYearNumber.setAttribute("class","calendarMonthNameCell");
                tdCalendarYearNumber.innerText = attributes.curYear;

                var btnPrevMonth = document.createElement("button");
                btnPrevMonth.setAttribute("class", "btnStandart btnMedium fa fa-chevron-down background-center");
                btnPrevMonth.setAttribute("aria-hidden", "true");
                btnPrevMonth.onclick = function () {
                    methods.goPrevMonth(container, sourceControl);
                }
                //tdCalendarPrevMonth.appendChild(btnPrevMonth);

                tdCalendarPrevMonth.setAttribute("class", " btnMedium fa-chevron-up background-center glyphiconStyle btn-navigation");
                tdCalendarPrevMonth.setAttribute("aria-hidden", "true");
                tdCalendarPrevMonth.onclick = function () {
                    methods.goPrevMonth(container, sourceControl);
                }

                var btnNextMonth = document.createElement("button");
                btnNextMonth.setAttribute("class","btnMedium fa fa-chevron-down");
                btnNextMonth.setAttribute("aria-hidden", "true");
                btnNextMonth.onclick = function () { methods.goNextMonth(container, sourceControl); }
                //tdCalendarNextMonth.appendChild(btnNextMonth);
                
                tdCalendarNextMonth.setAttribute("class", "btnMedium fa-chevron-down background-center glyphiconStyle btn-navigation");
                tdCalendarNextMonth.setAttribute("aria-hidden", "true");
                tdCalendarNextMonth.onclick = function () {
                    methods.goNextMonth(container, sourceControl);
                }

                trCalendarHead.appendChild(tdCalendarMonthName);
                trCalendarHead.appendChild(tdCalendarYearNumber);
                trCalendarHead.appendChild(tdCalendarPrevMonth);
                trCalendarHead.appendChild(tdCalendarNextMonth);

                table.appendChild(trCalendarHead);

                var week = ["Пн","Вт","Ср","Чт","Пт","Сб","Вс"];
                var trCalendarDayName = document.createElement("tr");
                trCalendarDayName.setAttribute("class","calendarDayNameRow");
                for (var dayIndex = 0; dayIndex < week.length; dayIndex++) {
                    var td = document.createElement("td");
                    td.innerText = week[dayIndex];
                    trCalendarDayName.appendChild(td);
                }
                table.appendChild(trCalendarDayName);
                
                //Формирование тела календаря
                var btnDayId = 0;
                for (var rowNumber = 0; rowNumber < 6; rowNumber++){
                    var tableRow = document.createElement("tr")
                    for(var cellNumber = 0; cellNumber < 7; cellNumber++){
                        var td = document.createElement("td");
                        var btn = document.createElement("button");
                        btn.dataset.currentDate = dateStart.getTime();
                        btn.dataset.dayId = "";
                        btn.setAttribute("data-title", "Пусто");
                        btn.setAttribute("id","btnDay_" + btnDayId.toString());
                        btn.setAttribute("class","btnStandart btnMedium");
                        btn.type = "button";
                        btn.innerText = dateStart.getDate().toString();
                        btn.onclick = function () {
                            methods.openEditForm(this);
                        }
                        td.appendChild(btn);
                        tableRow.appendChild(td);
                        dateStart.setDate(dateStart.getDate()+1);
                        btnDayId++;
                    }
                    table.appendChild(tableRow);
                }
                if(container.firstChild !== null)
                {
                    container.removeChild(container.firstChild);
                }
                container.appendChild(table);
        },
        /**
         * Метод определяет число понедельника для календаря
         * 
         * @param year необходимый год
         * 
         * @param month порядковый номер месяца (0..11)
         * 
         * @returns {Date}
         */
        getFirstDate :function(year,month){
            var firstDate = new Date(year,month,1,5,0,0);
            var daysCount;
            var dayOfWeek = firstDate.getDay();
            switch (dayOfWeek) {
                case 0:
                    daysCount = 6;
                    break;
                case 1:
                    daysCount = 0;
                    break;
                case 2:
                    daysCount = 1;
                    break;
                case 3:
                    daysCount = 2;
                    break;
                case 4:
                    daysCount = 3;
                    break;
                case 5:
                    daysCount = 4;
                    break;
                case 6:
                    daysCount = 5;
                    break;
                default:daysCount = 0;
                    break;
            }
            firstDate.setDate(firstDate.getDate()-daysCount);
            return firstDate;
        },
        /**
         * Метод переводит календарь на предыдущий месяца
         * 
         */
        goPrevMonth:function(container,sourceControl){
            if (attributes.curMonth === 0){
                attributes.curMonth = 11;
                attributes.curYear--;
            } else {
                attributes.curMonth--;
            }
            methods.createCalendar(methods.getFirstDate(attributes.curYear,attributes.curMonth),attributes.month[attributes.curMonth],container,sourceControl);
            methods.refreshCalendar(methods.getExcDayArray(sourceControl));
        },
        /**
         * Метод переводит календарь на следующий месяц
         */
        goNextMonth : function(container,sourceControl){
            if(attributes.curMonth === 11){
                attributes.curMonth = 0;
                attributes.curYear++;
            } else {
                attributes.curMonth++;
            }
            methods.createCalendar(methods.getFirstDate(attributes.curYear,attributes.curMonth),attributes.month[attributes.curMonth],container,sourceControl);
            methods.refreshCalendar(methods.getExcDayArray(sourceControl));
        },
        /**
         * 
         */
        getExcDayArray: function(sourceControl){
            var excDayArr = [];
            if (sourceControl !== {}) {
                var excDayString = sourceControl.value;
                if (excDayString !== "") {
                    excDayArr = JSON.parse(excDayString);
                }
            }
            return excDayArr;
        },
        /**
         * Метод сохраняет день-исключение в календаре
         */
        storeDay : function() {
            var day = methods.readDay()
            if (attributes.dayId in attributes.days) {
                methods.deleteDay(attributes.dayId);
                delete attributes.days[attributes.dayId];
            } else {
                attributes.dayId = attributes.curDay;
            }
            attributes.days[attributes.dayId] = day;

            methods.splitDay(attributes.dayId);
        },
        /**
         * Удаляет информацию о дне-исключении из календаря
         */
        removeDay : function(){
            methods.deleteDay(attributes.dayId);
            methods.clearEditView(attributes.curDay);
            delete attributes.days[attributes.dayId];
        },
        /**
         * Метод открывает форму редактирования дня
         * @param {DOM} btn кнопка дня - календаря
         */
        openEditForm: function (btn) {
            
            var ExcDayId = $(btn).data("day-id");
            var URL = "";
            if (ExcDayId !== "") {
                URL = "ExceptionDayE.aspx?PK=" + ExcDayId + "&ReturnURL=" + location.href + "&_flex-nw=True&_flex-md=True&DisableSaveAndCloseBtn=true&DisableCloseBtn=true";
            } else {
                URL = "ExceptionDayE.aspx?ReturnURL=" + location.href + "&_flex-nw=True&_flex-md=True&DisableSaveAndCloseBtn=true&DisableCloseBtn=true";
                if (btn.dataset.currentDate != null) {
                    URL += "&date=" + btn.dataset.currentDate;
                }
            };
            var calendarModal = $.ics.dialog.modal({
                href: URL,
                modal: false,
                width: 700,
                height: 600
            });
            $('#CalendarView').data("CalendarModal", calendarModal);
        },
        /**
         * Метод закрывает окно редактирования дня-исключения
         */
        closeEditForm : function(){
            var calendarModal = $('#CalendarView').data("CalendarModal");
            calendarModal.close();
        },
        /**
         * Метод убирает день-исключение из html-разметки календаря с учетом повторений
         * 
         * @param dayId идентификатор дня-исключения
         */
        deleteDay : function(day){
            var date = new Date(day.StartDate);
            var dayEnd = new Date(day.EndDate);

            if (dayEnd === null) {
                for (i = 0; i < day.RecurrenceCount; i++) {
                    methods.markDay(date, day, false);
                }
            } else {
                while (date <= dayEnd) {
                    methods.markDay(date, day, false);
                }
            }
        },
        /**
         * Метод отображает день-исключение на html-разметке календаря с учётом повторений
         * 
         * @param dayId идентификатор дня-исключения
         */
        splitDay: function (day) {
            var date = new Date(day.StartDate);
            var dayEnd = new Date(day.EndDate);
            if (dayEnd === null) {
                for (i = 0; i < day.RecurenceCount; i++) {
                    methods.markDay(date, day, true);
                }
            } else {
                while (date <= dayEnd) {
                    methods.markDay(date, day, true);
                }
            }
        },
        /**
         * Метод помечает, либо убирает отметку о дне-исключении  в html - разметке календаря в зависимости от выбранной опции
         * 
         * @param date дата дня-исключения
         * 
         * @param dayId идентификатор дня-исключения
         * 
         * @param Option true - пометить как день исключение, false - убрать отметку
         * 
         */
        markDay: function(date, day, Option){
            var stringDate = date.getTime();
            if (Option) {
                $("button[data-current-date=\"" + stringDate + "\"]").data("day-id", day.PrimaryKey);
                var btn = $("button[data-current-date=\"" + stringDate + "\"]")[0];
                if(btn){
                    btn.dataset.title = day.Name;
                }
                $("button[data-current-date=\"" + stringDate + "\"]").addClass("holiday");
            } else {
                $("button[data-current-date=\"" + stringDate + "\"]").data("day-id", "");
                $("button[data-current-date=\"" + stringDate + "\"]").removeClass("holiday");
            }
            switch (day.RecurrenceType) {
                case "Daily":
                    date.setDate(date.getDate() + day.RepeatStep);
                    break
                case "Weekly":
                    date.setDate(date.getDate() + day.RepeatStep * 7);
                    break
                case "Monthly":
                    date.setMonth(date.getMonth() + day.RepeatStep);
                    break
                case "Yearly":
                    date.setFullYear(date.getFullYear() + day.RepeatStep);
                    break
                default:
            }
        },
        /**
         * Метод отображает в html - разметке календаря информацию об имеющихся днях-исключениях
         * 
         */
        refreshCalendar: function (days) {
            var dLength = days.length;
            for(var i=0;i<dLength;i++){
                methods.splitDay(days[i]);
            }
        },
        getMethod:function(methodName){
            return methods.methodName;
        },
        /**
         * Метод для инициализации плагина
         */
        init: function(args){
            return this.each(function(){
                var dateNow = new Date(Date.now());
                attributes.curMonth = dateNow.getMonth();
                attributes.curYear = dateNow.getFullYear();
                methods.createCalendar(methods.getFirstDate(attributes.curYear,attributes.curMonth),attributes.month[attributes.curMonth],this,args);
                methods.refreshCalendar(methods.getExcDayArray(args));
            })
        }
    }
    /**
     * Плагин BusinessCalendar
     * 
     * @param method название метода плагина, который необходимо вызвать
     */
  $.fn.CalendarView = function(method) {
        if( methods[method] ){
            return methods[method].apply(this,Array.prototype.slice.call(arguments,1));
        } else if (!method){
            return methods.init.apply(this);
        } else {
            $.error('Метод с именем ' + method + ' не существует для JQuery.BusinessCalendar');
        }
  };
})(jQuery);