using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CompareAccountData;

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
        public string[] siteArr = {"ics.permy.ru", "www.googla.ru", "www.shmandex.ru", "www.mail.ru", "www.sto.ru"};

        // Список пользователь.
        public string[,] accounts = new string[,]
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

        protected void Page_Load(object sender, EventArgs e)
        {
            // Добавление списка сайтов классу ConvertAccountData.
            ConvertAccountData.siteArr = siteArr;

            // Обновление значений в текстбоксах.
            if (firstTextBox.Text == string.Empty)
            {
                firstTextBox.Text = ConvertAccountData.StringArrToString(tempText);
            }
            if (secondTextBox.Text == string.Empty)
            {
                secondTextBox.Text = ConvertAccountData.StringArrToString(tempText);
            }

            // Создание таблицы пользователей по сайтам.
            string[,] accountsCompare = ConvertAccountData.AccountToCompareStringArray(accounts);

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

            // Длина массива.
            int accountCompareArrWith = accountsCompare.GetLength(0);

            // Данные.
            for (int i = 0; i < accountCompareArrWith; i++)
            {
                // Проверка на наличие значений в строке.
                bool rowHaveValue= false;
                for (int k = 0; k < siteArr.Length; k++)
                {
                    if(accountsCompare[i, k]!=null)
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
                        cell.Text = accountsCompare[i, j];
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
            anserLabel.Text = "Совпадение " + CompareAccountData.Compare.CompareAccountData(ConvertAccountData.StringToArrString(firstTextBox.Text), ConvertAccountData.StringToArrString(secondTextBox.Text)).ToString() + "%";
        }
    }
}