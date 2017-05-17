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
        public string[] site =
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
                "pashamasalkin@yandex.ru",
                "Масалкин",
                "Павел",
                "Алексеевич",
                "м",
                "1994",
                "Краснокамск",
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
                "Алексеевич",
                "м",
                "1994",
                "Краснокамск",
                "Россия",
                "http:\\www.temp.ru",
                "www.googla.ru"
            },
            {
                "PMasalkin2",
                "pashamasalkin@yandex.ru",
                "Масалкин",
                "Павел",
                "Алексеевич",
                "м",
                "1994",
                "Краснокамск",
                "Россия",
                "http:\\www.temp.ru",
                "www.mail.ru"
            },
            {
                "PMasalkin3",
                "pashamasalkin@yandex.ru",
                "Масалкин",
                "Павел",
                "Алексеевич",
                "м",
                "1994",
                "Краснокамск",
                "Россия",
                "http:\\www.temp.ru",
                "www.googla.ru"
            },
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
            for (int i = 0; i < 5; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < 5; j++)
                {
                    TableCell cell = new TableCell();
                    if(i == 0)
                    {
                        cell.Text = site[j];
                    }
                    else
                    {
                        cell.Text = accauntsCompare[i-1, j];
                    }
                    cell.HorizontalAlign = HorizontalAlign.Center;
                    cell.Height = 26;
                    cell.Width = 26;
                    row.Cells.Add(cell);
                }
                Table1.Rows.Add(row);
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
        /// Метод AccautToCompareStringArray() массива пользователей в таблицу пользователей по сайтам
        /// </summary>
        /// <param name="stringarr">Входной массив пользователей</param>
        /// <returns>Массив пользователей по сайтам</returns>  
        private string[,] AccautToCompareStringArray(string[,] stringarr)
        {
            string[,] result;

            for (int i = 0; i < 5; i++)
            {
                for (int j = i+1; j < 10; j++)
                {
                    for (int k = 0; j < 9; k++)
                    {

                        
                    }
                }
            }

            result = stringarr;

            return result;
        }
    }
}