(function ($) {

    var attr = {
        timeSpans: [],
        idElemToStore:"",
        status : {
            Altered : 1,
            UnAltered : 0
        },
        currentStatus : 0
    }

    var methods = {

        /**
         * Метод для создания таблицы временных промежутков
         * @param container
         * 
         */
        craateTable: function (container) {
            var table = document.createElement("table");
            table.id = "TimeSpansTable";
            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            tr.setAttribute("class", "colorStandart textMiddle");
            var th1 = document.createElement("th");
            th1.setAttribute("class", "textMiddle timeCell borderStandart");
            th1.innerText = "Время начала(чч:мм)";
            var th2 = document.createElement("th");
            th2.setAttribute("class", "textMiddle timeCell borderStandart");
            th2.innerText = "Время окончания(чч:мм)";
            var th3 = document.createElement("th");
            th3.setAttribute("class", "smallCell borderStandart");
            var btnAddRow = document.createElement("button");
            btnAddRow.id = "btnAddTS";
            btnAddRow.type = "button";
            btnAddRow.setAttribute("class", "glyphiconStyle glyphicon-plus iconSmall background-center btnStandart btnSmall");
            btnAddRow.onclick = function () {
                methods.addRow(container, "", "", "", "");
                attr.currentStatus = attr.status.Altered;
            }
            th3.appendChild(btnAddRow);
            var tbody = document.createElement("tbody");

            tr.appendChild(th1);
            tr.appendChild(th2);
            tr.appendChild(th3);
            thead.appendChild(tr);
            table.appendChild(thead);
            table.appendChild(tbody);

            if (container[0].firstChild !== null) {
                container[0].removeChild(container.firstChild);
            }
            container[0].appendChild(table);
        },
        /**
         * Метод для преобразования строки JSON в объект
         * @param {string} jsonArray
         */
        readDataFromHidden: function () {
            if (attr.idElemToStore !== "") {
                var tsString = $('#' + attr.idElemToStore).val();
                attr.timeSpans = JSON.parse(tsString);
            }
        },
        /**
         * Метод добавляет одну строку в таблицу временных промежутков
         * @param {number} upTimeH
         * @param {number} upTimeM
         * @param {number} endTimeH
         * @param {number} endTimeM
         * @param {number} container
         */
        addRow: function (container,upTimeH, upTimeM, endTimeH, endTimeM) {
            var table = document.getElementById('TimeSpansTable');
            var i = table.rows.length;
            var tempTr = ('<tr id="tr_' + i + '">\
                                <td class="textMiddle timeCell borderGray">\
                                    <input type="number" value=\"' + upTimeH + '\" name="upTimeH" id="startTime_' + i + '" class="textStandart inputSmall inputHour"/>\
                                    <span style="vertical-align: sub; font-weight:bold;">:</span>\
                                    <input type="number"  value=\"'+ upTimeM + '\" name="upTimeM" id="startTimeM_' + i + '" class="textStandart inputSmall inputMinutes"/>\
                                </td>\
                                <td class="textMiddle timeCell borderGray">\
                                    <input name="endTimeH" type="number" value=\"' + endTimeH + '\"  id="endTime_' + i + '" class="textStandart inputSmall inputHour"/>\
                                    <span style="vertical-align: sub; font-weight:bold;">:</span>\
                                    <input name="endTimeM" type="number" value=\"' + endTimeM + '\" id="endTimeM_' + i + '"  class="textStandart inputSmall inputMinutes"/>\
                                </td>\
                                <td class="textMiddle smallCell borderGray">\
                                    <button type="button" class="glyphiconStyle glyphicon-minus background-center btnStandart btnSmall delTS" id="workTimeSpan_' + i + '" tabindex="-1"></button>\
                                </td>\
                            </tr>');
            $(container).find('tbody').append(tempTr);
            $(container).find('tbody').find('input').keyup(function () {
                attr.currentStatus = attr.status.Altered;
                methods.storeData.apply(container);
            });
            $(container).find('tbody').find('button').on("click", function () {
                $(this).closest('tr').remove();
                attr.currentStatus = attr.status.Altered;
            })
        },
        /**
         * Метод для заполнения таблицы временных промежутков
         * @param {DOM} container
         */
        fillTable: function () {
            var tsCount = attr.timeSpans.length;
            for (var i = 0; i < tsCount; i++) {
                methods.addRow(this, attr.timeSpans[i].StartTimeH, attr.timeSpans[i].StartTimeM, attr.timeSpans[i].EndTimeH, attr.timeSpans[i].EndTimeM);
            }
            attr.currentStatus = attr.status.UnAltered;
        },
        /**
         * Функция считывает временные промежутки с таблицы
         * @param {DOM} container 
         * @returns {Array} 
         */
        getTimeSpans: function () {
            var result = [];
            var tbody = this[0].getElementsByTagName("tbody")[0];
            var rowsCount = tbody.rows.length;
            for (var i = 0; i < rowsCount; i++) {
                var row = tbody.rows[i];
                result.push({
                    StartTimeH: $(row).find('input[name=\"upTimeH\"]').val(),
                    StartTimeM: $(row).find('input[name=\"upTimeM\"]').val(),
                    EndTimeH: $(row).find('input[name=\"endTimeH\"]').val(),
                    EndTimeM: $(row).find('input[name=\"endTimeM\"]').val()
                })
            }
            return result;
        },
        /**
         * Метод для инициализации таблицы временных промежутков
         * @param {string} jsonArray строка с массивом JSON
         * @param {DOM} container таблица временных промежутков
         */
        init: function (idElemToStore) {
            attr.idElemToStore(idElemToStore);
            methods.readDataFromHidden();
            methods.craateTable(this);
            methods.fillTable(this);      
        },
        /**
         * Функция возвращает текущее состояние объекта
         * @returns {Number} 1 - изменён, 0 - не изменён
         */
        getStatus: function() {
            return attr.currentStatus;
        },
        /**
         * Функция для установления идентификатора элемента, в значении которого будут храниться временные промежутки в сериализованном виде (JSON массиве)
         * @param {String} elementId
         */
        setIdElemToStore: function (elementId) {
            attr.idElemToStore = elementId;
        },
        /**
         * Функция сохраняет 
         */
        storeData: function() {
            $('#' + attr.idElemToStore).val() = JSON.stringify(methods.getTimeSpans.apply(this));
        }
    }
    /**
     * Плагин для работы с временными промежутками
     * @param {string} метод плагина
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
