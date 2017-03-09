using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
    public partial class _Default : Page
    {

        public string[,] accaunts = new string[,]
        {
            {   
            "PMasalkin",
            "pashamasalkin@yandex.ru",
            "Масалкин",
            "Павел",
            "Алексеевич",
            "м",
            "Дата_рождения 1994",
            "Город Краснокамск",
            "Страна Россия",
            "Вебсайт http:\\www.temp.ru"
            },
            { "PMasalkin",
            "pashamasalkin@yandex.ru",
            "Масалкин",
            "Павел",
            "Алексеевич",
            "м",
            "Дата_рождения 1994",
            "Город Краснокамск",
            "Страна Россия",
            "Вебсайт http:\\www.temp.ru"
            }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            AddRow(AccauntsToAccaunt(accaunts, 0));
            AddRow(AccauntsToAccaunt(accaunts, 1));

            CountLable.Text = "Колличество элементов: " + 2 + "(изменить)";
        }

        string[] AccauntsToAccaunt(string[,] temp, int num)
        {
            string[] accaunt = new string[9];
            for (int i = 0; i < 9; i++)
            {
                accaunt[i] = temp[num, i];
            }
            return accaunt;
        }

        private void AddRow(string[] temp)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            string labletext = string.Empty;
            string lableplatext = string.Empty;

            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        labletext += "Логин: ";
                        break;
                    case 1:
                        lableplatext += "Почта: ";
                        break;
                    case 2:
                        labletext += "Фамилия: ";
                        break;
                    case 3:
                        labletext += "Имя: ";
                        break;
                    case 4:
                        labletext += "Отчество: ";
                        break;
                    case 5:
                        labletext += "Пол: ";
                        break;
                    case 6:
                        labletext += "Дата рождения: ";
                        break;
                    case 7:
                        labletext += "Город: ";
                        break;
                    case 8:
                        labletext += "Страна: ";
                        break;
                    case 9:
                        labletext += "Сайт: ";
                        break;
                    default:
                        break;
                }

                labletext += temp[i] + Environment.NewLine; ;
            }

            Label label1 = new Label();
            label1.Text = labletext;
            Label label2 = new Label();

            cell.Controls.Add(label1);
            //cell.Controls.Add(label2);

            row.Cells.Add(cell);
            DataTable.Rows.Add(row);
        }
    }
}