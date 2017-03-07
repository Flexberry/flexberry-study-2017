(function( $ ) {
    methods = {
        /**
         * Функция проверяет число на целочисленное значение
         * 
         * @param value проверяемое число
         * 
         * @returns {boolean}
         */
        testForInteger : function(value){
            var intVal = parseInt(value);
            if (value == intVal){
                return true;
            } else {
                return false;
            }
        },
        /**
         * Функция проверяет строку на пустое значение
         * 
         * @param value проверяемая строка
         * 
         * @returns {boolean}
         */
        testForEmpty : function(value){
            if(value.trim().length > 0){
                return true;
            } else {
                return false;
            }
        },
        /**
         * Функция проверяет число на неотрицательное значение
         * 
         * @param value проверяемое числло
         * 
         * @returns {boolean}
         */
        testForPositive :function(value){
            if(value >= 0){
                return true;
            } else {
                return false;
            }
        },
        /**
         * Функция проверяет число на неотризательное целочисленное значение
         * 
         * @param value проверяемое число
         * 
         * @returns {boolean}
         */
        testForPositiveInt : function(value){
            var val = this;
            var valid = false;
            if(methods.testForEmpty(value)){
                if(methods.testForInteger(value)){
                    if(value > 0) {
                        valid =  true;
                    }
                }
            } 
            return valid;
        },
        /**
         * Функция проверяет является ли число часом
         * 
         * @param value проверяемое число
         * 
         * @returns {Boolean}
         */
        testForHour : function(value){
            var valid = false;
            if(methods.testForEmpty(value)){
                if(methods.testForInteger(value))
                    if(methods.testForPositive(value)){
                        if(value < 24){
                            valid = true;
                        }
                    }
            }
            return valid;
        },
        /**
         * Функция проверяет является ли значение числом минут
         * 
         * @param value проверяемое значение
         * 
         * @returns {boolean}
         */
        testForMinutes : function(value){
            var valid = false;
            if(methods.testForEmpty(value)){
                if(methods.testForInteger(value))
                    if(methods.testForPositive(value)){
                        if(value < 60){
                            valid = true;
                        }
                    }
            }
            return valid;
        },
        /**
         * Функция проверяет значение на правильный формат даты
         * 
         * @param value строка даты
         * 
         * @returns {boolean}
         */
        testForDate : function(value){
            var valid = false;
            if(methods.testForEmpty(value)){
                var upDayArr = value.split('.');
                var upDayDate = new Date(upDayArr[2],(upDayArr[1]-1),upDayArr[0]);
                if(value == (upDayDate.getDate() + '.' + (upDayDate.getMonth()+1) + '.' + upDayDate.getFullYear())){
                    valid = true;
                }
            }
            return valid;
        },
    }
    /**
     * @param method Функция валидирования
     * 
     * @param args Передаваемые параметры для нужной функции
     */
  $.fn.validate = function(method) {
        if( methods[method]){
            return methods[method](this.val());
        } else {
            $.error('Метод с именем ' + method + ' не существует для JQuery.validate');
        }
  };
})(jQuery);