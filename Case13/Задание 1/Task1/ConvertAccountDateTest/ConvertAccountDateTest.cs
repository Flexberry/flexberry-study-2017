using Xunit;
using Task1;
using System;

namespace ConvertAccountDateTest
{
    public class ConvertAccountDateTest
    {

        /// <summary>
        /// Тестовый метод для проверки работы (<see cref="StringArrToString"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Преобразование массива.</description></item>
        /// <item><description>Преобразование пустово массива в строку.</description></item>
        /// <item><description>Преобразование нулевого массива в строку.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void CompareAccountDateStringArrToStringDefaultTest()
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

            string[] tempText2 = new string[] { };

            string[] tempText3 = new string[]
            {
               ""
            };

            string tempText1AftherConvert = "Логин PMasalkin\r\nE-Mail pashamasalkin@yandex.ru\r\nФамилия Масалкин\r\nИмя Павел\r\nОтчество Алексеевич\r\nПол м\r\nДата_рождения 1994\r\nГород Краснокамск\r\nСтрана Россия\r\nВебсайт http:\\www.temp.ru";

            //Act
            var test1Act = ConvertAccountDate.StringArrToString(tempText1);
            var test2Act = ConvertAccountDate.StringArrToString(tempText2);
            var test3Act = ConvertAccountDate.StringArrToString(tempText3);

            //Assert

            // Преобразование массива
            Assert.Equal(test1Act, tempText1AftherConvert);

            // Преобразование пустого массива
            Assert.Equal(test2Act, string.Empty);

            // Преобразование массива с пустым элементом
            Assert.Equal(test3Act, string.Empty);
        }

