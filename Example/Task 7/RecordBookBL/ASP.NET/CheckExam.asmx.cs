using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ICSSoft.STORMNET;
using ICSSoft.STORMNET.Business;
using ICSSoft.STORMNET.Business.LINQProvider;

namespace NewPlatform.RecordBookBL
{
    /// <summary>
    /// Summary description for CheckExam
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CheckExam : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string[] CheckChangedMarks(ОценкаДляПроверки[] оценки)
        {
            var ds = (SQLDataService)DataServiceProvider.DataService;
            var оценкаИсправлена = СостояниеОценки.ОценкаИсправлена;

            return (
                from оценка in оценки
                let оценкиCollection = ds.Query<Оценка>(Оценка.Views.ОценкаE)
                let markChangedAgain = оценкиCollection.Count<Оценка>(m =>
                    m.__PrimaryKey.ToString() == оценка.PrimaryKey &&
                    m.Состояние == оценкаИсправлена &&
                    m.Значение != оценка.Mark) == 1
                where markChangedAgain
                select оценка.PrimaryKey).ToArray();
        }
    }

    public class ОценкаДляПроверки
    {
        public string PrimaryKey;
        public ЗначениеОценки Mark;

        public ОценкаДляПроверки() { }

        public ОценкаДляПроверки(string primaryKey, ЗначениеОценки значениеОценки)
        {
            this.PrimaryKey = primaryKey;
            this.Mark = значениеОценки;
        }
    }
}
