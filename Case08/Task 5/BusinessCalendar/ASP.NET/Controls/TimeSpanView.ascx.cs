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
    using ICSSoft.STORMNET.Web.Tools;

    public partial class TimeSpanView : System.Web.UI.UserControl
    {
        private List<TimeSpan> fValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            PageContentManager.AttachExternalFile("/shared/script/businessTimeSpans.js");
            PageContentManager.AttachExternalFile("/CSS/businessTimeSpans.css");
        }

        public IEnumerable<TimeSpan> Value
        {
            get
            {
                var jsArray = TimeSpansJson.Value;
                JavaScriptSerializer ser = new JavaScriptSerializer();
                return ser.Deserialize<List<TimeSpan>>(jsArray);
            }
            set
            {
                this.Value = value;
            }
        }
    }
}