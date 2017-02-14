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
    public partial class PointsCalculate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCalculatePoints_OnClick(object sender, EventArgs e)
        {
            Training training = new Training()
            {
                FirstZoneMinutes = Convert.ToDouble(TextBoxM1.Text),
                FirstZoneSeconds = Convert.ToDouble(TextBoxS1.Text),
                SecondZoneMinutes = Convert.ToDouble(TextBoxM2.Text),
                SecondZoneSeconds = Convert.ToDouble(TextBoxS2.Text),
                ThirdZoneMinutes = Convert.ToDouble(TextBoxM3.Text),
                ThirdZoneSeconds = Convert.ToDouble(TextBoxS3.Text),
            };

            double points = DataService.CalculatePoints(training);
            
                LabelFirstZone.Text = $"{training.FirstZoneMinutes}м. {training.FirstZoneSeconds}c.";
                LabelSecondZone.Text = $"{training.SecondZoneMinutes}м. {training.SecondZoneSeconds}c.";
                LabelThirdZone.Text = $"{training.ThirdZoneMinutes}м. {training.ThirdZoneSeconds}c.";
            LabelPoints.Text = String.Format("{0:0.##}", points);
        }
    }
}