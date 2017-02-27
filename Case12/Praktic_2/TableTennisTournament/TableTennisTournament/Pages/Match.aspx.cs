using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RatingPosition;
using TableTennisTournament.DAL;
using TableTennisTournament.Objects;


namespace TableTennisTournament.Pages
{
    public partial class Match : System.Web.UI.Page
    {
        private Rating ratingElo = new Rating();
        public Objects.Match CurrentMatch;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDate();
                GetPlayers();
            }


            MatchRepeater.DataSource = DataServiceProvider.Current.GetAllMatch();
            MatchRepeater.DataBind();
            if (Session["CurrentMatch"] != null)
            {
                CurrentMatch = (Objects.Match) Session["CurrentMatch"];
                CreateRoundPlace(CurrentMatch.RoundsList.Count);
                //  Session["CurrentMatch"] = null;
            }

        }

        protected void FillDate()
        {
            DateTime timeNowDateTime = DateTime.Now;
            for (int hour = 7; hour < 23; hour++)
            {
                Hour.Items.Add(hour.ToString());
            }
            Hour.Items.FindByText((timeNowDateTime.Hour + 1).ToString()).Selected = true;

            for (int minute = 0; minute < 60; minute += 5)
            {
                Minutes.Items.Add(minute.ToString());
            }
            Minutes.Items[0].Selected = true;

            for (int year = timeNowDateTime.Year - 2; year < timeNowDateTime.Year + 3; year ++)
            {
                Year.Items.Add(year.ToString());
            }
            Year.Items[2].Selected = true;

            string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames.Take(12).ToArray();
            foreach (var month in monthNames)
            {
                Month.Items.Add(month);
            }
            Month.Items[timeNowDateTime.Month - 1].Selected = true;

            for (int i = 1; i < DateTime.DaysInMonth(Int32.Parse(Year.SelectedValue), Month.SelectedIndex + 1) + 1; i++)
            {
                Day.Items.Add(i.ToString());
            }
            Day.SelectedIndex = timeNowDateTime.Day - 1;


        }

        protected void GetPlayers()
        {
            A_PlayerList.Items.AddRange(
                DataServiceProvider.Current.GetAllPlayer()
                    .Select(x => new ListItem(x.Login, x.PlayerGuid.ToString()))
                    .ToArray());
            B_PlayerList.Items.AddRange(
                DataServiceProvider.Current.GetAllPlayer()
                    .Select(x => new ListItem(x.Login, x.PlayerGuid.ToString()))
                    .ToArray());
        }

        protected void Month_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = Day.SelectedIndex;
            int daysInMonth = DateTime.DaysInMonth(Int32.Parse(Year.SelectedValue), Month.SelectedIndex + 1);

            Day.Items.Clear();

            for (int i = 1; i < daysInMonth + 1; i++)
            {
                Day.Items.Add(i.ToString());
            }

            int futureIndex = (currentIndex + 1 < daysInMonth) ? currentIndex : daysInMonth - 1;
            Day.SelectedIndex = futureIndex;
        }

        protected void addMatch_OnClick(object sender, EventArgs e)
        {
            var match = new Objects.Match()
            {
                PlayerOne = DataServiceProvider.Current.GetPlayer(new Guid(A_PlayerList.SelectedValue)),
                PlayerTwo = DataServiceProvider.Current.GetPlayer(new Guid(B_PlayerList.SelectedValue)),
                GameFactor = Int32.Parse(GameFactorTB.Text),
                IsRegistred = true,
                MatchGuid = Guid.NewGuid(),
                PlayDateTime =
                    new DateTime(Int32.Parse(Year.SelectedValue), Month.SelectedIndex + 1, Day.SelectedIndex + 1,
                        Int32.Parse(Hour.SelectedValue), Int32.Parse(Minutes.SelectedValue), 0),
            };
            for (var i = 0; i < int.Parse(RoundCount.Text); i++)
            {
                match.RoundsList.Add(new GameRound() {RoundGoal = int.Parse(GameType.SelectedValue)});
            }
            Session["CurrentMatch"] = match;
            DataServiceProvider.Current.AddMatch(match);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void CreateRoundPlace(int roundCount)
        {
            for (var i = 0; i < roundCount; i++)
            {
                CreateRound(RoundHolder, CurrentMatch.RoundsList[i], i);
            }
            RoundHolder.DataBind();
        }

        protected void CreateRound(PlaceHolder place, GameRound round, int currentRound)
        {

            var playerA = new TextBox()
            {
                ID = "playerAGame_" + currentRound,
                TextMode = TextBoxMode.Number,
                Text = round.ScorePlayerOne.ToString()
            };
            var playerB = new TextBox()
            {
                ID = "playerB_game" + currentRound,
                TextMode = TextBoxMode.Number,
                Text = round.ScorePlayerTwo.ToString()
            };

            if (round.WinnerIsPlayer == 1)
            {
                playerA.BorderColor = Color.Green;
            }
            else if (round.WinnerIsPlayer == 0)
            {
                playerB.BorderColor = Color.Green;
            }
            var btn = new Button()
            {
                Text = "Записать",
                ID = "btn_" + currentRound,
                CommandArgument = currentRound.ToString(),
                OnClientClick = "WriteRound_OnClick"
            };

            place.Controls.Add(new LiteralControl("<div>"));
            place.Controls.Add(playerA);
            place.Controls.Add(playerB);
            place.Controls.Add(btn);
            place.Controls.Add(new LiteralControl("</div>"));
        }

        protected void WriteRound_OnClick(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var position = int.Parse(btn.CommandArgument);
            GameRound round = CurrentMatch.RoundsList[position];
            round.ScorePlayerOne = Int32.Parse(((TextBox) RoundHolder.FindControl("playerAGame_" + position)).Text);
            round.ScorePlayerTwo = Int32.Parse(((TextBox) RoundHolder.FindControl("playerBGame_" + position)).Text);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            var ra = new List<GameRound>(CurrentMatch.RoundsList);

            var winA = ra.Count(x => x.WinnerIsPlayer == 1);
            var winB = ra.Count(x => x.WinnerIsPlayer == 0);
            CurrentMatch.Result = winA > winB ? winA : winB;
            ratingElo.GetNewPlayerRating(CurrentMatch);
            newRatingA.Text = CurrentMatch.PlayerOne.Rating.ToString();
            newRatingB.Text = CurrentMatch.PlayerTwo.Rating.ToString();
        }
    }
}