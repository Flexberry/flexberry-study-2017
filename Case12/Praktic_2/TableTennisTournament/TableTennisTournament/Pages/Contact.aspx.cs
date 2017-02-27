using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTennisTournament.DAL;
using TableTennisTournament.Objects;

namespace TableTennisTournament
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlayersRepeater.DataSource = DataServiceProvider.Current.GetAllPlayer();
            PlayersRepeater.DataBind();
            }

        protected void AddPlayer_OnClick(object sender, EventArgs e)
        {
            var player = new Player()
            {
                FirstName = NameTB.Text,
                MiddleName = middleTB.Text,
                LastName = familyTB.Text,
                Login = loginTB.Text,
                Rating = 1400,
                PlayerGuid = Guid.NewGuid()
            };
            DataServiceProvider.Current.AddPlayer(player);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void PlayerDelete_OnClick(object sender, EventArgs e)
        {
            var btnClick = (LinkButton) sender;
            DataServiceProvider.Current.DeletePlayer(new Guid(btnClick.CommandArgument));
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}