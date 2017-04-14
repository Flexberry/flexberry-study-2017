using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.Configuration;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
//using AjaxControls;
using ICSSoft.STORMNET.Web.Tools;
using IIS.Product_58826;

namespace ICSSoft.STORMNET.Web
{
    public partial class GetZodiak : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelStudent.Visible = false;
            PanelStudentIsNotFound.Visible = false;
            LabelFIO.Text = string.Empty;
            //LabelGroup.Text = string.Empty;
            //LabelDateBirth.Text = string.Empty;
            //LabelCodeSpeciality.Text = string.Empty;
            var students = ((SQLDataService)DataServiceProvider.DataService).Query<Студент>(Студент.Views.СтудентE).Where(k => k.Обучается == true).ToArray();

            //var organizations = ((SQLDataService)DataServiceProvider.DataService).Query<Организация>(Организация.Views.ОрганизацияE).Where(k => k.Актуальность == true).ToArray();
            foreach (var st in students)
            {
                var str = "";
                if (((st.ДатаРождения.Day.Between(21, 31)) && (st.ДатаРождения.Month == 3)) || ((st.ДатаРождения.Day.Between(1, 20)) && (st.ДатаРождения.Month == 4)))
                    str = "Овен";
                if (((st.ДатаРождения.Day.Between(23, 31)) && (st.ДатаРождения.Month == 7)) || ((st.ДатаРождения.Day.Between(1, 23)) && (st.ДатаРождения.Month == 8)))
                    str = "Лев";
                if (((st.ДатаРождения.Day.Between(23, 30)) && (st.ДатаРождения.Month == 11)) || ((st.ДатаРождения.Day.Between(1, 21)) && (st.ДатаРождения.Month == 12)))
                    str = "Стрелец";
                if (((st.ДатаРождения.Day.Between(21, 30)) && (st.ДатаРождения.Month == 4)) || ((st.ДатаРождения.Day.Between(1, 20)) && (st.ДатаРождения.Month == 5)))
                    str = "Телец";
                if (((st.ДатаРождения.Day.Between(24, 31)) && (st.ДатаРождения.Month == 8)) || ((st.ДатаРождения.Day.Between(1, 23)) && (st.ДатаРождения.Month == 9)))
                    str = "Дева";
                if (((st.ДатаРождения.Day.Between(22, 31)) && (st.ДатаРождения.Month == 12)) || ((st.ДатаРождения.Day.Between(1, 20)) && (st.ДатаРождения.Month == 1)))
                    str = "Козерог";
                if (((st.ДатаРождения.Day.Between(21, 31)) && (st.ДатаРождения.Month == 5)) || ((st.ДатаРождения.Day.Between(1, 21)) && (st.ДатаРождения.Month == 6)))
                    str = "Близнецы";
                if (((st.ДатаРождения.Day.Between(24, 30)) && (st.ДатаРождения.Month == 9)) || ((st.ДатаРождения.Day.Between(1, 23)) && (st.ДатаРождения.Month == 10)))
                    str = "Весы";
                if (((st.ДатаРождения.Day.Between(21, 31)) && (st.ДатаРождения.Month == 1)) || ((st.ДатаРождения.Day.Between(1, 20)) && (st.ДатаРождения.Month == 2)))
                    str = "Водолей";
                if (((st.ДатаРождения.Day.Between(22, 30)) && (st.ДатаРождения.Month == 6)) || ((st.ДатаРождения.Day.Between(1, 22)) && (st.ДатаРождения.Month == 7)))
                    str = "Рак";
                if (((st.ДатаРождения.Day.Between(24, 31)) && (st.ДатаРождения.Month == 10)) || ((st.ДатаРождения.Day.Between(1, 22)) && (st.ДатаРождения.Month == 11)))
                    str = "Скорпион";
                if (((st.ДатаРождения.Day.Between(21, 29)) && (st.ДатаРождения.Month == 2)) || ((st.ДатаРождения.Day.Between(1, 20)) && (st.ДатаРождения.Month == 3)))
                    str = "Рыбы";
                



                LabelFIO.Text += "Студент: " + $"{st.Фамилия} {st.Имя} {st.Отчество}" + "; Логин: " + $"{st.Логин}" + "; Дата рождения: " + $"{st.ДатаРождения.Date.ToShortDateString()}" + "; Знак Зодиака: " + $"{str}" + "<br/>";
                PanelStudent.Visible = true;



            }
        }

    protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
            
            //var students = ((SQLDataService)DataServiceProvider.DataService).Query<Студент>(Студент.Views.СтудентE).Where(k => k.Обучается == true).ToArray();

            ////var organizations = ((SQLDataService)DataServiceProvider.DataService).Query<Организация>(Организация.Views.ОрганизацияE).Where(k => k.Актуальность == true).ToArray();
            //foreach (var st in students)
            //{
            //    var str = "";
            //    if (((st.ДатаРождения.Day >= 21) && (st.ДатаРождения.Day <= 31) && (st.ДатаРождения.Month == 3)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 20) && (st.ДатаРождения.Month == 4)))
            //        str = "Овен";
            //    if (((st.ДатаРождения.Day >= 23) && (st.ДатаРождения.Day <= 31) && (st.ДатаРождения.Month == 7)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 23) && (st.ДатаРождения.Month == 8)))
            //        str = "Лев";
            //    if (((st.ДатаРождения.Day >= 23) && (st.ДатаРождения.Day <= 30) && (st.ДатаРождения.Month == 11)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 21) && (st.ДатаРождения.Month == 12)))
            //        str = "Стрелец";
            //    if (((st.ДатаРождения.Day >= 21) && (st.ДатаРождения.Day <= 30) && (st.ДатаРождения.Month == 4)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 20) && (st.ДатаРождения.Month == 5)))
            //        str = "Телец";
            //    if (((st.ДатаРождения.Day >= 24) && (st.ДатаРождения.Day <= 31) && (st.ДатаРождения.Month == 8)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 23) && (st.ДатаРождения.Month == 9)))
            //        str = "Дева";
            //    if (((st.ДатаРождения.Day >= 22) && (st.ДатаРождения.Day <= 31) && (st.ДатаРождения.Month == 12)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 20) && (st.ДатаРождения.Month == 1)))
            //        str = "Козерог";
            //    if (((st.ДатаРождения.Day >= 21) && (st.ДатаРождения.Day <= 31) && (st.ДатаРождения.Month == 5)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 21) && (st.ДатаРождения.Month == 6)))
            //        str = "Близнецы";
            //    if (((st.ДатаРождения.Day >= 29) && (st.ДатаРождения.Day <= 30) && (st.ДатаРождения.Month == 9)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 23) && (st.ДатаРождения.Month == 10)))
            //        str = "Весы";
            //    if (((st.ДатаРождения.Day >= 21) && (st.ДатаРождения.Day <= 31) && (st.ДатаРождения.Month == 1)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 20) && (st.ДатаРождения.Month == 2)))
            //        str = "Водолей";
            //    if (((st.ДатаРождения.Day >= 22) && (st.ДатаРождения.Day <= 30) && (st.ДатаРождения.Month == 6)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 22) && (st.ДатаРождения.Month == 7)))
            //        str = "Рак";
            //    if (((st.ДатаРождения.Day >= 24) && (st.ДатаРождения.Day <= 31) && (st.ДатаРождения.Month == 10)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 22) && (st.ДатаРождения.Month == 11)))
            //        str = "Скорпион";
            //    if (((st.ДатаРождения.Day >= 21) && (st.ДатаРождения.Day <= 29) && (st.ДатаРождения.Month == 2)) || ((st.ДатаРождения.Day >= 1) && (st.ДатаРождения.Day <= 20) && (st.ДатаРождения.Month == 3)))
            //        str = "Рыбы";





            //    LabelFIO.Text += "Студент: " + $"{st.Фамилия} {st.Имя} {st.Отчество}" + "; Знак Зодиака = " +$"{str}"+ "<br/>";
            //    PanelStudent.Visible = true;
                    
                
                
            //}
        }
    }
}