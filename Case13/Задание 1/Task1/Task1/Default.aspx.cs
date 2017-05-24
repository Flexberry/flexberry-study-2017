using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Task1
{
    public partial class _Default : Page
    {
        // Текст для сравнения текстовых форм.
        public string[] tempText =
        {
        "PMasalkin",
        "pashamasalkin@yandex.ru",
        "Масалкин",
        "Павел",
        "Алексеевич",
        "м",
        "1994",
        "Краснокамск",
        "Россия",
        "http:\\www.temp.ru"
        };

        // Список сайтов.
        public string[] siteArr =
        {"ics.permy.ru", "www.googla.ru", "www.shmandex.ru", "www.mail.ru", "www.sto.ru"};

        // Список пользователь.
        public string[,] accaunts = new string[,]
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
                "www.mail.ru"
            }
        };

        public string[,] accauntsCompare;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Обновление значений в текстбоксах.
            if (firstTextBox.Text == string.Empty)
            {
                firstTextBox.Text = StringArrToString(tempText);
            }
            if (secondTextBox.Text == string.Empty)
            {
                secondTextBox.Text = StringArrToString(tempText);
            }

            accauntsCompare = AccautToCompareStringArray(accaunts);

            // Создание таблицы пользователей по сайтам.
            Table1.CellSpacing = 0;
            Table1.CellSpacing = 0;
            Table1.BorderWidth = 2;
            Table1.GridLines = GridLines.Both;

            // Заголовки.
            TableRow row1 = new TableRow();
            for (int j = 0; j < siteArr.Length; j++)
            {
                TableCell cell = new TableCell();
                cell.Text = siteArr[j];
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Height = 26;
                cell.Width = 26;
                row1.Cells.Add(cell);
            }
            Table1.Rows.Add(row1);

            // Данные.
            for (int i = 0; i < accauntsCompare.Length / (accaunts.Length / 11); i++)
            {
                // Проверка на наличие значений в строке.
                bool rowHaveValue= false;
                for (int k = 0; k < siteArr.Length; k++)
                {
                    if(accauntsCompare[i, k]!=null)
                    {
                        rowHaveValue = true;
                    }
                }

                if (rowHaveValue)
                {
                    TableRow row2 = new TableRow();
                    for (int j = 0; j < siteArr.Length; j++)
                    {
                        TableCell cell = new TableCell();
                        cell.Text = accauntsCompare[i, j];
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        cell.Height = 26;
                        cell.Width = 26;
                        row2.Cells.Add(cell);
                    }
                    Table1.Rows.Add(row2);
                }
            }
        }

        protected void compareButton_Click(object sender, EventArgs e)
        {
            anserLabel.Text = "Совпадение " + AccauntCompare.Compare.AccauntCompare(StringToArrString(firstTextBox.Text), StringToArrString(secondTextBox.Text)).ToString() + "%";
        }

        /// <summary>
        /// Метод StringArrToString() преобразование массива в стоку
        /// </summary>
        /// <param name="stringarr">Массив для преобразования</param>
        /// <returns>Текстовую переменную</returns>  
        private string StringArrToString(string[] stringarr)
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
        /// Метод StringToArrString() преобразование стоки в массив
        /// </summary>
        /// <param name="stringarr">Строка для преобразования</param>
        /// <returns>Массив строк</returns>  
        private string[] StringToArrString(string stringarr)
        {
            string[] text;
            stringarr = stringarr.Replace(System.Environment.NewLine, "|");
            text = stringarr.Split('|');
            return text;
        }

        /// <summary>
        /// Метод AccautToCompareStringArray() преобразует массив пользователей в массив пользователей по сайтам
        /// </summary>
        /// <param name="stringarr">Входной массив пользователей</param>
        /// <returns>Массив пользователей по сайтам</returns>  
        private string[,] AccautToCompareStringArray(string[,] stringarr)
        {
            //Колличество столбцов в stingarr.
            int stringArrLength = stringarr.Length / 11;

            // Массив определяющий, в какую строку будет записана строка stringarr.
            int[] resultStringArr = new int[stringArrLength];

            // Результат.
            string[,] result = new string[stringArrLength, siteArr.Length];

            // Последняя не заполенная строка в resultStringArr.
            int resultLength = 0;

            // Перебор stringarr.
            for (int i = 0; i < stringArrLength; i++)
            {
                bool end=false;

                for (int j = 0; j < i; j++)
                {
                    // Если находится профиль, похожий >= 80%, то добавляем.
                    if (!end && i!=j)
                    {
                        if (AcciuntCompareAtOneArray(stringarr, i, j)>=80)
                        {
                            int k = resultStringArr[j];
                            if (result[k, SiteTableNumber(stringarr[i, 10])] == null)
                            {
                                result[k, SiteTableNumber(stringarr[i, 10])] = stringarr[i, 0];
                                resultStringArr[i] = resultLength;
                                end = true;
                            }
                        }                        
                    }

                }
                // Если не находится профиль, похожий >= 80%, то создаём новую строку.
                if (!end)
                {
                    result[resultLength, SiteTableNumber(stringarr[i, 10])] = stringarr[i, 0];
                    resultStringArr[i] = resultLength;
                    resultLength++;
                }
            }
            
            return result;
        }

        /// <summary>
        /// Метод SiteTableNumber() возвращает номер сети в таблице
        /// </summary>
        /// <param name="site">соц сеть</param>
        /// <returns>номер сети</returns>  
        private int SiteTableNumber(string site)
        {
            for(int i=0;i< siteArr.Length;i++)
            {
                if(site==siteArr[i])
                {
                    return i;
                }
            }

            return 0;
        } 

        /// <summary>
        /// Метод  AcciuntCompareAtOneArray() выполняет сравнение строк массива
        /// </summary>
        /// <param name="site">соц сеть</param>
        /// <param name="i">номер строки массива</param>
        /// <param name="j">номер строки массива</param>
        /// <returns>Результат сравнения в процента</returns>  
        private int AcciuntCompareAtOneArray(string[,] stringarr,int i, int j)
        {
            string[] arr1 = new string[10];
            string[] arr2 = new string[10];

            for (int k = 0; k < 10; k++)
            {
                arr1[k] = stringarr[i, k];
                arr2[k] = stringarr[j, k];
            }


            return AccauntCompare.Compare.AccauntCompare(arr1, arr2);
        }

    }
}