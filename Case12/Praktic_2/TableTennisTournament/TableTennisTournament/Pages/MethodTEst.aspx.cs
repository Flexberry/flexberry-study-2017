using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTennisTournament.DAL;
using TableTennisTournament.Objects;
using RatingPosition;

namespace TableTennisTournament.Pages
{
    public partial class MethodTEst : System.Web.UI.Page
    {
        private Rating RatingElo = new RatingPosition.Rating();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetRating_OnClick(object sender, EventArgs e)
        {
            Player playerA = new Player()
            {
                Login = NameA.Text,
                Rating = Int32.Parse(RatingA.Text)
            };
            Player playerB = new Player()
            {
                Login = NameB.Text,
                Rating = Int32.Parse(RatingB.Text)
             };
            Objects.Match match = new Objects.Match()
            {
                GameFactor = int.Parse(MagicK.Text),
                PlayerOne = playerA,
                PlayerTwo = playerB,
                };
            if (WinA.Checked)
            {
                match.Result = 1;
            }
            else if (WinAB.Checked)
            {
                match.Result = -1;
            }
            else if (WinB.Checked)
            {
                match.Result = 0;
            }

            RatingElo.GetNewPlayerRating(match);
            newRatingA.Text = match.PlayerOne.Rating.ToString();
            newRatingB.Text = match.PlayerTwo.Rating.ToString();
        }

        protected void RatingB_OnTextChanged(object sender, EventArgs e)
        {
            var rating = int.Parse(RatingB.Text);
            RatingB.Text =(rating < 0 ? 0 : rating > 10000 ? 9999 : rating).ToString();

        }

        protected void RatingA_OnTextChanged(object sender, EventArgs e)
        {
            var rating = int.Parse(RatingA.Text);
            RatingA.Text = (rating < 0 ? 0 : rating > 10000 ? 9999 : rating).ToString();
        }
    }
}
