using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    /// <summary>
    /// Тестирование библиотеки AccauntCompare.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
    
       [TestMethod]
        public void AccauntCompareTest()
        {
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

            // Cравсненеи идентичных массивов
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText1), 100);

            string[] tempText3 = new string[]
            {
                "Пол м",
                "Дата_рождения 1994",
                "Город Краснокамск",
                "Страна Россия",
                "Вебсайт http:\\www.temp.ru"
            };

            // Сравненеие с меньшим массивом
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText3), 50);
        
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

            // Сравненеи с массивом с 1 похожим полем
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText4), 10);

            string[] tempText2 = new string[] { };

            // Сравнение полного массива с пустым.
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText2), 0);
        }

        [TestMethod]
        public void AccauntCompareInputWithEmptyTest()
        {

            string[] tempText5 = new string[]
            {
                string.Empty
            };
            
            // Сравнение масиивов с пустыми элементами.
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText5, tempText5), 0);
        }

        [TestMethod]
        public void AccauntCompareInputWithNullTest()
        {

            string[] tempText6 = new string[]
            {
                null
            };

            // Сравнение масиивов с null элментами.
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText6, tempText6), 0);
        }

        [TestMethod]
        public void AccauntCompareInputNullTest()
        {
            // Сравнение  null элментами.
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(null, null), 0);
        }
    }
}
