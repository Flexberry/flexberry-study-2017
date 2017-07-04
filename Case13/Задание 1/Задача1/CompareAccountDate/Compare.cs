using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareAccountData
{
    /// <summary>
    ///  Класс Compare основной класс программы сравнения аккаунтов.
    /// </summary>
    public static class Compare
    {
        /// <summary>
        ///  Текст ошибки принятия нулевого значения.
        /// </summary>
        public static string CompareAccountDataNullExeptionText = "Аdopted a value of zero";

        /// <summary>
        /// Метод CompareAccountData() выполняет сравнение двух строковых массивов.
        /// </summary>
        /// <param name="innerAccountDataArray1">Первый массив для сравнения.</param>
        /// <param name="innerAccountDataArray2">Второй массив для сравнения.</param>
        /// <returns>Результат сравнения в процентах.</returns>  
        public static int CompareAccountData(string[] innerAccountDataArray1, string[] innerAccountDataArray2)
        {
            if (innerAccountDataArray1 == null || innerAccountDataArray2 == null)
            {
                throw new Exception(CompareAccountDataNullExeptionText);
            }

            int innerAccountDataArray1Lenght = innerAccountDataArray1.Length;
            int innerAccountDataArray2Lenght = innerAccountDataArray2.Length;

            // Результат сравнения.
            int result = 0;

            // Максимальное количество элементов при сравнении.
            int maxResult = Math.Max(innerAccountDataArray1Lenght, innerAccountDataArray2Lenght);

            // Сравнение элементов массива.
            for (int i = 0; i < innerAccountDataArray1Lenght; i++)
            {
                for (int j = 0; j < innerAccountDataArray2Lenght; j++)
                {
                    if (innerAccountDataArray1[i] != null && innerAccountDataArray2[j] != null)
                    {
                        if (innerAccountDataArray1[i] != string.Empty && innerAccountDataArray2[j] != string.Empty)
                        {
                            if (innerAccountDataArray1[i].Equals(innerAccountDataArray2[j]))
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

