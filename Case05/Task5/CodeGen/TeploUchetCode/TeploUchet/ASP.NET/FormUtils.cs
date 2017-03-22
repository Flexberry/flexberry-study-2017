using System;

namespace ICSSoft.STORMNET.Web
{
    using ICSSoft.STORMNET.Web.AjaxControls;
    using ICSSoft.STORMNET;
    using Resources;

    /// <summary>
    /// Статические утилиты для работы с формами
    /// </summary>
    public static class FormUtils
    {
        /// <summary>Смена настроек лукапов</summary>
        /// <param name="lookup">Лукап, которому меняются настройки</param>
        public static void ChangeLookUpSettings(BaseMasterEditorLookUp lookup)
        {
            try
            {
                Type type = Type.GetType(lookup.MasterTypeName);
                string caption = Information.GetClassCaption(type);
                lookup.LookUpFormCaption = !string.IsNullOrEmpty(caption) ? caption : Resource.Select_Value;
            }
            catch (Exception)
            {
                lookup.LookUpFormCaption = Resource.Select_Value;
            }
        }
    }
}