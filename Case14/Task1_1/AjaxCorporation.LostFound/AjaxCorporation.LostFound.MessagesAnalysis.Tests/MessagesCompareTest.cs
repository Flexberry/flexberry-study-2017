namespace AjaxCorporation.LostFound.MessagesAnalysis.Tests
{
    using AjaxCorporation.LostFound.MessagesAnalysis;
    using System;
    using Xunit;

    /// <summary>
    /// Проверка корректности сравнения двух массивов строк
    /// соообщений о найденных/потерянных объектах.
    /// Для всех тестов исключена обработка первых элементов массива,
    /// тк они всегда различны и статично заданы (типы сообщений найдено/потеряно).
    /// </summary>
    public class MessagesCompareTest
    {
        // Проверка случая с полностью идентичными массивами строк.
        [Fact]
        public void FullArrayEqual()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            // При полной идентичности массивов строк совпадение должно равняться 100%.
            double expectedPercent = MessagesCompare.fullPercent;

            // Act.
            double actualPercent = MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);

        }

        // Проверка обработки пробелов: пробелы исключаются из цикла сопоставления.
        [Fact]
        public void SpaceInArrayEqual()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка ", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", " Кошка", "Ивановская, 4 ", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", " Белая с рыжими и черными пятнами" };

            // При полной идентичности массивов строк совпадение должно равняться 100%.
            double expectedPercent = MessagesCompare.fullPercent;

            // Act.
            double actualPercent = MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);

        }

        // Проверка обработки разницы в регистре начертания слов:
        // значения в цикле сопоставления переведены в нижний регистр.
        [Fact]
        public void WordRegisterArrayEqual()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "КошкА", "ивановская, 4", "01.02.2000", "ЖивОТное", "ПЯТНИСТАЯ", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "маленькая", "Беспородная", " Белая с рыжими и черными пятнами" };

            // При полной идентичности массивов строк совпадение должно равняться 100%.
            double expectedPercent = MessagesCompare.fullPercent;

            // Act.
            double actualPercent = MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);

        }

        // Проверка случая с частичным совпадением массвов строк (пустые строки (null) в первом массиве).
        [Fact]
        public void NullElementLost()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", " ", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", " " };

            string[] found = new string[9] { "Найдено", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            // В данном случае массивы отличаются в две строки, процент совпадения
            // равен 75 (при приведении к целому).
            double expectedPercent = 75;

            // Act.
            double actualPercent = (int)MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);
        }

        // Проверка случая с частичным совпадением массвов строк (пустые строки (null) во втором массиве).
        [Fact]
        public void NullElementFound()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Кошка", " ", "01.02.2000", "Животное", "Пятнистая", "Маленькая", " ", " " };

            // В данном случае массивы отличаются в две строки, процент совпадения
            // равен 62 (при приведении к целому).
            double expectedPercent = 62;

            // Act.
            double actualPercent = (int)MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);
        }

        // Проверка случая с полностью отличными массивами строк.
        [Fact]
        public void FullArrayNotEqual()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            // При полном различии массивов строк совпадение должно равняться 0%.
            double expectedPercent = 0;

            // Act.
            double actualPercent = MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);

        }

        // Проверка случая с полностью идентичными массивами строк,
        // когда содержание строк перепутано местами.
        [Fact]
        public void ValuesReversedEqual()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "01.02.2000", "Животное", "Кошка", "Ивановская, 4", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            // При полной идентичности массивов строк совпадение должно равняться 100%.
            double expectedPercent = MessagesCompare.fullPercent;

            // Act.
            double actualPercent = MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);
        }

        // Проверка случая, когда большинство строк равны null.
        [Fact]
        public void FullFewElement()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Сумка", "", "01.02.2000", "", "", "", "", "" };

            string[] found = new string[9] { "Найдено", "Сумка", "", "01.02.2000", "", "", "", "", "" };

            // Строки равные null исключаются из подсчета совпадений,
            // в заданных условиях идентичны 2 строки (2 совпадения),
            // поэтому процент при приведении к целому должен равняться 25%.
            double expectedPercent = 25;

            // Act.
            double actualPercent = (int)MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);
        }

        // Проверка случая, когда все строки в массиве идентичны,
        // сами массивы строк также идентичны.
        [Fact]
        public void SameArraysElements()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно" };

            string[] found = new string[9] { "Найдено", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно", "Потеряно" };

            // Если 2 и более строки в массивах совпадают, то итоговый процент может превысить 100%,
            // задано условие, что в таких случаях процент совпадения считать равным 100%.
            double expectedPercent = MessagesCompare.fullPercent;

            // Act.
            double actualPercent = MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);
        }

        // Проверка обработки массивов с разной длиной.
        // Должно быть выброшено исключение.
        [Fact]
        public void ArraysLenghtNotEqual()
        {
            // Arrange.
            string[] lost = new string[10] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами", "" };

            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            // Act.
            var exeption = Assert.Throws<Exception>(() => MessagesCompare.Compare(lost, found));

            // Assert.
            // Проверяется не только вызов исключения, но и его контекст.
            Assert.Contains("Массивы, сообщающие о пропаже или находке, должны иметь одинаковое количество элементов. Сравнение невозможно.", exeption.Message);
        }

        // Проверка случая, когда первый массив (lost) null.
        [Fact]
        public void LostNull()
        {
            // Arrange.
            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            // Act.
            var exeption = Assert.Throws<ArgumentNullException>(() => MessagesCompare.Compare(null, found));

            // Assert.
            // Проверяется не только вызов исключения, но и его контекст.
            Assert.Contains("Массив lost не заполнен.", exeption.Message);
        }

        // Проверка случая, когда второй массив (found) null.
        [Fact]
        public void FoundNull()
        {
            // Arrange.
            string[] lost = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            // Act.
            var exeption = Assert.Throws<ArgumentNullException>(() => MessagesCompare.Compare(lost, null));

            // Assert.
            // Проверяется не только вызов исключения, но и его контекст.
            Assert.Contains("Массив found не заполнен.", exeption.Message);
        }

        // Проверка случая, когда оба массива равны null.
        [Fact]
        public void ArraysNull()
        {
            // Arrange.
            // Массивы не заданы.

            // Объявление переменной для перехвата исключения.
            bool exeptionCalled = false;

            // Act & assert.
            // Вызов метода и перехват исключения.
            try
            {
                MessagesCompare.Compare(null, null);
            }
            catch (ArgumentNullException exception)
            {
                exeptionCalled = true;
            }

            // При корректной работе должно быть вызвано исключение.
            Assert.True(exeptionCalled);
        }

        // Проверка случая, когда обязательное поле (тип сообщения) null.
        [Fact]
        public void TypeMessageNull()
        {
            // Arrange.
            string[] lost = new string[9] { " ", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            // Act.
            var exeption = Assert.Throws<Exception>(() => MessagesCompare.Compare(lost, found));

            // Assert.
            // Проверяется не только вызов исключения, но и его контекст.
            Assert.Contains("Тип сообщения (Пропажа/Находка) не заполнен.", exeption.Message);
        }

        // Проверка случая, когда обязательное поле(тип сообщения) null.
        [Fact]
        public void TypeMessageNotExist()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Привет", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            // Act.
            var exeption = Assert.Throws<Exception>(() => MessagesCompare.Compare(lost, found));

            // Assert.
            // Проверяется не только вызов исключения, но и его контекст.
            Assert.Contains("Тип сообщения не существует.", exeption.Message);
        }

        // Проверка случая, когда дата сообщения не заполнена (null).
        [Fact]
        public void DateNotExist()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01/14/2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            // Act.
            var exeption = Assert.Throws<Exception>(() => MessagesCompare.Compare(lost, found));

            // Assert.
            // Проверяется не только вызов исключения, но и его контекст.
            Assert.Contains("Дата сообщения не заполнена.", exeption.Message);
        }

        // Проверка случая несовпадения даты сообщений в массивах.
        [Fact]
        public void DateArraysNotEqual()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Кошка", "Ивановская, 4", "01.02.2010", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            // В данном случае для сообщений различны только даты, процент совпадения
            // равен 87 (при приведении к целому).
            double expectedPercent = 87;

            // Act.
            double actualPercent = (int)MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);
        }

        // Проверка случая совпадения дат, написанных в разных форматах.
        [Fact]
        public void DateFormatNotEqual()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "15.05.2009", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Кошка", "Ивановская, 4", "15 May 2009", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            // При полной идентичности массивов строк совпадение должно равняться 100%.
            // В данном случае идентичность должна быть полной.
            double expectedPercent = MessagesCompare.fullPercent;

            // Act.
            double actualPercent = MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);
        }

        // Проверка случая невалидной даты сообщений в массивах.
        [Fact]
        public void DateArraysNotParse()
        {
            // Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "1 февраля", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Кошка", "Ивановская, 4", "01.02.2010", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            // В данном случае для сообщений различны только даты, процент совпадения
            // равен 87 (при приведении к целому).
            double expectedPercent = 87;

            // Act.
            double actualPercent = (int)MessagesCompare.Compare(lost, found);

            // Assert.
            Assert.Equal(expectedPercent, actualPercent);

        }
    }
}
