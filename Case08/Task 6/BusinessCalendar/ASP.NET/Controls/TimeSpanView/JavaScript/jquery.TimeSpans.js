(function ($) {

    var attr = {
        timeSpans: [],
        status : {
            Altered : 1,
            UnAltered: 0
        }
    }

    var methods = {

        /**
         * Метод для создания таблицы временных промежутков(шапки таблицы)
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
            var tbody = document.createElement("tbody");
            var sourceControl = document.getElementById(this[0].dataset.sourceControl);
            var statusControl = document.getElementById(this[0].dataset.statusControl);
            th3.onclick = function () {
                methods.addRow(tbody,sourceControl,statusControl,"", "", "", "");
            }
            

            tr.appendChild(th1);
            tr.appendChild(th2);
            tr.appendChild(th3);
            thead.appendChild(tr);
            table.appendChild(thead);
            table.appendChild(tbody);

            
            if (this[0].firstChild !== null) {
                this[0].removeChild(this[0].firstChild);
            }
            this[0].appendChild(table);
        },
        /**
         * Метод считывает временные промежутки со скрытого поля
         *@param {DOM} контрол для хранения json-массива временных промежутков
         */
        readDataFromHidden: function (sourceControl) {
            if (sourceControl !== {}) {
                var tsString = sourceControl.value;
                if (tsString !== "") {
                    attr.timeSpans = JSON.parse(tsString);
                }
            }
        },
        /**
         * Метод добавляет одну строку в таблицу временных промежутков
         * @param {DOM} тело таблицы временных промежутков
         * @param {DOM} контрол для сохранения массива временных промежутков
         * @param {DOM} контрол для установки текущего статуса
         * @param {number} upTimeH часы начала
         * @param {number} upTimeM минуты начала
         * @param {number} endTimeH часы окончания
         * @param {number} endTimeM минуты окончания
         */
        addRow: function (tableBody, sourceControl, statusControl, upTimeH, upTimeM, endTimeH, endTimeM) {
            var i = tableBody.rows.length;

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
                statusControl.value = attr.status.Altered;
                methods.storeData(tableBody,sourceControl,statusControl);
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
                statusControl.value = attr.status.Altered;
                methods.storeData(tableBody, sourceControl, statusControl);
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
                statusControl.value = attr.status.Altered;
                methods.storeData(tableBody, sourceControl, statusControl);
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
                statusControl.value = attr.status.Altered;
                methods.storeData(tableBody, sourceControl, statusControl);
            }

            td2.appendChild(txtEndTimeH);
            td2.appendChild(span1);
            td2.appendChild(txtEndTimeM);

            var td3 = document.createElement("td");
            td3.setAttribute("class", " textMiddle background-center btn-standart font-big border-aqua");
            td3.innerText = "-";
            td3.onclick = function () {
                $(td3).closest('tr').remove();
                statusControl.value = attr.status.Altered;
                methods.storeData(tableBody, sourceControl, statusControl);
            }

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);

            tableBody.appendChild(tr);
        },
        /**
         * Метод для заполнения таблицы временных промежутков
         * @param {DOM} tableBody тело таблицы временных промежутков
         * @param {DOM} souceControl контрол для записи массива временных промежутков
         * @param {DOM} statusControl контрол для записи статуса таблицы временных промежутков
         */
        fillTable: function (tableBody,sourceControl,statusControl) {
            var tsCount = attr.timeSpans.length;
            for (var i = 0; i < tsCount; i++) {
                methods.addRow(tableBody, sourceControl, statusControl, attr.timeSpans[i].StartTimeH, attr.timeSpans[i].StartTimeM, attr.timeSpans[i].EndTimeH, attr.timeSpans[i].EndTimeM);
            }
            statusControl.value = attr.status.UnAltered;
        },
        /**
         * Функция считывает временные промежутки с таблицы
         * @param {DOM} tableBody тело таблицы временных промежутков 
         * @returns {Array} массив временных промужутков
         */
        readDataFromView: function (tableBody) {
            var result = [];
            if (tableBody.rows != null)
            {
                var tbody = tableBody;
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
            }
            return result;
        },
        /**
         * Метод удаляет все временные промежутки
         */
        dispose: function () {
            this.find('tbody')[0].innerHTML = "";
            var tableContainer = this.find('.TSVContainer')[0];
            var sourceControl = document.getElementById(tableContainer.dataset.sourceControl);
            var statusControl = document.getElementById(tableContainer.dataset.statusControl);
            if (attr.timeSpans == false) {
                statusControl.value = attr.status.UnAltered;
            } else {
                statusControl.value = attr.status.Altered;
            }
            attr.timeSpans = [];
            methods.storeData({}, sourceControl, statusControl);
            return this;
        },
        /**
        * Метод скрывает контрол на разметке
        */
        hide:function(){
            this.addClass('hide');
        },
        /**
        * Метод показывает контрол на разметке
        */
        show:function(){
            this.removeClass('hide');
        },
        /**
         * Метод для инициализации таблицы временных промежутков
         * @param {DOM} elemToStore таблица временных промежутков
         */
        init: function (sourceControl, statusControl) {
            this[0].setAttribute('data-source-control', sourceControl.id);
            this[0].setAttribute('data-status-control', statusControl.id);
            methods.create.apply(this);
            methods.readDataFromHidden(sourceControl);
            methods.fillTable(this.find('tbody')[0],sourceControl,statusControl);
        },
        /**
         * Функция сохраняет массив временных промежутков в скрытом поле
         * @param {DOM} тело таблицы временных промежутков
         * @param {DOM} контрол для записи массива временных промежутков
         * @param {DOM} контрол для записи текущего состояния таблицы временных промежутков
         */
        storeData: function (tableBody,sourceControl,statusControl) {
            attr.timeSpans = methods.readDataFromView(tableBody);
            $(sourceControl).val(JSON.stringify(attr.timeSpans));
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
