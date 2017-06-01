namespace ICSSoft.STORMNET.Web
{
    using System;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Routing;

    using ICSSoft.STORMNET.Web.Tools;
    using ICSSoft.STORMNET.Web.Tools.Monads;

    using Resources;

    /// <summary>
    /// Класс ASP.NET прилжения.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Значение параметра конфигурации, отвечающего за отключение кэширования.
        /// </summary>
        private bool? _noCache;

        /// <summary>
        /// Обработчик события начала запроса к приложению.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (_noCache == null)
            {
                string noCache = WebConfigurationManager.AppSettings["NoCache"];
                _noCache = !string.IsNullOrEmpty(noCache) && noCache.ToLower() == "true";
            }

            if (_noCache.Value)
            {
                CacheHelper.ClearCache();
            }
        }

        /// <summary>
        /// Обработчик события запуска приложения.
        /// Все зависимости (сервисы) должны разрешаться именно тут.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ServiceConfig.ConfigureServices();
        }

        /// <summary>
        /// Обработчик события завершения приложения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        protected void Application_End(object sender, EventArgs e)
        {
            // Для того, чтобы все объекты, которые сейчас в кэше, но должны обновиться в базе обновились.
            CacheHelper.RemoveFromCache(string.Empty);
        }

        /// <summary>
        /// Обработчик события возникновения необработанного исключения.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            string noHideError = WebConfigurationManager.AppSettings["NoHideError"];

            if (string.IsNullOrEmpty(noHideError) || noHideError.ToLower() != "true")
            {
                try
                {
                    // Ловим последнее возникшее исключение 
                    Exception lastError = Server.GetLastError();

                    if (lastError != null)
                    {
                        // Записываем непосредственно исключение, вызвавшее данное, в 
                        HttpContext.Current.Items[WebParamController.STR_ErrorException] = lastError;

                        string strErr = "App_error";
                        if (HttpContext.Current != null)
                            if (HttpContext.Current.User != null)
                                if (HttpContext.Current.User.Identity != null)
                                    if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                                        strErr += " User:" + HttpContext.Current.User.Identity.Name;

                        LogService.Log.Error(strErr, lastError);
                    }

                    // Обнуление ошибки на сервере 
                    Server.ClearError();

                    // Перенаправление на свою страницу отображения ошибки
                    if ((lastError as HttpException).Return(x => x.GetHttpCode() == 404, false))
                    {
                        Server.Transfer("~/Error404.aspx");
                    }
                    else
                    {
                        Server.Transfer("~/ErrorForm.aspx");
                    }
                }
                catch (Exception)
                {
                    // если мы всё же приходим сюда - значит обработка исключения 
                    // сама сгенерировала исключение, мы ничего не делаем, чтобы 
                    // не создать бесконечный цикл 
                    Response.Write(Resource.Crirical_Error);
                }
            }
        }
    }
}