        /// <summary>
        /// Тестовый метод для проверки ошибки при передаче null элементов (<see cref="StringArrToString"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Вывод ошибки при принятии функцией null элемента.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void ConvertAccountDateStringArrToStringInputNullTest()
        {
            // Сравнение  null элментами.
            try
            {
                //Act
                ConvertAccountDate.StringArrToString(null);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, ConvertAccountDate.CovertAccountDateStringArrToStringNullExeptionText);
            }
        }

        /// <summary>
        /// Тестовый метод для проверки работы (<see cref="StringArrToString"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Преобразование строки в массив.</description></item>
        /// <item><description>Преобразование пустой строки в массив.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void CompareAccountDateStringToArrStringDefaultTest()
        {
            // Arrange.
            string tempText1 = "Логин PMasalkin\r\nE-Mail pashamasalkin@yandex.ru\r\nФамилия Масалкин\r\nИмя Павел\r\nОтчество Алексеевич\r\nПол м\r\nДата_рождения 1994\r\nГород Краснокамск\r\nСтрана Россия\r\nВебсайт http:\\www.temp.ru";

            string tempText2 = "";

            string[] tempText1AftherConvert = new string[]
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

            string[] tempText2AftherConvert = new string[] 
            {
                ""
            };


            //Act
            var test1Act = ConvertAccountDate.StringToArrString(tempText1);
            var test2Act = ConvertAccountDate.StringToArrString(tempText2);

            //Assert

            // Преобразование массива
            Assert.Equal(test1Act, tempText1AftherConvert);

            // Преобразование пустого массива
            Assert.Equal(test2Act, tempText2AftherConvert);
        }

        /// <summary>
        /// Тестовый метод для проверки ошибки при передаче null элементов (<see cref="StringArrToString"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Вывод ошибки при принятии функцией null элемента.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void ConvertAccountDateStringToArrStringInputNullTest()
        {
            // Сравнение  null элментами.
            try
            {
                //Act
                ConvertAccountDate.StringToArrString(null);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, ConvertAccountDate.CovertAccountDateStringToArrStringNullExeptionText);
            }
        }

        /// <summary>
        /// Тестовый метод для проверки работы (<see cref="AcciuntCompareAtOneArray"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Проверка при идентичности данных.</description></item>
        /// <item><description>Проверка сравнения 2 массивов с разными записями.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void CompareAccountDateAcciuntCompareAtOneArrayDefaultTest()
        {
            // Arrange.
            string[,] tempAccounts = new string[,]
            {
                 {
                    "PMasalkin1",
                    "pashamasalkin@yandex.ru",
                    "Масалкин",
                    "Павел",
                    "Алексеевич",
                    "м",
                    "1994",
                    "Краснокамск",
                    "Россия",
                    "http:\\www.temp.ru",
                    "ics.permy.ru"
                },
                {
                    "PMasalkin1",
                    "pashamasalkin@yandex.ru1",
                    "Масалкин",
                    "Павел",
                    "Алексеевич",
                    "м",
                    "1994",
                    "Краснокамск2",
                    "Россия",
                    "http:\\www.temp.ru",
                    "www.shmandex.ru"
                }
            };


            //Act
            int test1Act = ConvertAccountDate.AcciuntCompareAtOneArray(tempAccounts, 0, 1);
            int test2Act = ConvertAccountDate.AcciuntCompareAtOneArray(tempAccounts, 0, 0);

            //Assert

            // Результат стравнения
            Assert.Equal(test1Act, 80);
            
            // Сравнение идентичныъ массивов
            Assert.Equal(test2Act, 100);
        }

        /// <summary>
        /// Тестовый метод для проверки передачи не существующего элемента (<see cref="AcciuntCompareAtOneArray"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Сравнение не сущетсвующей строки.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void ConvertAccountDateAcciuntCompareAtOneArrayInputNullTest()
        {
            // Сравнение  null элментами.
            try
            {
                // Arrange.
                string[,] tempAccounts = new string[,]
                {
                    {
                        "PMasalkin1",
                        "pashamasalkin@yandex.ru",
                        "Масалкин",
                        "Павел",
                        "Алексеевич",
                        "м",
                        "1994",
                        "Краснокамск",
                        "Россия",
                        "http:\\www.temp.ru",
                        "ics.permy.ru"
                    },
                    {
                        "PMasalkin1",
                        "pashamasalkin@yandex.ru1",
                        "Масалкин",
                        "Павел",
                        "Алексеевич",
                        "м",
                        "1994",
                        "Краснокамск2",
                        "Россия",
                        "http:\\www.temp.ru",
                        "www.shmandex.ru"
                    }
                };


                //Act
                ConvertAccountDate.AcciuntCompareAtOneArray(tempAccounts, 0, 5);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, ConvertAccountDate.CovertAccountDateAcciuntCompareAtOneArrayNullExeptionText);
            }
        }

        /// <summary>
        /// Тестовый метод для проверки работы (<see cref="SiteTableNumber"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Поиск существующего элемента массива.</description></item>
        /// <item><description>Поиск не существующего элемента массива.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void CompareAccountDateSiteTableNumberDefaultTest()
        {
            // Arrange.
            string tempText1 = "ics.permy.ru";

            string tempText2 = "ics.permy.ru1";

            string[] siteArr = { "ics.permy.ru", "www.googla.ru", "www.shmandex.ru", "www.mail.ru", "www.sto.ru" };

            //Act
            ConvertAccountDate.siteArr = siteArr;
            int test1Act = ConvertAccountDate.SiteTableNumber(tempText1);
            int test2Act = ConvertAccountDate.SiteTableNumber(tempText2);

            //Assert

            // Номер существующего значения
            Assert.Equal(test1Act, 0);

            //  Номер не существующего значения
            Assert.Equal(test2Act, -1);
        }

        /// <summary>
        /// Тестовый метод для проверки ошибки при передаче null элементов (<see cref="StringArrToString"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Вывод ошибки при принятии функцией null элемента.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void ConvertAccountDateSiteTableNumberInputNullTest()
        {
            // Сравнение  null элментами.
            try
            {
                // Arrange.
                string[] siteArr = { "ics.permy.ru", "www.googla.ru", "www.shmandex.ru", "www.mail.ru", "www.sto.ru" };

                //Act
                ConvertAccountDate.siteArr = siteArr;
                ConvertAccountDate.SiteTableNumber(null);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, ConvertAccountDate.CovertAccountDateSiteTableNumberNullExeptionText);
            }
        }

        /// <summary>
        /// Тестовый метод для проверки работы (<see cref="AccautToCompareStringArray"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Преобразование массива аккаунтов в массив пользователь.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void CompareAccountDateAccautToCompareStringArrayDefaultTest()
        {
            // Arrange.
            string[] siteArr = { "ics.permy.ru", "www.googla.ru", "www.shmandex.ru", "www.mail.ru", "www.sto.ru" };

            // Список пользователь.
            string[,] tempAccounts = new string[,]
            {
                 {
                    "PMasalkin1",
                    "pashamasalkin@yandex.ru",
                    "Масалкин",
                    "Павел",
                    "Алексеевич",
                    "м",
                    "1994",
                    "Краснокамск",
                    "Россия",
                    "http:\\www.temp.ru",
                    "ics.permy.ru"
                },
                {
                    "PMasalkin1",
                    "pashamasalkin@yandex.ru",
                    "Масалкин",
                    "Павел",
                    "Алексеевич",
                    "м",
                    "1994",
                    "Краснокамск",
                    "Россия",
                    "http:\\www.temp.ru",
                    "www.sto.ru"
                },
                {
                    "PMasalkin2",
                    "pashamasalkin@yandex.ru",
                    "Масалкин",
                    "Павел",
                    "Алексеевичый",
                    "рептилойд",
                    "1994",
                    "Краснокамск",
                    "Россия",
                    "http:\\www.temp.ru",
                    "ics.permy.ru"
                },
                                {
                    "PMasalkin3",
                    "pashamasalkin@yandex.ru",
                    "Масалкинf",
                    "Павел",
                    "Алексеевич3",
                    "Вакум",
                    "-1994",
                    "Краснокамск",
                    "Россия",
                    "http:\\www.temp.ru1",
                    "www.googla.ru"
                },
                {
                    "PMasalkin2",
                    "pashamasalkin@yandex.ru",
                    "Масалкин",
                    "Павел",
                    "Алексеевичый",
                    "рептилойд",
                    "1994",
                    "Краснокамск",
                    "Россия",
                    "http:\\www.temp.ru",
                    "www.mail.ru"
                }
            };

            string[,] tempAccountsResult = new string[,]
            {
                {
                    "PMasalkin1",
                    null,
                    null,
                    null,
                    "PMasalkin1"
                },
                {
                    "PMasalkin2",
                    null,
                    null,
                    "PMasalkin2",
                    null,
                },
                {
                    null,
                    "PMasalkin3",
                    null,
                    null,
                    null,
                },
                {
                    null,
                    null,
                    null,
                    null,
                    null,
                },
                {
                    null,
                    null,
                    null,
                    null,
                    null,
                },
            };
            //Act
            ConvertAccountDate.siteArr = siteArr;
            string[,] test1Act = ConvertAccountDate.AccautToCompareStringArray(tempAccounts);

            //Assert

            // Номер существующего значения
            Assert.Equal(test1Act, tempAccountsResult);
        }

        /// <summary>
        /// Тестовый метод для проверки ошибки при передаче null элементов (<see cref="AccautToCompareStringArray"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Вывод ошибки при принятии функцией null элемента.</description></item>
        /// </list>
        /// </summary>
        [Fact]
        public void ConvertAccountDateAccautToCompareStringArrayInputNullTest()
        {
            // Сравнение  null элментами.
            try
            {
                //Act
                ConvertAccountDate.AccautToCompareStringArray(null);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal(ex.Message, ConvertAccountDate.CovertAccountDateAccautToCompareStringArrayNullExeptionText);
            }
        }
    }
}
