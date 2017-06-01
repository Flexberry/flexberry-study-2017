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
    public partial class GetRating : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelStudent.Visible = false;
            PanelStudentIsNotFound.Visible = false;
            LabelFIO.Text = string.Empty;
            //LabelGroup.Text = string.Empty;
            //LabelDateBirth.Text = string.Empty;
            //LabelCodeSpeciality.Text = string.Empty;
            var organizations = ((SQLDataService)DataServiceProvider.DataService).Query<Организация>(Организация.Views.ОрганизацияE).Where(k => k.Актуальность == true).ToArray();
            foreach (var org in organizations)
            {
                var choice = ((SQLDataService)DataServiceProvider.DataService).Query<ВыборПриоритета>(ВыборПриоритета.Views.Скрипт).Where(k => k.Модуль.Организация.Название == org.Название).Where(k => k.Актуальность == true).ToArray();
                var rate = 0;
                foreach (var ch in choice)
                {
                    if (ch.Приоритет < 4)
                    {
                        rate += (4 - ch.Приоритет);
                    }
                }
                LabelFIO.Text += "Организация: " + $"{org.Название}" + "; Рейтинг = " + $"{rate}" + "<br/>";
                PanelStudent.Visible = true;
            }
        }

    protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
           //     var choice = ((SQLDataService)DataServiceProvider.DataService).Query<ВыборПриоритета>(ВыборПриоритета.Views.ВыборПриоритетаL).Where(k => k.Приоритет == 1).Where(k => k.Модуль.Организация.Название == TextBoxCode.Text).Where(k => k.Актуальность == true).Where(k => k.МодульВыбран == true).ToArray();
                

      //  var str = [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.SQLDataService), "SELECT STUFF((SELECT '; Семестр № ',\"Номер\" AS 'data()', ', программа '  ,\"Название\" AS 'data()', ', приоритет = ',\"Приоритет\" AS 'data()'" +
      //" FROM \"Студент\" stud join \"ВыборПриоритета\" prior on stud.\"primaryKey\" = prior.\"Студент\" join \"Модуль\" mod on mod.\"primaryKey\" = prior.\"Модуль_m0\" join \"Семестр\" sem on mod.\"Семестр_m0\" = sem.\"primaryKey\""
      //+ "WHERE sem.\"Актуальность\"  = \'true\' AND mod.\"Актуальность\"  = \'true\' AND prior.\"Актуальность\"  = \'true\' AND prior.\"МодульВыбран\"  = \'true\' AND stud.\"Логин\"  = @Логин@ FOR XML PATH('')),1,2,'')")];

            ////var organizations = ((SQLDataService)DataServiceProvider.DataService).Query<Организация>(Организация.Views.ОрганизацияE).Where(k => k.Актуальность == true).ToArray();
            ////foreach (var org in organizations)
            ////{
            ////    var choice = ((SQLDataService)DataServiceProvider.DataService).Query<ВыборПриоритета>(ВыборПриоритета.Views.Скрипт).Where(k => k.Модуль.Организация.Название == org.Название).Where(k => k.Актуальность == true).ToArray();
            ////    var rate = 0;
            ////    foreach (var ch in choice)
            ////    {
            ////        if(ch.Приоритет < 4)
            ////        {
            ////            rate += (4 - ch.Приоритет);
            ////        }
            ////    } 
            ////    LabelFIO.Text += "Организация: " + $"{org.Название}" + "; Рейтинг = " +$"{rate}"+ "<br/>";
            ////    PanelStudent.Visible = true;                                                 
            ////}
            

           // DataServiceProvider.Current.GetStudent(TextBoxCode.Text);
            //    if (студент != null)
            //    {
            //        LabelFIO.Text = $"{студент.Фамилия} {студент.Имя} {студент.Отчество}";
            //        LabelGroup.Text = студент.НомерГруппы;
            //        LabelDateBirth.Text = студент.ДатаРождения.ToString("D");
            //        LabelCodeSpeciality.Text = студент.КодСпециальности.ToString();
            //        PanelStudent.Visible = true;
            //    }
            //    else
            //    {
            //        PanelStudentIsNotFound.Visible = true;
            //    }
        }
    }
}