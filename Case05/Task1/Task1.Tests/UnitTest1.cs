using Logic;

namespace Web.Tests
{
    using System;
    using Xunit;

    using Task1.Objects;
    using Logic;

    public class CodeGeneratorTests
    {
        [Fact]
        public void L1_Correct()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = "РогаКопыта",
                DateReg = new DateTime(2017, 01, 01),
                Account = 123456789
            };
            
            //правильное решение
            var expectedCode = "170101РогаКоп12345";

            ///Запуск теста.
            var Code = Logic1.GenerateCode(TestConsumer);

            ///Сравнение.
            Assert.Equal(expectedCode, Code);
        }

        // короткие поля названия и лс
        [Fact]
        public void TC_L1_Correct_short_name_ls()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = "Рога",
                DateReg = new DateTime(2017, 01, 01),
                Account = 123
            };

            //правильное решение
            var expectedCode = "170101___Рога00123";

            ///Запуск теста.
            var Code = Logic.Logic1.GenerateCode(TestConsumer);

            ///Сравнение.
            Assert.Equal(expectedCode, Code);
        }

        //пустой объект
        [Fact]
        public void TC_L1_Incorrecе_empty_name()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = null,
                DateReg = new DateTime(2017, 01, 01),
                Account = 123456789
            };

            ///Запуск теста.
            var ex = Assert.Throws<ArgumentNullException>(() => Logic1.GenerateCode(TestConsumer));

            ///Сравнение.
            Assert.Contains("Не заполнены все поля формы", ex.Message);
        }

        //пустой л/с
        [Fact]
        public void TC_L1_Incorrect_empty_ls()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = "РогаКопыта",
                DateReg = new DateTime(2017, 01, 01),
                //Account = null
            };

            ///Запуск теста.
            var ex = Assert.Throws<ArgumentNullException>(() => Logic1.GenerateCode(TestConsumer));

            ///Сравнение.
            Assert.Contains("Не заполнены все поля формы", ex.Message);
        }
        
        //странные символы
        [Fact]
        public void TC_L1_Correct_random_symbol()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = "@",
                DateReg = new DateTime(2017, 01, 01),
                Account = 123,
            };

            //правильное решение
            var expectedCode = "170101______@00123";

            ///Запуск теста.
            var Code = Logic.Logic1.GenerateCode(TestConsumer);

            ///Сравнение.
            Assert.Equal(expectedCode, Code);
        }

        [Fact]
        public void TC_L2_Correct()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = "РогаКопыта",
                DateReg = new DateTime(2017, 01, 01),
                Account = 123456789
            };

            //правильное решение
            var expectedCode = "021I3V9РогаК170101";

            ///Запуск теста.
            var Code = Logic2.GenerateCode(TestConsumer);

            ///Сравнение.
            Assert.Equal(expectedCode, Code);
        }
        [Fact]
        public void TC_L2_Correct_short()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = "Р",
                DateReg = new DateTime(2017, 01, 01),
                Account = 1,
            };

            //правильное решение
            var expectedCode = "0000001____Р170101";

            ///Запуск теста.
            var Code = Logic2.GenerateCode(TestConsumer);

            ///Сравнение.
            Assert.Equal(expectedCode, Code);
        }
        //пустой объект
        [Fact]
        public void TC_L2_Incorrecе_empty_name()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = null,
                DateReg = new DateTime(2017, 01, 01),
                Account = 123456789
            };

            ///Запуск теста.
            var ex = Assert.Throws<ArgumentNullException>(() => Logic2.GenerateCode(TestConsumer));

            ///Сравнение.
            Assert.Contains("Не заполнены все поля формы", ex.Message);
        }

        //пустой л/с
        [Fact]
        public void TC_L2_Incorrect_empty_ls()
        {
            ///Тестовые данные.
            var TestConsumer = new Consumer()
            {
                Name = "РогаКопыта",
                DateReg = new DateTime(2017, 01, 01),
                //Account = null
            };

            ///Запуск теста.
            var ex = Assert.Throws<ArgumentNullException>(() => Logic2.GenerateCode(TestConsumer));

            ///Сравнение.
            Assert.Contains("Не заполнены все поля формы", ex.Message);
        }
    }
}
