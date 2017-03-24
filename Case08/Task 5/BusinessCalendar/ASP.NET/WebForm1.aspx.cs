using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IIS.BusinessCalendar
{
    using IIS.BusinessCalendar.Controls;
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TimeSpan> tsl = new List<TimeSpan>();
            tsl.Add(new TimeSpan()
            {
                StartTimeH = 8,
                StartTimeM = 30,
                EndTimeH = 12,
                EndTimeM = 30
            });
            tsl.Add(new TimeSpan()
            {
                StartTimeH = 13,
                StartTimeM = 30,
                EndTimeH = 17,
                EndTimeM = 30
            });
            TimeSpanView1.Value = tsl;
        }
    }
}