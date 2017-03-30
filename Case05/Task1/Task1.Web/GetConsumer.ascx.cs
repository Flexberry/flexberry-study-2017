using System;
using Task1.DAL;

namespace Web
{
    public partial class GetConsumer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelConsumer.Visible = false;
            PanelConsumerNotFound.Visible = false;
            LabelName.Text = string.Empty;
            LabelDateReg.Text = string.Empty;
            LabelAccount.Text = string.Empty;
        }

        protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
            var consumer = DataServiceProvider.Current.GetConsumer(TextBoxCode.Text);
            var consumer2 = DataServiceProvider.Current.GetConsumer2(TextBoxCode.Text);
            if (consumer != null)
            {
                LabelName.Text = $"{consumer.Name}";
                LabelDateReg.Text = consumer.DateReg.ToString("D");
                LabelAccount.Text = consumer.Account.ToString();
                PanelConsumer.Visible = true;
            }
            else
            {
                if (consumer2 != null)
                {
                    LabelName.Text = $"{consumer2.Name}";
                    LabelDateReg.Text = consumer2.DateReg.ToString("D");
                    LabelAccount.Text = consumer2.Account.ToString();
                    PanelConsumer.Visible = true;
                }
                else
                {
                    PanelConsumerNotFound.Visible = true;
                }
            }
        }
    }
}