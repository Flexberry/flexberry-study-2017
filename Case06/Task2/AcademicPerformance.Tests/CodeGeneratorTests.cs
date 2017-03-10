namespace AcademicPerformance.Tests
{
    using System;
    using Xunit;

    using AcademicPerformance.Objects;
    using CheckNumber;

/// не были реализованы следующие тесты:
///  1) сплошной текст в строке информации (без пробелов). Ячейка таблицы разъедется, т.к. не осуществится перенос строк по словам.
///  2) не реализована проверка ввода нескольких допустимых символов ./()- подряд (зависит от конкретного шаблона пользователя)
///  3) ввод номера уже существующего договора (не относится к проверке корректности самого номера, а относится к проверке при добавление в хранилище)

    public class CheckNumberTests     // ВСЕ ТЕСТЫ ВЫПОЛНЕНЫ ДЛЯ ШАБЛОНА "000ААА000" !!!!!!!
    {
        [Fact]
        public void TestGetCodeForRecordBook_CorrectDogovor() // с русскими буквами
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "273икр729",
                Информация = "Информация для тестового договора."
            };

            //var expectedКодДоговора = "2a";
            var expectedКорректность = true;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_CorrectDogovorNumber1() // с английскими буквами
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "273dhw729",
                Информация = "Информация для тестового договора."
            };

            ///Act.
         //   var ex = Assert.Throws<ArgumentNullException>(() => CheckNumber.GetCodeForRecordBook(договор));

            var expectedКорректность = true;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);


            ///Assert.
    //        Assert.Contains("Некорректный номер договора", ex.Message);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectDogovorNumber_OnlyNumbers() // только числа
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "273816274",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectDogovorNumber_OnlyLetters() // только буквы
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "аругылару",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectDogovorNumber_TooShort() // слишком короткий номер + не соответствует шаблону
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "2рв2в",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectDogovorNumber_TooLong() // слишком длинный номер + не соответствует шаблону
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "2рвуцаа372в",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectDogovorNumber_Almost() // частично правильный номер: ААА000
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "врп231",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectDogovorNumber_EmptyNumber() // не введен номер договора
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_СorrectDogovorNumber2() // номер в виде 0ААА000 для шаблона 000ААА000. 
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "1оар374", // = 001оар374
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = true;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_InorrectDogovorNumber_EmptyInformation() // не введена информация
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "341фрп231",
                Информация = ""
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_IncorrectDogovorNumber_IncorrectSymbols() // номер с недопустимыми символами
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "341fh*231",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = false;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_CorrectDogovorNumber_CorrectSymbols() // номер с допустимыми символами  -()/.
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "341fh/231",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = true;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }

        [Fact]
        public void TestGetCodeForRecordBook_CorrectDogovorNumber_Registrs() // разный регистр букв и разные языки (2 теста в одном)
        {
            ///Arrange.
            var договор = new Договор()
            {
                номерДоговора = "341NqЩ231",
                Информация = "Информация для тестового договора."
            };

            var expectedКорректность = true;
            ///Act.
            var Корректность = CheckNumber.GetCodeForRecordBook(договор);
            ///Assert.
            Assert.Equal(expectedКорректность, Корректность);
        }


    }
}
