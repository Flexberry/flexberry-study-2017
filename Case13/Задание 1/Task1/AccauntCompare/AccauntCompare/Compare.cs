using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccauntCompare
{
    /// <summary>
    ///  Класс Compare основной класс программы
    ///  сравнения аккаунтов
    /// </summary>
    public class Compare
    {
        /// <summary>
        /// Метод AccauntCompare() выполняет сравнение
        /// двух строковых массивов
        /// </summary>
        /// <param name="innerText1">Первый массив для сравнения</param>
        /// <param name="innerText2">Второй массив для сравнения</param>
        /// <returns>Результат сравнения в процентах</returns>  
        public static int AccauntCompare(string[] innerText1, string[] innerText2)
        {
            // Результат срвнения.
            int result = 0;

            // Максимальное количество элементов при срвнении.
            int maxResult = Math.Max(innerText1.Length, innerText2.Length);

            // Сравненение элементов массива.
            for (int i = 0; i < innerText1.Length; i++)
            {
                for (int j = 0; j < innerText2.Length; j++)
                {
                    if (innerText1[i].Equals(innerText2[j]))
                    {
                        result++;
                    }
                }
            }

            return result * 100 / maxResult;
        }
    }
}
