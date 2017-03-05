namespace LostFound.Tests
{
    using Analysis;
    using System;
    using Xunit;

    public class ClassCompTest
    {
        [Fact]
        public void FullArrayEqual()
        {
            //Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            double expectedPct = 100;

            //Act.
            ClassComp testClassComp = new ClassComp();
            double actPct = testClassComp.Comparison(lost, found);

            //Assert.
            Assert.Equal(expectedPct, actPct);

        }

        [Fact]
        public void NullElementLost()
        {
            //Arrange.
            string[] lost = new string[9] { " ", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", " " };

            string[] found = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            double expectedPct = 77;

            //Act.
            ClassComp testClassComp = new ClassComp();
            double actPct = (int)testClassComp.Comparison(lost, found);

            //Assert.
            Assert.Equal(expectedPct, actPct);
        }

        [Fact]
        public void NullElementFound()
        {
            //Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Потеряно", "Кошка", " ", "01.02.2000", "Животное", "Пятнистая", "Маленькая", " ", " " };

            double expectedPct = 66;

            //Act.
            ClassComp testClassComp = new ClassComp();
            double actPct = (int)testClassComp.Comparison(lost, found);

            //Assert.
            Assert.Equal(expectedPct, actPct);
        }

        [Fact]
        public void FullArrayNotEqual()
        {
            //Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            double expectedPct = 0;

            //Act.
            ClassComp testClassComp = new ClassComp();
            double actPct = testClassComp.Comparison(lost, found);

            //Assert.
            Assert.Equal(expectedPct, actPct);

        }

        [Fact]
        public void ValuesRreversedEqual()
        {
            //Arrange.
            string[] lost = new string[9] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            string[] found = new string[9] { "Потеряно", "01.02.2000", "Животное", "Кошка", "Ивановская, 4",  "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами" };

            double expectedPct = 100;

            //Act.
            ClassComp testClassComp = new ClassComp();
            double actPct = testClassComp.Comparison(lost, found);

            //Assert.
            Assert.Equal(expectedPct, actPct);

        }

        [Fact]
        public void ArraysLenghtNotEqual()
        {
            //Arrange.
            string[] lost = new string[10] { "Потеряно", "Кошка", "Ивановская, 4", "01.02.2000", "Животное", "Пятнистая", "Маленькая", "Беспородная", "Белая с рыжими и черными пятнами", "" };

            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            bool exeptionCalled = false;

            //Act & assert.
            try
            {
                ClassComp testClassComp = new ClassComp();
                testClassComp.Comparison(lost, found);
            }
            catch (Exception)
            {
                exeptionCalled = true;
            }

            Assert.True(exeptionCalled);

        }

        [Fact]
        public void LostNull()
        {
            //Arrange.
            string[] found = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            bool exeptionCalled = false;

            //Act & assert.
            try
            {
                ClassComp testClassComp = new ClassComp();
                testClassComp.Comparison(null, found);
            }
            catch (ArgumentNullException exception)
            {
                if (exception.ParamName == "lost")
                {
                    exeptionCalled = true;
                }
            }
            Assert.True(exeptionCalled);
        }

        [Fact]
        public void FoundNull()
        {
            //Arrange.
            string[] lost = new string[9] { "Найдено", "Сумка", "Листовская, 14-5", "01.14.2010", "Аксессуар", "Синяя", "Объемная", "Нет", "Внутри фотография и расческа" };

            bool exeptionCalled = false;

            //Act & assert.
            try
            {
                ClassComp testClassComp = new ClassComp();
                testClassComp.Comparison(lost, null);
            }
            catch (ArgumentNullException exception)
            {
                if (exception.ParamName == "found")
                {
                    exeptionCalled = true;
                }
            }
            Assert.True(exeptionCalled);
        }

        [Fact]
        public void ArraysNull()
        {
            //Arrange.
            
            bool exeptionCalled = false;

            //Act & assert.
            try
            {
                ClassComp testClassComp = new ClassComp();
                testClassComp.Comparison(null, null);
            }
            catch (ArgumentNullException exception)
            {
                exeptionCalled = true;
            }
            Assert.True(exeptionCalled);
        }

    }
}
