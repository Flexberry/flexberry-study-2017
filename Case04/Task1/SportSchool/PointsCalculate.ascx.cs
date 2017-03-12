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
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var time = TextBoxTime.Text;

            string pattern = @"^[0-9][0-9]:[0-6][0-9]:[0-6][0-9]$";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(time);
            if (matches.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Неверное время')", true);
                return;
            }
        }

        protected void ButtonCalculatePoints_OnClick(object sender, EventArgs e)
        {
            
        }
    }
}