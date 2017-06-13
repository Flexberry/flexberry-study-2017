using System;
using Xunit;

using CompareAccauntData;

namespace UnitTest
{
    /// <summary>
    /// Тестирование библиотеки CompareAccauntData.
    /// </summary>
    public class CompareAccountDateTests
    {
        /// <summary>
        /// Тестовый метод для проверки работы (<see cref="CompareAccauntData"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Проверка при идентичности данных.</description></item> 
        /// <item><description>Проверка сравнения массивов данных разного размера.</description></item> 
        /// <item><description>Проверка сравнения 2 массивов с разными записями.</description></item> 
        /// </list> 
        /// </summary>
        [Fact]
        public void CompareAccountDateCompareTest()
        {
            // Arrange.
            string[] tempText1 = new string[]
            {
                "Логин PMasalkin",
                "E-Mail pashamasalkin@yandex.ru",
                "Фамилия Масалкин",
                "Имя Павел",
                "Отчество Алексеевич",
                "Пол м",
                "Дата_рождения 1994",
                "Город Краснокамск",
                "Страна Россия",
                "Вебсайт http:\\www.temp.ru"
            };

            string[] tempText3 = new string[]
            {
                "Пол м",
                "Дата_рождения 1994",
                "Город Краснокамск",
                "Страна Россия",
                "Вебсайт http:\\www.temp.ru"
            };

            string[] tempText4 = new string[]
            {
                "Логин PMasalkin1",
                "E-Mail pashamasalkin@yandex.ru1",
                "Фамилия Масалкин1",
                "Имя Павел1",
                "Отчество Алексеевич1",
                "Пол м1",
                "Дата_рождения 19941",
                "Город Краснокамск1",
                "Страна Россия1",
                "Вебсайт http:\\www.temp.ru"
            };
 
            string[] tempText2 = new string[] { };

            //Act
            var test1Act = CompareAccauntData.Compare.CompareAccauntData(tempText1, tempText1);
            var test2Act = CompareAccauntData.Compare.CompareAccauntData(tempText1, tempText3);
            var test3Act = CompareAccauntData.Compare.CompareAccauntData(tempText1, tempText4);
            var test4Act = CompareAccauntData.Compare.CompareAccauntData(tempText1, tempText2);

            //Assert

            // Cравсненеи идентичных массивов
            Assert.Equal(test1Act, 100);

            // Сравненеие с меньшим массивом
            Assert.Equal(test2Act, 50);

            // Сравненеи с массивом с 1 похожим полем
            Assert.Equal(test3Act, 10);

            // Сравнение полного массива с пустым.
            Assert.Equal(test4Act, 0);
        }

        /// <summary>
        /// Тестовый метод для проверки работы с включёнными в массив пустыми элементами (<see cref="CompareAccauntData"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Проверка сравнения с включёнными в массив пустыми элементами.</description></item> 
        /// </list> 
        /// </summary>
        [Fact]
        public void CompareAccauntDataInputWithEmptyTest()
        {
            // Arrange.
            string[] tempText5 = new string[]
            {
                string.Empty
            };

            //Act
            var test1Act = CompareAccauntData.Compare.CompareAccauntData(tempText5, tempText5);

            //Assert
            // Сравнение масиивов с пустыми элементами.
            Assert.Equal(test1Act, 0);
        }

        /// <summary>
        /// Тестовый метод для проверки работы с включёнными в массив null элементами (<see cref="CompareAccauntData"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Проверка сравнения с включёнными в массив null элементами.</description></item> 
        /// </list> 
        /// </summary>
        [Fact]
        public void CompareAccauntDataInputWithNullTest()
        {
            // Arrange.
            string[] tempText6 = new string[]
            {
                null
            };

            //Act
            var test1Act = CompareAccauntData.Compare.CompareAccauntData(tempText6, tempText6);

            //Assert
            // Сравнение масиивов с null элментами.
            Assert.Equal(test1Act, 0);
        }

        /// <summary>
        /// Тестовый метод для проверки ошибки при передаче null элементов (<see cref="CompareAccauntData"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Вывод ошибки при принятии функцией null элемента.</description></item> 
        /// </list> 
        /// </summary>
        [Fact]
        public void CompareAccauntDataInputNullTest()
        {
            // Сравнение  null элментами.
            try
            {
                //Act
                CompareAccauntData.Compare.CompareAccauntData(null, null);
            }
            catch(Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, CompareAccauntData.Compare.CompareAccauntDataNullExeptionText);
            }
        }
    }
}
