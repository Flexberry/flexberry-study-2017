using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompareAccauntData;

namespace Task1
{
    public static class ConvertAccountData
    {

        // Список сайтов.
        public static string[] siteArr;

        // Настройка степени идентичности в процентах.
        private static double degreeOfIdentity = 80;
   
        /// <summary>
        /// Метод StringArrToString() преобразовывает массив в строку.
        /// </summary>
        /// <param name="stringarr">Массив для преобразования</param>
        /// <returns>Текстовую переменную</returns>  
        public static string StringArrToString(string[] stringarr)
        {
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
        /// Метод StringToArrString() преобразовывает стоку в массив.
        /// </summary>
        /// <param name="stringarr">Строка для преобразования</param>
        /// <returns>Массив строк</returns>  
        public static string[] StringToArrString(string stringarr)
        {
            string[] text;
            stringarr = stringarr.Replace(System.Environment.NewLine, "|");
            text = stringarr.Split('|');
            return text;
        }

        /// <summary>
        /// Метод AccautToCompareStringArray() преобразует массив пользователей в массив пользователей по сайтам.
        /// </summary>
        /// <param name="stringarr">Входной массив пользователей</param>
        /// <returns>Массив пользователей по сайтам</returns>  
        public static string[,] AccautToCompareStringArray(string[,] stringarr)
        {
            //Колличество столбцов в stingarr.
            int stringArrLength = stringarr.GetLength(0);
            int stringArrWith = stringarr.GetLength(1);

            // Массив определяющий, в какую строку будет записана строка stringarr.
            int[] resultStringArr = new int[stringArrLength];

            // Результат.
            string[,] result = new string[stringArrLength, siteArr.Length];

            // Последняя не заполенная строка в resultStringArr.
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
                        if (AcciuntCompareAtOneArray(stringarr, i, j) >= degreeOfIdentity)
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
        /// Метод SiteTableNumber() возвращает номер сети в таблице.
        /// </summary>
        /// <param name="site">Соц сеть</param>
        /// <returns>Номер соц сети</returns>  
        private static int SiteTableNumber(string site)
        {
            for (int i = 0; i < siteArr.Length; i++)
            {
                if (site == siteArr[i])
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// Метод  AcciuntCompareAtOneArray() выполняет сравнение строк массива.
        /// </summary>
        /// <param name="site">Соц сеть</param>
        /// <param name="i">Номер строки массива</param>
        /// <param name="j">Номер строки массива</param>
        /// <returns>Результат сравнения в процента</returns>  
        private static int AcciuntCompareAtOneArray(string[,] stringarr, int i, int j)
        {

            int stringArrWith = stringarr.GetLength(1);
  
            string[] arr1 = new string[stringArrWith - 1];
            string[] arr2 = new string[stringArrWith - 1];

            for (int k = 0; k < 10; k++)
            {
                arr1[k] = stringarr[i, k];
                arr2[k] = stringarr[j, k];
            }


            return CompareAccauntData.Compare.CompareAccauntData(arr1, arr2);
        }
    }
}