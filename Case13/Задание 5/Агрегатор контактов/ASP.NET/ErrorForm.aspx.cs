namespace ICSSoft.STORMNET.Web
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.UI;
    using AjaxControls;
    using ICSSoft.STORMNET.Web.Controls;
    using ICSSoft.STORMNET.Web.Tools;

    /// <summary>
    /// Форма, показывающая ошибку
    /// </summary>
    public partial class ErrorForm : Page
    {
        #region Constants and Fields

        /// <summary>
        /// The _context exceptions list.
        /// </summary>
        private List<WebErrorBoxRiser> _contextExceptionsList;

        /// <summary>
        /// The _ex.
        /// </summary>
        private Exception _ex;

        /// <summary>
        /// Показывать подробности
        /// </summary>
        private bool _showDetails;

        #endregion

        #region Methods

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The e. </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitShowDetails();
                this._ex = (Exception)this.Context.Items[WebParamController.STR_ErrorException];
                this._contextExceptionsList =
                    (List<WebErrorBoxRiser>)
                    HttpContext.Current.Items[WebParamController.PageFilter_WebErrorBoxExceptions];

                if (this._ex == null)
                {
                    this.MessageLabel.Text = "Сведения об ошибке отсутствуют";
                    return;
                }

                string pageErrorOccured = string.Empty;
                if (this.Context != null && this.Context.Request != null && this.Context.Request.UrlReferrer != null)
                {
                    pageErrorOccured = this.Context.Request.UrlReferrer.OriginalString;
                }

                int i = 0;
                string arr = null;

                bool withInnerExceptions = this.WithInnerExceptions();
                if (withInnerExceptions)
                {
                    this.SelectErr.Items.Clear();
                }
                else
                {
                    this.SelectErr.Visible = false;
                    this.ErrorNumCaption.Visible = false;
                }

                while (this._ex != null)
                {
                    string controlId = this.AddNewExceptionPanel(this._ex, "ep" + i, i != 0, this._showDetails);
                    this._ex = this._ex.InnerException;
                    this.SelectErr.Items.Add(i.ToString(CultureInfo.InvariantCulture));
                    arr += (arr == null ? "'" : ",'") + controlId + "'";
                    i++;
                }

                string httpContextExceptionsIds = this.GetHttpContextExceptions(i);
                if (httpContextExceptionsIds != null)
                {
                    arr += "," + httpContextExceptionsIds;
                }

                if (arr != null && withInnerExceptions)
                {
                    this.SelectErr.Attributes["onchange"] = "OnErrorChanged(this,[" + arr + "])";
                }

                this.Context.Items[WebParamController.STR_ErrorException] = null;

                // отобразим пользователю общее сообщение об ошибке 
                if (!string.IsNullOrEmpty(pageErrorOccured))
                {
                    this.MessageLabel.Text = "<br>Чтобы вернуться назад, кликните <a href='" + pageErrorOccured
                                             + "'>здесь</a>.<br><br>";
                }
            }
            catch (Exception ex)
            {
                // если исключение вызвано кодом, написанным выше 
                // выведем сообщение об ошибке и StackTrace 
                this.MessageLabel.Text = ex.Message + "<br>";
                this.MessageLabel.Text += ex.StackTrace;
            }
        }

        /// <summary>
        /// Динамически добавить панель с информацией об ошибке
        /// </summary>
        /// <param name="exc"> Исключение, которое отображается на этой панели </param>
        /// <param name="controlId"> controlId контрола </param>
        /// <param name="hidden"> скрыть или нет </param>
        /// <param name="showDetails"> Показывать детали </param>
        /// <returns> ClientID главной панели контрола </returns>
        private string AddNewExceptionPanel(Exception exc, string controlId, bool hidden, bool showDetails)
        {
            var ctrl = new ExceptionPanel
                {
                    ID = controlId,
                    ExceptionToShow = exc,
                    ShowDetails = showDetails,
                    EnableViewState = false,
                    Hidden = hidden
                };
            this.Panel4Controls.Controls.Add(ctrl);
            this.ScriptHolder.Text += ctrl.Script + Environment.NewLine;
            return ctrl.MainPanelClientID;
        }

        /// <summary>
        /// The get http context exceptions.
        /// </summary>
        /// <param name="num">
        /// The num.
        /// </param>
        /// <returns>
        /// The get http context exceptions.
        /// </returns>
        private string GetHttpContextExceptions(int num = 0)
        {
            if (this._contextExceptionsList == null)
            {
                return null;
            }

            int i = num;
            string arr = null;

            var reversedExceptionsList = new List<WebErrorBoxRiser>(this._contextExceptionsList.ToArray());
            reversedExceptionsList.Reverse();
            foreach (WebErrorBoxRiser riser in reversedExceptionsList)
            {
                Exception ex = riser.Exception;

                while (ex != null)
                {
                    string idCtrl = this.AddNewExceptionPanel(ex, "ep" + i, i != 0, this._showDetails);
                    ex = ex.InnerException;
                    this.SelectErr.Items.Add(i.ToString());
                    arr += (arr == null ? "'" : ",'") + idCtrl + "'";
                    i++;
                }
            }

            return arr;
        }

        /// <summary>
        /// The init show details.
        /// </summary>
        private void InitShowDetails()
        {
            this._showDetails = true;
            string showDetailsConf = WebConfigurationManager.AppSettings["ShowErrorDetails"];
            if (!string.IsNullOrEmpty(showDetailsConf))
            {
                this._showDetails = showDetailsConf.ToLower() == "true";
            }
        }

        /// <summary>
        /// Содержит или нет текущее исключение _ex внутренние исключения
        /// </summary>
        /// <returns> true, если содержит/// </returns>
        private bool WithInnerExceptions()
        {
            bool res = true;

            if (this._ex == null)
            {
                res = false;
            }
            else
            {
                if (this._ex.InnerException == null)
                {
                    res = false;
                }
            }

            // Нужно посмотреть в HttpContext
            if (!res && this._contextExceptionsList != null)
            {
                res = this._contextExceptionsList.Count > 0;
            }

            return res;
        }

        #endregion
    }
}