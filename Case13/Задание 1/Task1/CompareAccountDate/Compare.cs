using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAccountDate
{
    /// <summary>
    ///  Класс Compare основной класс программы сравнения аккаунтов
    /// </summary>
    public static class Compare
    {
        /// <summary>
        ///  Тескст ошибки принятия нулевого значения
        /// </summary>
        public static string CompareAccountDateNullExeptionText = "Аdopted a value of zero";

        /// <summary>
        /// Метод CompareAccountDate() выполняет сравнение двух строковых массивов
        /// </summary>
        /// <param name="innerText1">Первый массив для сравнения</param>
        /// <param name="innerText2">Второй массив для сравнения</param>
        /// <returns>Результат сравнения в процентах</returns>  
        public static int CompareAccountDate(string[] innerText1, string[] innerText2)
        {
            if (innerText1 == null || innerText2 == null)
            {
                throw new Exception(CompareAccountDateNullExeptionText);
            }

            int innerText1Lenght = innerText1.Length;
            int innerText2Lenght = innerText2.Length;

            // Результат срвнения.
            int result = 0;

            // Максимальное количество элементов при срвнении.
            int maxResult = Math.Max(innerText1Lenght, innerText2Lenght);

            // Сравненение элементов массива.
            for (int i = 0; i < innerText1Lenght; i++)
            {
                for (int j = 0; j < innerText2Lenght; j++)
                {
                    if (innerText1[i] != null && innerText2[j] != null)
                    {
                        if (innerText1[i] != string.Empty && innerText2[j] != string.Empty)
                        {
                            if (innerText1[i].Equals(innerText2[j]))
                            {
                                result++;
                            }
                        }
                    }
                }
            }

            return result * 100 / maxResult;
        }
    }
}
