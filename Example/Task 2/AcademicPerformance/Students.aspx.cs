using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AcademicPerformance.Objects;
using AcademicPerformance.DAL;
using AcademicPerformance.Helpers;

namespace AcademicPerformance
{
    public partial class Students : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListSpecialityCode.Items.Clear();
                DropDownListSpecialityCode.Items.Add(КодСпециальности.КБ.ToString());
                DropDownListSpecialityCode.Items.Add(КодСпециальности.ММ.ToString());
                DropDownListSpecialityCode.Items.Add(КодСпециальности.МТТ.ToString());
                DropDownListSpecialityCode.Items.Add(КодСпециальности.ПМИ.ToString());
            }

            if (Request.Params["code"] != null)
            {
                var кодСтудента = Request.Params["code"];
                DataServiceProvider.Current.DeleteStudent(кодСтудента);
                var newUri = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.Url.Query, StringComparison.Ordinal));
                Response.Redirect(newUri);
            }

            StudentsRepeater.DataSource = DataServiceProvider.Current.GetAllStudents();
            StudentsRepeater.DataBind();

            if (Session["IsStudentAdded"] != null && (bool)Session["IsStudentAdded"])
            {
                ClearControls();
                Session["IsStudentAdded"] = null;
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var студент = new Студент()
            {
                Фамилия = TextBoxSurname.Text,
                Имя = TextBoxName.Text,
                Отчество = TextBoxPatronymic.Text,
                НомерГруппы = TextBoxGroup.Text,
                ДатаРождения = DateTime.Parse(Request.Form["calendartext"]),
                КодСпециальности = DomainObjectsHelper.GetКодСпециальности(DropDownListSpecialityCode.SelectedValue)
            };

            DataServiceProvider.Current.AddStudent(студент);
            Session["IsStudentAdded"] = true;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ButtonClear_OnClick(object sender, EventArgs e)
        {
            DataServiceProvider.Current.ClearStudents();
            Session["IsStudentAdded"] = true;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void ClearControls()
        {
            TextBoxSurname.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            TextBoxPatronymic.Text = string.Empty;
            TextBoxGroup.Text = string.Empty;
            //CalendarDateBirth.SelectedDate = DateTime.Now;

            DropDownListSpecialityCode.SelectedIndex = 0;
        }
    }
}