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
        /// <param name="accountDataArray1">Первый массив для сравнения.</param>
        /// <param name="accountDataArray2">Второй массив для сравнения.</param>
        /// <returns>Результат сравнения в процентах.</returns>  
        public static int CompareAccountData(string[] accountDataArray1, string[] accountDataArray2)
        {
            if (accountDataArray1 == null || accountDataArray2 == null)
            {
                throw new Exception(CompareAccountDataNullExeptionText);
            }

            int accountDataArray1Lenght = accountDataArray1.Length;
            int accountDataArray2Lenght = accountDataArray2.Length;

            // Результат сравнения.
            int result = 0;

            // Максимальное количество элементов при сравнении.
            int maxResult = Math.Max(accountDataArray1Lenght, accountDataArray2Lenght);

            // Сравнение элементов массива.
            for (int i = 0; i < accountDataArray1Lenght; i++)
            {
                for (int j = 0; j < accountDataArray2Lenght; j++)
                {
                    if (accountDataArray1[i] != null && accountDataArray2[j] != null)
                    {
                        if (accountDataArray1[i] != string.Empty && accountDataArray2[j] != string.Empty)
                        {
                            if (accountDataArray1[i].Equals(accountDataArray2[j]))
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

