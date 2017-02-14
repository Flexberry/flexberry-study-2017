using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SportSchool.DAL;

namespace SportSchool
{
    public partial class GetSportsman : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
            var sportsmen = DataService.GetSportsmen(TextBoxLastName.Text, TextBoxFirstName.Text, TextBoxPatronymic.Text, TextBoxCodeGroup.Text);
            SportsmenRepeater.DataSource = sportsmen;
            SportsmenRepeater.DataBind();
        }
    }
}