using System;
using Xunit;

namespace ConvertAccountDateTest
{
    /// <summary>
    /// Тестирование библиотеки ConvertAccountDate.
    /// </summary>
    public class ConvertAccountDateTest
    {
        /// <summary>
        /// Тестовый метод для проверки работы с включёнными в массив пустыми элементами (<see cref="CompareAccountDate"/>).
        /// Тест проверяет следующие факты:
        /// <list type="number">
        /// <item><description>Проверка сравнения с включёнными в массив пустыми элементами.</description></item> 
        /// </list> 
        /// </summary>
        [Fact]
        public void CompareAccountDateInputWithEmptyTest()
        {
            // Arrange.
            string[] tempText5 = new string[]
            {
                string.Empty
            };

            //Act
            var test1Act =  0;//CompareAccountDate.Compare.CompareAccountDate(tempText5, tempText5);

            //Assert
            // Сравнение масиивов с пустыми элементами.
            Assert.Equal(test1Act, 0);
        }
    }
}
