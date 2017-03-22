namespace WebApplication
{
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Web.AjaxControls;
    using ICSSoft.STORMNET.Web.AjaxControls.Forms;
    using ICSSoft.STORMNET.Web.Tools;

    using NewPlatform.Flexberry.Web.Themeable;

    /// <summary>
    /// Класс мастер-страницы приложения.
    /// </summary>
    public partial class Site1 : MasterPage
    {
        /// <summary>
        /// Перечисление типов разметки страницы.
        /// <remarks>
        /// Содержит список возможных вариантов разметки страниц приложения, который может
        /// быть изменен на конкретном прикладном проекте.
        /// Выбранный тип разметки добавляется в качестве идетификатора к тэгу "body".
        /// Разметка настраивается при помощи CSS.
        /// </remarks>
        /// </summary>
        protected enum PageLayout
        {
            /// <summary>
            /// Отображение только основного содержимого страницы.
            /// </summary>
            [Caption("M")]
            MainColumn,

            /// <summary>
            /// Отображение основного содержимого страницы и левого блока (меню).
            /// </summary>
            [Caption("LM")]
            LeftAndMainColumns,

            /// <summary>
            /// Отображение основного содержимого страницы, левого блока (меню)
            /// и правого блока (по умолчанию отсутствует в шаблоне).
            /// </summary>
            [Caption("LMR")]
            LeftMainAndRightColumns,

            /// <summary>
            /// Отображение основного содержимого страницы и правого блока (по умолчанию отсутствует в шаблоне).
            /// </summary>
            [Caption("MR")]
            MainAndRightColumns
        }

        /// <summary>
        /// Текущий тип разметки страницы.
        /// </summary>
        private PageLayout _layout = PageLayout.LeftAndMainColumns;

        /// <summary>
        /// Метод для получения CSS-класса тэга "body" на основе текущего типа разметки.
        /// </summary>
        /// <returns>CSS-класс тэга "body".</returns>
        protected string GetBodyClass()
        {
            return EnumCaption.GetCaptionFor(_layout);
        }

        /// <summary>
        /// Обработчик события инициализации страницы (<see cref="E:System.Web.UI.Control.Init" />).
        /// </summary>
        /// <param name="e">Аргументы события.</param>
        protected override void OnInit(EventArgs e)
        {
            PageContentManager.AttachExternalFile("/shared/script/jquery-1.7.2.min.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.cookie.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.disable.text.select.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.countdown.pack.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery-ui.min.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.maskedinput-1.2.2.js");
            PageContentManager.AttachExternalFile("/shared/script/thickbox.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.maxlength.min.js");
            PageContentManager.AttachExternalFile("/shared/script/master.page.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.alerts.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.sticky.js");
            PageContentManager.AttachExternalFile("/shared/script/jquery.ics.js");

            base.OnInit(e);
        }

        /// <summary>
        /// Обработчик события загрузки страницы.
        /// </summary>
        /// <param name="e">Аргументы события.</param>
        protected override void OnLoad(EventArgs e)
        {
            // При открытии окна в качестве редактора лукапа или в дочернем окне следует установить
            // соответствующий тип разметки страницы.
            string lookUpQueryString = Request[WebParamController.OpenedFromLookupParamName];
            bool openAsLookUp = !string.IsNullOrEmpty(lookUpQueryString) && lookUpQueryString.ToLower().Equals("true");

            string newWindowQueryString = Request[WebParamController.OpenedInNewWindowParamName];
            bool openAsNewWindow = !string.IsNullOrEmpty(newWindowQueryString) && newWindowQueryString.ToLower().Equals("true");

            if (openAsLookUp || openAsNewWindow)
            {
                _layout = PageLayout.MainColumn;
            }

            LoadCurrentTheme();
            ApplyTreeViewCookie();

            fio.Text = Context.User.Identity.Name;

            base.OnLoad(e);
        }

        /// <summary>
        /// Обработчик события перед рендерингом страницы.
        /// </summary>
        /// <param name="e">Аргументы события.</param>
        protected override void OnPreRender(EventArgs e)
        {
            // При включенных StyleSheetThemes мета-тэг X-UA-Compatible не будет первым в "head" и может не быть обработан корректно:
            // http://connect.microsoft.com/VisualStudio/feedback/details/581278/setting-x-ua-compatible-meta-tag-in-asp-net-4-0-site-doesn-t-work-yes-it-s-at-the-top
            // http://stackoverflow.com/questions/6156639/x-ua-compatible-is-set-to-ie-edge-but-it-still-doesnt-stop-compatibility-mode
            // Другой вариант - передача HTTP-заголовка.
            var metatag = new HtmlMeta();
            metatag.Attributes.Add("http-equiv", "X-UA-Compatible");
            metatag.Attributes.Add("content", "IE=edge");
            Page.Header.Controls.AddAt(0, metatag);

            // Установка класса тэга "body" на основе текущего типа разметки.
            // Устанавливается в Code Behind для корректной работы PlaceholderPageContentConnector
            // при отсутствии плейсхолдеров "FlexberryScripts" и "FlexberryRawHtml" ("body"
            // должен быть отдельным контролом, а не входить в LiteralControl).
            // Если PlaceholderPageContentConnector не используется, то установку класса
            // можно перенести в разметку.
            body.AddCssClass(GetBodyClass());

            base.OnLoad(e);
        }

        /// <summary>
        /// Обработчик клика по кнопке "Выход".
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        protected void ExitButtonClickHandler(object sender, EventArgs e)
        {
            new WebLockHelper().ClearWebLock(Context.User.Identity.Name);
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        /// <summary>
        /// Обработчик изменения значения в списке выбора темы оформления.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        protected void OnThemeChangedHandler(object sender, EventArgs e)
        {
            ThemeService.Current.Theme = themesList.SelectedValue;

            // Для применения изменений требуется перезагрузить страницу т.к.
            // настройки тем могут быть изменены не позже OnInit.
            Response.Redirect(Request.RawUrl, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// Метод для установки текущей темы оформления в список выбора <see cref="themesList"/>.
        /// </summary>
        private void LoadCurrentTheme()
        {
            themesList.Enabled = ThemeService.Current.CanBeChanged;
            if (!IsPostBack)
            {
                // Только для технологических страниц.
                var page = Page as BasePage;
                if (page != null)
                    themesList.SelectedValue = ThemeService.Current.Theme;
            }
        }

        /// <summary>
        /// Метод для настройки видимости меню на основе сохраненных сookies.
        /// </summary>
        private void ApplyTreeViewCookie()
        {
            // чтение Cookies для TreeView
            var cookie = HttpContext.Current.Request.Cookies["treeView"];
            if (cookie == null || cookie.Value == "1")
            {
                // Показать TreeView
                pageForm.Attributes["class"] = "page-form treeview-visible";
                treeviewHideSpan.Attributes["class"] = String.Empty;
                treeviewShowSpan.Attributes["class"] = "Hide";
            }
            else
            {
                // Скрыть TreeView
                pageForm.Attributes["class"] = "page-form treeview-hidden";
                treeviewHideSpan.Attributes["class"] = "Hide";
                treeviewShowSpan.Attributes["class"] = String.Empty;
            }
        }
    }
}