﻿/*flexberryautogenerated="false"*/

namespace IIS.BusinessCalendar
{
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Security;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Web.Controls;
    using ICSSoft.Services;
    using ICSSoft.STORMNET.Web.AjaxControls;
    
    public partial class CalendarE : BaseEditForm<Calendar>
    {
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public CalendarE()
            : base(Calendar.Views.CalendarE)
        {
        }

        /// <summary>
        /// Путь до формы.
        /// </summary>
        public static string FormPath
        {
            get { return "~/forms/Calendar/CalendarE.aspx"; }
        }

        /// <summary>
        /// Вызывается самым первым в Page_Load.
        /// </summary>
        protected override void Preload()
        {
        }

        /// <summary>
        /// Здесь лучше всего писать бизнес-логику, оперируя только объектом данных.
        /// </summary>
        protected override void PreApplyToControls()
        {
            if(Request["PK"] != null)
            {
                BtnDays.Visible = true;
                BtnWeek.Visible = true;
            }
            else
            {
                BtnDays.Visible = false;
                BtnWeek.Visible = false;
            }
        }

        /// <summary>
        /// Здесь лучше всего изменять свойства контролов на странице,
        /// которые не обрабатываются WebBinder.
        /// </summary>
        protected override void PostApplyToControls()
        {
            var sm = DataServiceProvider.DataService.SecurityManager;
            if (!(sm.AccessObjectCheck(typeof(Calendar), tTypeAccess.Update, false) || sm.AccessObjectCheck(typeof(Calendar), tTypeAccess.Full, false)))
            {
                SaveBtn.Visible = false;
                SaveAndCloseBtn.Visible = false;
                ctrlName.Enabled = false;
            };
            Page.Validate();
        }

        /// <summary>
        /// Вызывается самым последним в Page_Load.
        /// </summary>
        protected override void Postload()
        {
        }

        /// <summary>
        /// Валидация объекта для сохранения.
        /// </summary>
        /// <returns>true - продолжать сохранение, иначе - прекратить.</returns>
        protected override bool PreSaveObject()
        {
            return base.PreSaveObject();
        }

        /// <summary>
        /// Нетривиальная логика сохранения объекта.
        /// </summary>
        /// <returns>Объект данных, который сохранился.</returns>
        protected override DataObject SaveObject()
        {
            return base.SaveObject();
        }

        protected void BtnDays_Click(object sender, System.EventArgs e)
        {
            try
            {
                string PK = Request["PK"];
                Session["CalendarID"] = Request["PK"];
                Response.Redirect("~/forms/ExceptionDay/ExceptionDayL.aspx?CalendarID=" + PK);
            }
            catch (System.NullReferenceException)
            {
                throw;
            }
        }

        protected void BtnWeek_Click(object sender, System.EventArgs e)
        {
            try
            {
                string PK = Request["PK"];
                Session["CalendarID"] = Request["PK"];
                Response.Redirect("~/forms/Week/WeekL.aspx?CalendarID=" + PK);
            }
            catch (System.NullReferenceException)
            {
                throw;
            }
        }
    }
}