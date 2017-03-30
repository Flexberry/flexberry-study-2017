(function ($) {

    var attr = {
        timeSpans: [],
        elemToStore: {},
        inputStatus: {},
        table: {},
        tableBody: {},
        tableParent: {},
        status : {
            Altered : 1,
            UnAltered : 0
        },
        currentStatus : 0
    }

    var methods = {

        /**
         * Метод для создания таблицы временных промежутков
         * 
         */
        create: function () {
            var table = document.createElement("table");
            table.id = "TimeSpansTable";
            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            tr.setAttribute("class", "colorStandart textMiddle");
            var th1 = document.createElement("th");
            th1.setAttribute("class", "textMiddle timeCell border-standart");
            th1.innerText = "Время начала(чч:мм)";
            var th2 = document.createElement("th");
            th2.setAttribute("class", "textMiddle timeCell border-standart");
            th2.innerText = "Время окончания(чч:мм)";
            var th3 = document.createElement("th");
            th3.setAttribute("class", "textMiddle smallCell background-center btn-add border-standart font-big");
            th3.innerText = "+";
            th3.onclick = function () {
                methods.addRow("", "", "", "");
            }
            var tbody = document.createElement("tbody");

            tr.appendChild(th1);
            tr.appendChild(th2);
            tr.appendChild(th3);
            thead.appendChild(tr);
            table.appendChild(thead);
            table.appendChild(tbody);

            if (attr.tableParent.firstChild !== null) {
                attr.tableParent.removeChild(attr.tableParent.firstChild);
            }
            attr.tableParent.appendChild(table);
            attr.table = table;
            attr.tableBody = tbody;
        },
        /**
         * Метод считывает временные промежутки со скрытого поля
         */
        readDataFromHidden: function () {
            if (attr.elemToStore !== {}) {
                var tsString = attr.elemToStore.value;
                if (tsString !== "") {
                    attr.timeSpans = JSON.parse(tsString);
                }
            }
        },
        /**
         * Метод добавляет одну строку в таблицу временных промежутков
         * @param {number} upTimeH часы начала
         * @param {number} upTimeM минуты начала
         * @param {number} endTimeH часы окончания
         * @param {number} endTimeM минуты окончания
         * @param {number} container
         */
        addRow: function (upTimeH, upTimeM, endTimeH, endTimeM) {
            var i = attr.table.rows.length;

            var tr = document.createElement("tr");
            tr.id = "tr_" + i;

            var td1 = document.createElement("td");
            td1.setAttribute("class", "textMiddle timeCell border-gray");

            var txtUpTimeH = document.createElement("input");
            txtUpTimeH.type = "number";
            txtUpTimeH.maxLength = "2";
            txtUpTimeH.value = upTimeH;
            txtUpTimeH.name = "upTimeH";
            txtUpTimeH.setAttribute("class", "textStandart inputSmall inputHour");
            txtUpTimeH.id = "startTime_" + i;
            txtUpTimeH.onchange = function () {
                attr.currentStatus = attr.status.Altered;
                methods.storeData();
            }

            var span = document.createElement("span");
            span.setAttribute("class", "span-standart");
            span.innerHTML = ":";

            var txtUpTimeM = document.createElement("input");
            txtUpTimeM.type = "number";
            txtUpTimeM.maxLength = "2";
            txtUpTimeM.value = upTimeM;
            txtUpTimeM.name = "upTimeM";
            txtUpTimeM.setAttribute("class", "textStandart inputSmall inputHour");
            txtUpTimeM.id = "startTimeM_" + i;
            txtUpTimeM.onchange = function () {
                attr.currentStatus = attr.status.Altered;
                methods.storeData();
            }

            td1.appendChild(txtUpTimeH);
            td1.appendChild(span);
            td1.appendChild(txtUpTimeM);

            var td2 = document.createElement("td");

            td2.setAttribute("class", "textMiddle timeCell border-gray");

            var txtEndTimeH = document.createElement("input");
            txtEndTimeH.type = "number";
            txtEndTimeH.maxLength = "2";
            txtEndTimeH.value = endTimeH;
            txtEndTimeH.name = "endTimeH";
            txtEndTimeH.setAttribute("class", "textStandart inputSmall inputHour");
            txtEndTimeH.id = "startTime_" + i;
            txtEndTimeH.onchange = function () {
                attr.currentStatus = attr.status.Altered;
                methods.storeData();
            }

            var span1 = document.createElement("span");
            span1.setAttribute("class", "span-standart");
            span1.innerHTML = ":";

            var txtEndTimeM = document.createElement("input");
            txtEndTimeM.type = "number";
            txtEndTimeM.maxLength = "2";
            txtEndTimeM.value = endTimeM;
            txtEndTimeM.name = "endTimeM";
            txtEndTimeM.setAttribute("class", "textStandart inputSmall inputHour");
            txtEndTimeM.id = "startTimeM_" + i;
            txtEndTimeM.onchange = function () {
                attr.currentStatus = attr.status.Altered;
                methods.storeData();
            }

            td2.appendChild(txtEndTimeH);
            td2.appendChild(span1);
            td2.appendChild(txtEndTimeM);

            var td3 = document.createElement("td");
            td3.setAttribute("class", " textMiddle background-center btn-standart font-big border-aqua");
            td3.innerText = "-";
            td3.onclick = function () {
                $(td3).closest('tr').remove();
                attr.currentStatus = attr.status.Altered;
                methods.storeData();
            }

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);

            attr.tableBody.appendChild(tr);
        },
        /**
         * Метод для заполнения таблицы временных промежутков
         */
        fillTable: function () {
            var tsCount = attr.timeSpans.length;
            for (var i = 0; i < tsCount; i++) {
                methods.addRow(attr.timeSpans[i].StartTimeH, attr.timeSpans[i].StartTimeM, attr.timeSpans[i].EndTimeH, attr.timeSpans[i].EndTimeM);
            }
            attr.currentStatus = attr.status.UnAltered;
        },
        /**
         * Функция считывает временные промежутки с таблицы
         * @param {DOM} container 
         * @returns {Array} 
         */
        readDataFromView: function () {
            var result = [];
            var tbody = attr.tableBody;
            var rowsCount = tbody.rows.length;
            for (var i = 0; i < rowsCount; i++) {
                var row = tbody.rows[i];
                var stH = $(row).find('input[name=\"upTimeH\"]').val();
                var stM = $(row).find('input[name=\"upTimeM\"]').val();
                var etH = $(row).find('input[name=\"endTimeH\"]').val();
                var etM = $(row).find('input[name=\"endTimeM\"]').val();
                if (!((stH === "") || (stM === "") || (etH === "") || (etM === ""))) {
                    result.push({
                        StartTimeH: stH,
                        StartTimeM: stM,
                        EndTimeH: etH,
                        EndTimeM: etM
                    })
                }
            }
            return result;
        },
        /**
         * Метод удаляет все временные промежутки
         */
        dispose: function(){
            attr.tableParent.innerHTML = "";
            attr.table = {};
            attr.tableBody = {};
            attr.elemToStore.value = "";
            attr.inputStatus.value = attr.status.Altered;
            attr.timeSpans = [];
        },
        /**
         * Метод для инициализации таблицы временных промежутков
         * @param {DOM} elemToStore таблица временных промежутков
         */
        init: function (elemToStore, inputStatus) {
            attr.elemToStore = elemToStore;
            attr.inputStatus = inputStatus;
            attr.currentStatus = attr.status.UnAltered;
            attr.tableParent = this[0];

            methods.create();
            methods.readDataFromHidden();
            methods.fillTable.apply(this);
        },
        /**
         * Функция возвращает текущее состояние объекта
         * @returns {Number} 2 - сохранён, 1 - изменён, 0 - не изменён
         */
        getStatus: function() {
            return attr.currentStatus;
        },
        /**
         * Функция сохраняет массив временных промежутков в скрытом поле
         */
        storeData: function () {
            attr.timeSpans = methods.readDataFromView();
            $(attr.elemToStore).val(JSON.stringify(attr.timeSpans));
            $(attr.inputStatus).val(attr.currentStatus);
            return;
        }
    }
    /**
     * Плагин для работы с временными промежутками
     * @param {string} название вызываемого метода плагина
     */
    $.fn.TimeSpans = function (method) {
        if (method) {
            var result = methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else {
            $.error('Метод с именем ' + method + ' не существует для JQuery.TimeSpans');
        }
        return result;
    }
})(jQuery);
