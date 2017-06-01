using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AcademicPerformance.Objects;

namespace AcademicPerformance
{
    public partial class StudentsClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            /*    DropDownListSpecialityCode.Items.Clear();
                DropDownListSpecialityCode.Items.Add(КодСпециальности.КБ.ToString());
                DropDownListSpecialityCode.Items.Add(КодСпециальности.ММ.ToString());
                DropDownListSpecialityCode.Items.Add(КодСпециальности.МТТ.ToString());
                DropDownListSpecialityCode.Items.Add(КодСпециальности.ПМИ.ToString());*/
            }
        }
    }
}