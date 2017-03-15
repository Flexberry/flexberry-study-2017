using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportSchool.DAL;
using SportSchool.Objects;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SportSchool
{
    public partial class PointsCalculate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Training training = new Training();
            ZoneRepeater.DataSource = DataService.GetZones();
            ZoneRepeater.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var time = TextBoxTime.Text;

            string pattern = @"^[0-2][0-9]:[0-6][0-9]:[0-6][0-9]$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(time);
            if (matches.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Неверное время')", true);
                return;
            }
            DataService.AddZone(int.Parse(ZoneDropDownList.SelectedValue), TimeSpan.Parse(time));
            Response.Redirect(Request.Url.AbsoluteUri.Split('?')[0]);
        }

        protected void ButtonCalculatePoints_OnClick(object sender, EventArgs e)
        {
            var training = DataService.GetLastTraining();
            loadLabel.Text = (DataService.CalculatePoints(training)).ToString();
        }
    }
}