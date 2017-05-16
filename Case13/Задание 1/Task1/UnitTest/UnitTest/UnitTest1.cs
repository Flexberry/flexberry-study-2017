using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccauntCompare;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string[] tempText1 =
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

        string[] tempText2 = { };

        string[] tempText3 =
        {
            "Пол м",
            "Дата_рождения 1994",
            "Город Краснокамск",
            "Страна Россия",
            "Вебсайт http:\\www.temp.ru"
            };

        string[] tempText4 =
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

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText1), 100);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText2), 0);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText3), 50);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(AccauntCompare.Compare.AccauntCompare(tempText1, tempText4), 10);
        }
    }
}
