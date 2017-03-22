namespace ICSSoft.STORMNET.Web.Controls
{
    /// <summary>
    /// Класс прикладной формы лукапов.
    /// </summary>
    public class LookUpForm : AjaxControls.Forms.LookUpForm
    {
        /// <summary>
        /// Применение настроек к wolv лежащему на форме лукапа.
        /// Переопределенный метод вызывает логику по настройке wolv из прикладного WOLVSettApplyer.
        /// </summary>
        protected override void ApplyWolvSettings()
        {
            new WOLVSettApplyer().SettingsApply(LookUpFormWOLV);
        }
    }
}