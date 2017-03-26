using System;
using System.Linq;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using NewPlatform.RecordBookBL;

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
            var ds = (SQLDataService)DataServiceProvider.DataService;

            var student = ds.Query<Студент>(Студент.Views.СтудентE).Where(студент => студент.НомерЗачетки == TextBoxCode.Text).FirstOrDefault();

            if (student != null)
            {
                LabelFIO.Text = $"{student.Фамилия} {student.Имя} {student.Отчество}";
                LabelGroup.Text = student.Группа.Название;
                LabelDateBirth.Text = student.ДатаРождения.ToString("D");
                LabelCodeSpeciality.Text = student.Группа.Специальность.КодСпециальности;
                PanelStudent.Visible = true;
            }
            else
            {
                PanelStudentIsNotFound.Visible = true;
            }
        }
    }
}