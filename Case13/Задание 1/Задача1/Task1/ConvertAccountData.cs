using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompareAccountData;

namespace Task1
{
    /// <summary>
    /// Класс для преобразования данных аккаунта.
    /// </summary> 
    public static class ConvertAccountData
    {
        /// <summary>
        /// Список сайтов.
        /// </summary>
        public static string[] siteArr;
  
        /// <summary>
        /// Настройка степени идентичности в процентах.
        /// </summary>
        private static double degreeOfIdentity = 80;

        /// <summary>
        /// Текст ошибки принятия нулевого значения StringArrToStrin.
        /// </summary>
        public static string CovertAccountDataStringArrToStringNullExeptionText = "Аdopted null value";

        /// <summary>
        /// Текст ошибки принятия нулевого значения StringToArrString.
        /// </summary>
        public static string CovertAccountDataStringToArrStringNullExeptionText = "Аdopted null value";

        /// <summary>
        /// Текст ошибки принятия нулевого значения SiteTableNumber.
        /// </summary>
        public static string CovertAccountDataSiteTableNumberNullExeptionText = "Аdopted null value";

        /// <summary>
        /// Текст ошибки принятия нулевого значения AccountToCompareStringArray.
        /// </summary>
        public static string CovertAccountDataAccountToCompareStringArrayNullExeptionText = "Аdopted null value";

        /// <summary>
        /// Текст ошибки принятия нулевого значения AccountCompareAtOneArray.
        /// </summary>
        public static string CovertAccountDataAccountCompareAtOneArrayNullExeptionText = "Index is out of bounds of the array";

        /// <summary>
        /// Преобразует массив в строку.
        /// </summary>
        /// <param name="stringarr">Массив для преобразования.</param>
        /// <returns>Текстовую переменную.</returns>  
        public static string StringArrToString(string[] stringarr)
        {
            if (stringarr == null)
            {
                throw new Exception(CovertAccountDataStringArrToStringNullExeptionText);
            }

            string text = string.Empty;
            for (int i = 0; i < stringarr.Length; i++)
            {
                if (i != stringarr.Length - 1)
                {
                    text += stringarr[i] + System.Environment.NewLine;
                }
                else
                {
                    text += stringarr[i];
                }
            }
            return text;
        }

        /// <summary>
        /// Преобразует стоку в массив.
        /// </summary>
        /// <param name="stringarr">Строка для преобразования.</param>
        /// <returns>Массив строк.</returns>  
        public static string[] StringToArrString(string stringarr)
        {
            if (stringarr == null)
            {
                throw new Exception(CovertAccountDataStringToArrStringNullExeptionText);
            }

            string[] text;
            stringarr = stringarr.Replace(System.Environment.NewLine, "|");
            text = stringarr.Split('|');
            return text;
        }

        /// <summary>
        /// Преобразует массив пользователей в массив пользователей по сайтам.
        /// </summary>
        /// <param name="stringarr">Входной массив пользователей.</param>
        /// <returns>Массив пользователей по сайтам.</returns>  
        public static string[,] AccountToCompareStringArray(string[,] stringarr)
        {
            if (stringarr == null)
            {
                throw new Exception(CovertAccountDataAccountToCompareStringArrayNullExeptionText);
            }

            //Количество столбцов в stingarr.
            int stringArrLength = stringarr.GetLength(0);
            int stringArrWith = stringarr.GetLength(1);

            // Массив определяющий, в какую строку будет записана строка stringarr.
            int[] resultStringArr = new int[stringArrLength];

            // Результат.
            string[,] result = new string[stringArrLength, siteArr.Length];

            // Последняя не заполненная строка в resultStringArr.
            int resultLength = 0;

            // Перебор stringarr.
            for (int i = 0; i < stringArrLength; i++)
            {
                bool end = false;

                for (int j = 0; j < i; j++)
                {
                    // Если находится профиль, похожий >= degreeOfIdentity%, то добавляем.
                    if (!end && i != j)
                    {
                        if (AccountCompareAtOneArray(stringarr, i, j) >= degreeOfIdentity)
                        {
                            int k = resultStringArr[j];
                            if (result[k, SiteTableNumber(stringarr[i, stringArrWith - 1])] == null)
                            {
                                result[k, SiteTableNumber(stringarr[i, stringArrWith - 1])] = stringarr[i, 0];
                                resultStringArr[i] = resultLength;
                                end = true;
                            }
                        }
                    }

                }
                // Если не находится профиль, похожий >= degreeOfIdentity%, то создаём новую строку.
                if (!end)
                {
                    result[resultLength, SiteTableNumber(stringarr[i, stringArrWith - 1])] = stringarr[i, 0];
                    resultStringArr[i] = resultLength;
                    resultLength++;
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает номер сети в таблице.
        /// </summary>
        /// <param name="site">Соц. сеть.</param>
        /// <returns>Номер соц. сети.</returns>  
        public static int SiteTableNumber(string site)
        {
            if (site == null)
            {
                throw new Exception(CovertAccountDataSiteTableNumberNullExeptionText);
            }

            for (int i = 0; i < siteArr.Length; i++)
            {
                if (site == siteArr[i])
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///Выполняет сравнение строк массива.
        /// </summary>
        /// <param name="site">Соц. сеть.</param>
        /// <param name="i">Номер строки массива.</param>
        /// <param name="j">Номер строки массива.</param>
        /// <returns>Результат сравнения в процента.</returns>  
        public static int AccountCompareAtOneArray(string[,] stringarr, int i, int j)
        {
            int stringArrLength = stringarr.GetLength(0);
            int stringArrWith = stringarr.GetLength(1);

            if (i > stringArrLength || j > stringArrLength || i < 0 || j < 0)
            {
                throw new Exception(CovertAccountDataAccountCompareAtOneArrayNullExeptionText);
            }

            string[] arr1 = new string[stringArrWith - 1];
            string[] arr2 = new string[stringArrWith - 1];

            for (int k = 0; k < stringArrWith - 1; k++)
            {
                arr1[k] = stringarr[i, k];
                arr2[k] = stringarr[j, k];
            }


            return CompareAccountData.Compare.CompareAccountData(arr1, arr2);
        }
    }
}
