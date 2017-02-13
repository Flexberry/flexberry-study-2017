using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SportSchool.DAL;
using SportSchool.Objects;

namespace SportSchool
{
    public partial class Sportsmen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["sportsman"] != null)
            {
                string sportsman = Request.Params["sportsman"];
                var arr = sportsman.Split(';');
                Sportsman deleted = new Sportsman()
                {
                    LastName = arr[0],
                    FirstName = arr[1],
                    Patronymic = arr[2],
                    CodeGroup = arr[3]
                };
                DataService.DeleteSportsman(deleted);
                var newUri = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.Url.Query, StringComparison.Ordinal));
                Response.Redirect(newUri);
            }

            SportsmenRepeater.DataSource = DataService.GetAllSportsmen();
            SportsmenRepeater.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Sportsman sportsman = new Sportsman()
            {
                LastName = TextBoxLastName.Text,
                FirstName = TextBoxFirstName.Text,
                Patronymic = TextBoxPatronymic.Text,
                CodeGroup = TextBoxCodeGroup.Text
            };

            DataService.AddSportsman(sportsman);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            DataService.ClearSportsmen();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void ClearControls()
        {
            TextBoxLastName.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxPatronymic.Text = string.Empty;
            TextBoxCodeGroup.Text = string.Empty;
        }
    }
}