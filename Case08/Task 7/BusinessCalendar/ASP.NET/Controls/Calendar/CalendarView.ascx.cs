using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IIS.BusinessCalendar.Controls.Calendar
{
    using System.Web.Script.Serialization;
    using ICSSoft.STORMNET.Web.Tools;
    public partial class CalendarView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageContentManager.AttachExternalFile("/shared/script/jquery-1.7.2.min.js");
            PageContentManager.AttachExternalFile("/Controls/Calendar/CSS/CalendarView.css");
            PageContentManager.AttachExternalFile("/Controls/Calendar/JavaScript/jquery.CalendarView.js");
        }

        public List<ExcDay> DataSource
        {
            get
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Deserialize<List<ExcDay>>(CalendarDataSource.Value);
            }
            set
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                CalendarDataSource.Value = ser.Serialize(value);
            }
        }
    }
}