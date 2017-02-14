using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTennisTournament.DAL;
using TableTennisTournament.Objects;


namespace TableTennisTournament.Pages
{
    public partial class Match : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 FillDate();
               
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
            
            A_PlayerList.DataSource = DataServiceProvider.Current.GetAllPlayer();
            A_PlayerList.DataBind();

            B_PlayerList.DataSource = DataServiceProvider.Current.GetAllPlayer();
            B_PlayerList.DataBind();
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
          
        }
    }
}