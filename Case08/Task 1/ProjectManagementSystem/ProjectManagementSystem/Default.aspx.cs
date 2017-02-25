using System;
using System.Collections.Generic;

using System.Web.UI;
using WorkTimeLibrary;
using PMS.Objects;
using PMS.DAL;

namespace ProjectManagementSystem
{
    public partial class _Default : Page
    {
        private List<Day> days;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            days = new List<Day>();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = DateTime.Parse(TextBoxStartDate.Text);
                int hour = Int32.Parse(TextBoxHour.Text);

                BusinessCalendarService businessCalendarService = new BusinessCalendarService();
                BusinessCalendar businessCalendar = new BusinessCalendar(BusinessCalendarServiceProvider.Current);
                DateTime deadLine = businessCalendar.CalculateDeadLine(hour, startDate);

                finishDate.Text = deadLine.ToString();
                ErrorLabel.Visible = false;
            }
            catch (System.FormatException)
            {
                ErrorLabel.Visible = true;
            }
        }

        
    }
}