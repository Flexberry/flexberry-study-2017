namespace AjaxCorporation.LostFound.MessagesAnalysis
{
    using System;

    /// <summary>
    /// Статистический класс, предназначенный для сравнения полученных
    /// сообщений о пропавших/найденных животных, вещах.
    /// </summary>
    public static class MessagesCompare
    {
        // Проверка соответствия сообщений в виде массива строк.
        public static double Compare(string[] lost, string[] found)
        {
            // Проверка полученного массива о потерянном на null.
            // Если элементы массива отсутствуют, вывести исключение.
            if (lost == null)
            {
                throw new ArgumentNullException(nameof(lost), "Массив lost не заполнен.");
            }

            // Проверка полученного массива о найденном на null.
            // Если элементы массива отсутствуют, вывести исключение.
            if (found == null)
            {
                throw new ArgumentNullException(nameof(found), "Массив found не заполнен.");
            }

            // Получение дин массивов для последующей проверки на равенство их длин.
            int lenghtLost = lost.Length;
            int lenghtFound = found.Length;

            // Длина проверяемого массива. Проверка корректна при совпадении длин
            // обоих массивов, поэтому присвоение производится по длине первого.
            int messagesElementsCount = lenghtLost;

            // Счетчик совпадений элементов массивов.
            double countMatches = 0;

            // Процент полученных совпадений элементов массивов.
            double equalityPercent = 0;

            // Проверка совпадения длин массивов.
            // Если массивы неравны, вывести исключение.
            if (lenghtLost != lenghtFound)
            {
                throw new Exception("Массивы, сообщающие о пропаже или находке, должны иметь одинаковое количество элементов. Сравнение невозможно.");
            }

            // Обработка типа сообщений для массива (элемент 0).
            // Получение нулевого элемента массива.
            string typeMessageLost = lost[0]?.Trim()?.ToLower();
            string typeMessageFound = found[0]?.Trim()?.ToLower();

            // Проверка нулевого элемента на null.
            bool isTypeMessageLostEmpty = string.IsNullOrEmpty(typeMessageLost);
            bool isTypeMessageFoundEmpty = string.IsNullOrEmpty(typeMessageFound);

            // Если тип сообщения (нулевой элемент массива) не заполнен,
            // вывести исключение.
            if (isTypeMessageLostEmpty || isTypeMessageFoundEmpty)
            {
                throw new Exception("Тип сообщения (Пропажа/Находка) не заполнен.");
            }

            // Проверка существования обязательного поля "Тип сообщения".
            // Тип сообщения можнт быть "Потеряно" или "Найдено".
            // Контрольные типы сообщений.
            string messageLost = "Потеряно";
            string messageFound = "Найдено";

            // Если тип сообщения из массива не соответствует контрольному,
            // вывести исключение.
            if (typeMessageLost != messageLost.ToLower() || typeMessageFound != messageFound.ToLower())
            {
                throw new Exception("Тип сообщения не существует.");
            }

            // Обработка даты для массива (элемент 3).
            // Получение третьего элемента массива.
            // Необходимо для приведения даты к единому формату.
            string dateLost = lost[3]?.Trim()?.ToLower();
            string dateFound = found[3]?.Trim()?.ToLower();

            // Переменная для проверки равенства третьих элементов массивов (даты).
            bool isdateCorrectEqual = false;

            // Проверка третьего элемента на null.
            bool isdateLostEmpty = string.IsNullOrEmpty(dateLost);
            bool isdateFoundEmpty = string.IsNullOrEmpty(dateFound);

            // Если тип сообщения (нулевой элемент массива) не заполнен,
            // вывести исключение.
            if (isdateLostEmpty || isdateFoundEmpty)
            {
                throw new Exception("Дата сообщения не заполнена.");
            }

            if (lenghtLost == lenghtFound)
            {
                // Переменная, в которую вернется распарсенная дата.
                DateTime dateLostValue;
                DateTime dateFoundValue;

                // Приведение даты к формату DateTime.
                DateTime.TryParse(dateLost, out dateLostValue);
                DateTime.TryParse(dateFound, out dateFoundValue);

                // Проверка полученных дат на идентичность,
                // с целю включения в подсчет совпадений элементов массива
                // или исключения из него.
                isdateCorrectEqual = Equals(dateLostValue, dateFoundValue);
            }

            // Если длина массивов совпадает, провести проверку на соответствие
            // полученных строк. Из расчетов исключаются пустые строки.
            if (lenghtLost == lenghtFound)
            {
                for (int i = 1; i < messagesElementsCount; i++)
                {
                    for (int j = 1; j < messagesElementsCount; j++)
                    {
                        // Пропуск третьего элемента массива,
                        // так как он обрабатывается отдельно.
                        if (i == 3 && j == 3)
                        {
                            continue;
                        }

                        // Значения элементов массивов для проверки идентичности
                        // и подсчета количества совпадений.
                        var lostMessageElement = lost[i]?.Trim()?.ToLower();
                        var foundMessageElement = found[j]?.Trim()?.ToLower();

                        // Проверка элементов массива на null (такие элементы исключаются из подсчета совпадений).
                        bool isLostMessageElementEmpty = string.IsNullOrEmpty(lostMessageElement);
                        bool isFoundMessageElementEmpty = string.IsNullOrEmpty(foundMessageElement);

                        // Если элемены совпали, увеличить счетчик совпадений на 1.
                        if (lostMessageElement == foundMessageElement && !isLostMessageElementEmpty && !isFoundMessageElementEmpty)
                        {
                            countMatches = countMatches + 1;
                        }
                    }
                }

                // Если даты равны, включить в подсчет совпадений элементов массива.
                if (isdateCorrectEqual)
                {
                    countMatches = countMatches + 1;
                }

                // Константа для обозначения 100%.
                const int fullPercent = 100;

                // Подсчет процента совпадений в массивах по результатам сравнения.
                equalityPercent = (countMatches * fullPercent / (messagesElementsCount - 1));

                // Если процент совпадений больше 100 (в случае наличия идентичных элементов в отдельном массиве),
                // установить процент равный 100.
                if (equalityPercent > fullPercent)
                {
                    equalityPercent = fullPercent;
                }
            }

            return equalityPercent;
        }
    }
}
