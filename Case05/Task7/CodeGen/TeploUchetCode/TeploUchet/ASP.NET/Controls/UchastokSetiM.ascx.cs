using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeploCorp.TeploUchet;

namespace Web
{
    public partial class UchastokSetiM : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string strUser = HttpContext.Current.User.Identity.Name;
            var _dataService = (SQLDataService)DataServiceProvider.DataService;
            var _Inspector = _dataService.Query<Инспектор>(Инспектор.Views.ИнспекторL).FirstOrDefault(x => x.Логин == strUser); // получаем объект инспектор по логину

            

            //MainPanel.Controls.Add(panel);
        }

        protected void Preload()
        {
            var x = 5 + 5;
        }



    }
}