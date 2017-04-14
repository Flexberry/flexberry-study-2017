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
    public partial class GetPreferences : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelStudent.Visible = false;
            PanelStudentIsNotFound.Visible = false;
            LabelFIO.Text = string.Empty;
            //LabelGroup.Text = string.Empty;
            //LabelDateBirth.Text = string.Empty;
            //LabelCodeSpeciality.Text = string.Empty;

        }

    protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
           //     var choice = ((SQLDataService)DataServiceProvider.DataService).Query<ВыборПриоритета>(ВыборПриоритета.Views.ВыборПриоритетаL).Where(k => k.Приоритет == 1).Where(k => k.Модуль.Организация.Название == TextBoxCode.Text).Where(k => k.Актуальность == true).Where(k => k.МодульВыбран == true).ToArray();
                

      //  var str = [DataServiceExpression(typeof(ICSSoft.STORMNET.Business.SQLDataService), "SELECT STUFF((SELECT '; Семестр № ',\"Номер\" AS 'data()', ', программа '  ,\"Название\" AS 'data()', ', приоритет = ',\"Приоритет\" AS 'data()'" +
      //" FROM \"Студент\" stud join \"ВыборПриоритета\" prior on stud.\"primaryKey\" = prior.\"Студент\" join \"Модуль\" mod on mod.\"primaryKey\" = prior.\"Модуль_m0\" join \"Семестр\" sem on mod.\"Семестр_m0\" = sem.\"primaryKey\""
      //+ "WHERE sem.\"Актуальность\"  = \'true\' AND mod.\"Актуальность\"  = \'true\' AND prior.\"Актуальность\"  = \'true\' AND prior.\"МодульВыбран\"  = \'true\' AND stud.\"Логин\"  = @Логин@ FOR XML PATH('')),1,2,'')")];

            var students = ((SQLDataService)DataServiceProvider.DataService).Query<Студент>(Студент.Views.СтудентE).Where(k => k.Обучается == true).Where(k => k.Логин == TextBoxCode.Text).ToArray();
            foreach (var st in students)
            {
                var choice = ((SQLDataService)DataServiceProvider.DataService).Query<ВыборПриоритета>(ВыборПриоритета.Views.Скрипт).Where(k => k.Приоритет == 1).Where(k => k.Актуальность == true).Where(k => k.Студент.__PrimaryKey == st.__PrimaryKey).ToArray();

                LabelFIO.Text += "Студент: " + $"{st.Фамилия} {st.Имя} {st.Отчество}" + "; Логин: " + $"{st.Логин}"  + "<br/><br/>";
                PanelStudent.Visible = true;
                // DataServiceProvider.DataService.LoadObject(st);
                foreach (var ch in choice)
                {
                    //   DataServiceProvider.DataService.LoadObject(ch);

                    LabelFIO.Text += "Модуль: " + $"{ch.Модуль.Название}" + "; Приоритет: " +$"{ch.Приоритет}"  +"<br/>";
                        
                    
                }
                
            }
            

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