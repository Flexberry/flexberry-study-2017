using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Web.AjaxControls;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using ICSSoft.STORMNET.FunctionalLanguage;
using ICSSoft.STORMNET.FunctionalLanguage.SQLWhere;
using System;
using System.Linq;
using TeploCorp.TeploUchet;

namespace Web
{
    public partial class GetConsumer : System.Web.UI.UserControl
    {
        //private object _Inspector;

        protected void Page_Load(object sender, EventArgs e)
        {
            PanelConsumer.Visible = false;
            PanelConsumerNotFound.Visible = false;
            LabelName.Text = string.Empty;
            LabelDateReg.Text = string.Empty;
            LabelAccount.Text = string.Empty;
        }
        /// <summary>
        /// Вызывается самым первым в Page_Load.
        /// </summary>
        protected void Preload()
        {
        }

        protected void ButtonFind_OnClick(object sender, EventArgs e)
        {
            string codeFromForm = TextBoxCode.Text;
            var ids = (SQLDataService)DataServiceProvider.DataService;

            var _consumer = ids.Query<Объект>(Объект.Views.ОбъектL)
                    .Where(x => x.Наименование != null)
                    .FirstOrDefault(x => x.КодОбъекта == codeFromForm); 

            if ( _consumer != null)
            {
                LabelName.Text = _consumer.Наименование;
                LabelDateReg.Text = _consumer.ДатаРегистрации.Day.ToString() + ".";
                LabelDateReg.Text += _consumer.ДатаРегистрации.Month.ToString() + ".";
                LabelDateReg.Text += _consumer.ДатаРегистрации.Year.ToString() ;
                LabelAccount.Text = _consumer.ЛицСчет.ToString();
                PanelConsumer.Visible = true;
            }
            else
            {
                PanelConsumerNotFound.Visible = true;
            }
        }
    }
}