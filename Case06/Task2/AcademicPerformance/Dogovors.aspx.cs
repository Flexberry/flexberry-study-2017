using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AcademicPerformance.Objects;
using AcademicPerformance.DAL;

namespace AcademicPerformance
{
    public partial class Dogovors : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
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
                ClearControls();
                Session["IsDogovorAdded"] = null;
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            var договор = new Договор()
            {
                номерДоговора = TextBoxNumber.Text,
                Информация = TextBoxName.Text,
            };

            DataServiceProvider.Current.AddDogovor(договор);
            Session["IsDogovorAdded"] = true;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ButtonClear_OnClick(object sender, EventArgs e)
        {
            DataServiceProvider.Current.ClearDogovors();
            Session["IsDogovorAdded"] = true;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void ClearControls()
        {
            TextBoxNumber.Text = string.Empty;
        }
    }
}