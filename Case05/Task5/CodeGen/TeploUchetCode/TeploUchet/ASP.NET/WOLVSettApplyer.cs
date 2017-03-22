namespace ICSSoft.STORMNET.Web
{
    /// <summary>
    /// Тюнер для WOLV'а доступный для прикладных программистов.
    /// </summary>
    public class WOLVSettApplyer : AjaxControls.WolvSettApplyer
    {
        /// <summary>
        /// Применение настроек внешнего вида для WOLV'а с прикладной логикой.
        /// Важно: перед применением настроек должен вызываться базовый (технологический)
        /// метод SettingsApply.
        /// </summary>
        /// <param name="wolv">WOLV который необходимо настроить.</param>
        public override void SettingsApply(AjaxControls.WebObjectListView wolv)
        {
            base.SettingsApply(wolv);
        }

        /// <summary>
        /// Метод применения настроек, вызывающийся в случае, когда WOLV находится на
        /// форме лукапа.
        /// </summary>
        /// <param name="wolv">WOLV, к которому надо применить настройки.</param>
        public override void ApplyLookUpSettings(AjaxControls.WebObjectListView wolv)
        {
        }
    }
}