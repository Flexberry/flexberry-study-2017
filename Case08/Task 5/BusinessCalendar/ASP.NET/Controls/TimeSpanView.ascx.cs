using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace IIS.BusinessCalendar.Controls
{
    using System.Web.Script.Serialization;
    using System.Collections.Generic;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Web.Tools;

    public partial class TimeSpanView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageContentManager.AttachExternalFile("/shared/script/jquery-1.7.2.min.js");
            PageContentManager.AttachExternalFile("/shared/script/businessTimeSpans.js");
            PageContentManager.AttachExternalFile("/CSS/businessTimeSpans.css");
            PageContentManager.AttachExternalFile("/shared/script/TSRealTimeLogic.js");
        }

        public List<TimeSpan> Value
        {
            get
            {
                var jsArray = Request.Form[TimeSpansJson.Name];
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Deserialize<List<TimeSpan>>(jsArray);
            }
            set
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TimeSpansJson.Value = ser.Serialize(value);
            }
        }
        public ObjectStatus Status
        {
            get
            {
                int inputStatus = Convert.ToInt32(TimeSpanViewStatus.Value);
                ObjectStatus os = new ObjectStatus();
                switch (inputStatus)
                {
                    case 0: os = ObjectStatus.UnAltered;
                        break;
                    case 1: os = ObjectStatus.Altered;
                        break;
                    default: os = ObjectStatus.Created;
                        break;
                }
                return os;
            }
        }
    }
}