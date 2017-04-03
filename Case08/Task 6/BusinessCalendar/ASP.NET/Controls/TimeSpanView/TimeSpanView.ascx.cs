using System;
using System.Web.UI;

namespace IIS.BusinessCalendar.Controls.TimeSpanView
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
            PageContentManager.AttachExternalFile("/Controls/TimeSpanView/JavaScript/jquery.TimeSpans.js");
            PageContentManager.AttachExternalFile("/Controls/TimeSpanView/CSS/TimeSpans.css");
            if (Page.IsPostBack)
            {
                TimeSpansJson.Value = Request[TimeSpansJson.Name];
            }
        }

        public List<TimeSpan> Text
        {
            get
            {
                var jsArray = TimeSpansJson.Value;
                List<TimeSpan> result;
                if(jsArray != "")
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    result = ser.Deserialize<List<TimeSpan>>(jsArray);
                }
                else
                {
                    result = new List<TimeSpan>();
                }
                return result;
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
                    case 0:
                        os = ObjectStatus.UnAltered;
                        break;
                    case 1:
                        os = ObjectStatus.Altered;
                        break;
                    default:
                        os = ObjectStatus.Created;
                        break;
                }
                return os;
            }
        }
    }
}