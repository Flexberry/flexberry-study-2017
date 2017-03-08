using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logic;
using Task1.Objects;
using Task1.DAL;

namespace Web
{
    public partial class AddConsumers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                var CodeObject = Request.Params["code"];
                DataServiceProvider.Current.DeleteConsumer(CodeObject);
                var newUri = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.Url.Query, StringComparison.Ordinal));
                Response.Redirect(newUri);
            }

            ConsumersRepeater.DataSource = DataServiceProvider.Current.GetAllConsumers();
            ConsumersRepeater.DataBind();

            if (Session["IsConsumerAdded"] != null && (bool)Session["IsConsumerAdded"])
            {
                ClearControls();
                Session["IsConsumerAdded"] = null;
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {            

            if ( CheckUlong(TextBoxAccount.Text) )
            {
                TextBoxAccountError.CssClass = "hidden";
                var consumer = new Consumer()
                {
                    Name = TextBoxName.Text,
                    DateReg = CalendarReg.SelectedDate,
                    Account = Convert.ToUInt64(TextBoxAccount.Text),
                };

                try
                {
                    DataServiceProvider.Current.AddConsumer(consumer);
                    Session["IsConsumerAdded"] = true;
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                catch  
                {
                    TextBoxNameError.CssClass = "text-danger";
                }
            }
            else
            {                
                TextBoxAccountError.CssClass = "text-danger";
            }
        }    

        protected void ButtonClear_OnClick(object sender, EventArgs e)
        {
            DataServiceProvider.Current.ClearConsumers();
            Session["IsConsumerAdded"] = true;
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void ClearControls()
        {
            TextBoxName.Text = string.Empty;
            CalendarReg.SelectedDate = DateTime.Now;
            TextBoxAccount.Text = string.Empty;
        }
        //проверка поля лс на корректность ввода(только цифры)
        private static Boolean CheckUlong(string value)
        {
            try
            {
                ulong x = Convert.ToUInt64(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}