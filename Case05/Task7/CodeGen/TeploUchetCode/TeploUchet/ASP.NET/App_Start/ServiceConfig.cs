namespace ICSSoft.STORMNET.Web
{
    using ICSSoft.Services;
    using ICSSoft.STORMNET.Business.Audit;
    using ICSSoft.STORMNET.Web.AjaxControls;
    using ICSSoft.STORMNET.Web.Tools;

    using Microsoft.Practices.Unity;

    using NewPlatform.Flexberry.Services;
    using NewPlatform.Flexberry.Web.Themeable;

    /// <summary>
    /// Класс конфигурации сервисов приложения.
    /// </summary>
    public static class ServiceConfig
    {
        /// <summary>
        /// Метод для конфигурации всех сервисов прилоежния.
        /// </summary>
        public static void ConfigureServices()
        {
            IUnityContainer container = UnityFactory.CreateContainer();
            
            // Сервис аудита.
            AuditSetter.InitAuditService(BridgeToDS.GetDataService());

            // Сервис тем оформления.
            ThemeService.Current = container.Resolve<IThemeService>();
            
            // Настройки лукапа.
            BaseMasterEditorLookUp.ChangeLookUpSettings = FormUtils.ChangeLookUpSettings;

            // Менеджер расширенных ограничений.
            if (container.IsRegistered<IAdvLimitManager>())
                AdvLimitManager.Current = container.Resolve<IAdvLimitManager>();

            // Сервис настроек пользователя.
            if (container.IsRegistered<IUserSettingsService>())
                UserSettingsService.Current = container.Resolve<IUserSettingsService>();
            else
                LogService.LogWarn("IUserSettingsService не сконфигурирован в Unity. Будет использована реализация по умолчанию.");
        }
    }
}