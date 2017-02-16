using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AcademicPerformance.DAL;

namespace AcademicPerformance
{
    public partial class GetStudent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelStudent.Visible = false;
            PanelStudentIsNotFound.Visible = false;
            LabelFIO.Text = string.Empty;
            LabelGroup.Text = string.Empty;
            LabelDateBirth.Text = string.Empty;
            LabelCodeSpeciality.Text = string.Empty;
        }

        protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
            var студент = DataServiceProvider.Current.GetStudent(TextBoxCode.Text);
            if (студент != null)
            {
                LabelFIO.Text = $"{студент.Фамилия} {студент.Имя} {студент.Отчество}";
                LabelGroup.Text = студент.НомерГруппы;
                LabelDateBirth.Text = студент.ДатаРождения.ToString("D");
                LabelCodeSpeciality.Text = студент.КодСпециальности.ToString();
                PanelStudent.Visible = true;
            }
            else
            {
                PanelStudentIsNotFound.Visible = true;
            }
        }
    }
}