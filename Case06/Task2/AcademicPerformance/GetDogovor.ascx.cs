using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AcademicPerformance.DAL;
using AcademicPerformance.Objects;

namespace AcademicPerformance
{
    public partial class GetDogovor : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelDogovor.Visible = false;
            PanelDogovorIsNotFound.Visible = false;
            LabelNumber.Text = string.Empty;
            LabelInformation.Text = string.Empty;

      /*      if (Request.Params["code"] != null)
            {
                var кодДоговора = Request.Params["code"];
                DataServiceProvider.Current.DeleteDogovor(кодДоговора);
                var newUri = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.Url.Query, StringComparison.Ordinal));
                Response.Redirect(newUri);
            }

            DogovorsRepeater.DataSource = DataServiceProvider.Current.GetAllDogovors();
            DogovorsRepeater.DataBind();

            if (Session["IsDogovorAdded"] != null && (bool)Session["IsDogovorAdded"])
            {
                Session["IsDogovorAdded"] = null;
            }
        
    */

    }

        protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
           
            var договор = DataServiceProvider.Current.GetDogovor(TextBoxCode.Text);
            if (договор != null)
            {
                LabelNumber.Text = $"{договор.номерДоговора}";
                LabelInformation.Text = договор.Информация;
                PanelDogovor.Visible = true;
            }
            else
            {
                PanelDogovorIsNotFound.Visible = true;
            }
            TextBoxCode.Text = string.Empty;
        }
    }
}