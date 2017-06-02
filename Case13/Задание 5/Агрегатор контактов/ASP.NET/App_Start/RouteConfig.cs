namespace ICSSoft.STORMNET.Web
{
    using System.Web.Routing;

	using ICSSoft.STORMNET.Web.Tools;
    using NewPlatform.Flexberry.Web.Routing;

    /// <summary>
    /// Класс конфигурации маршрутов приложения.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Метод для регистрации маршрутов в коллекции.
        /// При изменении адреса страниц не забудьте произвести соответсвующие изменения в SiteMap.
        /// </summary>
        /// <param name="routes">Коллекция маршрутов, в которую необходимо добавить новые элементы.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Маршруты до технологических страниц.
            routes.AddDynamicPageRoute("flexberry/AuditEntitiesList", DynamicPageIdentifier.AuditEntitiesList);
            routes.AddDynamicPageRoute("flexberry/AuditEntityByObjectView/{PK}", DynamicPageIdentifier.AuditEntityByObjectView);
            routes.AddDynamicPageRoute("flexberry/AuditEntityByObjectsList", DynamicPageIdentifier.AuditEntityByObjectsList);
            routes.AddDynamicPageRoute("flexberry/AuditEntityView/{PK}", DynamicPageIdentifier.AuditEntityView);

            routes.AddDynamicPageRoute("flexberry/LocksList", DynamicPageIdentifier.LocksList);

            routes.AddDynamicPageRoute("flexberry/LogList", DynamicPageIdentifier.LogList);
            routes.AddDynamicPageRoute("flexberry/LogEntry/{PK}", DynamicPageIdentifier.LogEntry);

            /* Регистрируем маршруты на технологические формы отчетов только в том случае, если загружена сборка
             ICSSoft.STORMNET.Web.Reports, т.к. она вынесена в отдельный пакет с веб-отчетами.
            */
            if (AssemblyHelper.IsWebReportsPackageLoaded())
            {
                routes.AddDynamicPageRoute("flexberry/ModuleReportTemplateEdit/{PK}", DynamicPageIdentifier.ModuleReportTemplateEdit);

                routes.AddDynamicPageRoute("flexberry/ReportDocumentEdit/{PK}", DynamicPageIdentifier.ReportDocumentEdit);
                routes.AddDynamicPageRoute("flexberry/ReportDocumentsList", DynamicPageIdentifier.ReportDocumentsList);
                routes.AddDynamicPageRoute("flexberry/ReportExportTaskView/{PK}", DynamicPageIdentifier.ReportExportTaskView);
                routes.AddDynamicPageRoute("flexberry/ReportExportTasksList", DynamicPageIdentifier.ReportExportTasksList);
                routes.AddDynamicPageRoute("flexberry/ReportTemplateEdit/{PK}", DynamicPageIdentifier.ReportTemplateEdit);
                routes.AddDynamicPageRoute("flexberry/ReportTemplatesList", DynamicPageIdentifier.ReportTemplatesList);
                routes.AddDynamicPageRoute("flexberry/ReportTypeEdit/{PK}", DynamicPageIdentifier.ReportTypeEdit);
                routes.AddDynamicPageRoute("flexberry/ReportTypesList", DynamicPageIdentifier.ReportTypesList);
            }

            routes.AddDynamicPageRoute("flexberry/SecurityClassEdit/{PK}", DynamicPageIdentifier.SecurityClassEdit);
            routes.AddDynamicPageRoute("flexberry/SecurityClassEdit", DynamicPageIdentifier.SecurityClassNew);
            routes.AddDynamicPageRoute("flexberry/SecurityClassesList", DynamicPageIdentifier.SecurityClassesList);
            routes.AddDynamicPageRoute("flexberry/SecurityRoleEdit/{PK}", DynamicPageIdentifier.SecurityRoleEdit);
            routes.AddDynamicPageRoute("flexberry/SecurityRoleEdit", DynamicPageIdentifier.SecurityRoleNew);
            routes.AddDynamicPageRoute("flexberry/SecurityRolesList", DynamicPageIdentifier.SecurityRolesList);
            routes.AddDynamicPageRoute("flexberry/SecurityUserEdit/{PK}", DynamicPageIdentifier.SecurityUserEdit);
            routes.AddDynamicPageRoute("flexberry/SecurityUserEdit", DynamicPageIdentifier.SecurityUserNew);
            routes.AddDynamicPageRoute("flexberry/SecurityUsersList", DynamicPageIdentifier.SecurityUsersList);
            routes.AddDynamicPageRoute("flexberry/SecurityGroupEdit/{PK}", DynamicPageIdentifier.SecurityGroupEdit);
            routes.AddDynamicPageRoute("flexberry/SecurityGroupEdit", DynamicPageIdentifier.SecurityGroupNew);
            routes.AddDynamicPageRoute("flexberry/SecurityGroupsList", DynamicPageIdentifier.SecurityGroupsList);

            routes.AddDynamicPageRoute("flexberry/Version", DynamicPageIdentifier.Version);

            routes.AddDynamicPageRoute("flexberry/Cache", DynamicPageIdentifier.CacheAdmin);
        }
    }
}