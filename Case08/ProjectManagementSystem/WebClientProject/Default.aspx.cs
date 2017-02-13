using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebClientProject
{
    using System.Globalization;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WorkTimeLibrary;
    using ManagementSystemObjects;

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

                WorkTimeBuilder wtb = new WorkTimeBuilder();
                DeadLineCalculator deadLineCalculator = new DeadLineCalculator();
                DateTime deadLine = deadLineCalculator.CalculateDeadLine(hour, startDate, wtb);


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