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
    public partial class Trainings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["sportsman"] != null)
            {
                string sportsman = Request.Params["sportsman"];
                var arr = sportsman.Split(';');

                Sportsman sportsmen = new Sportsman()
                {
                    LastName = arr[0],
                    FirstName = arr[1],
                    Patronymic = arr[2],
                    CodeGroup = arr[3]
                };

                Sportsmen.Text ="Спортсмен: " + arr[0] + ' ' + arr[1] + ' ' + arr[2];

                Training training = new Training()
                {
                    sportsman = sportsmen,
                    TimeInZones = new Dictionary<int, TimeSpan>()
                };

                DataService.AddTraining(training);
            }
        }
    }
}