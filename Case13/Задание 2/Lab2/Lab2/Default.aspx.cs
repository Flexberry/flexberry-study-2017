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
        public static string[] tempText =
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
        };

        public string[,,] accaunts = new string[,,]
        {
        {         {
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
        "Вебсайт http:\\www.temp.ru"},
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            CountLable.Text = "Колличество элементов: " + tempText.Length.ToString();

        }

        private void AddRow(string[] temp)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            for (int i = 0; i < 6; i++)
            {
                Label label = new Label();
                switch (i)
                {
                    case 0:
                        label.Text = "Логин: " + temp[i];
                        break;
                    case 1:
                        /****/
                        break;
                    case 2:
                        label.Text = "Фамилия: " + temp[i];
                        break;
                    case 3:
                        label.Text = "Имя: " + temp[i];
                        break;
                    case 4:
                        label.Text = "Отчество: " + temp[i];
                        break;
                    case 5:
                        label.Text = "Пол: " + temp[i];
                        break;
                    default:
                        break;
                }
                cell.Controls.Add(label);
            }

            row.Cells.Add(cell);
            DataTable.Rows.Add(row);
        }
    }
}