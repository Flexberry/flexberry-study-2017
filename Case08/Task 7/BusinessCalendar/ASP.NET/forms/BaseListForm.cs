//------------------------------------------------------------------------------
// Этот класс не технологический, его можно менять в соответствии с
// потребностями проекта
//------------------------------------------------------------------------------

namespace ICSSoft.STORMNET.Web.Controls
{
    /// <summary>
    /// Базовая форма списка.
    /// </summary>
    /// <typeparam name="T">
    /// Тип отображаемых объектов.
    /// </typeparam>
    public abstract class BaseListForm<T> : AjaxControls.Forms.BaseListForm<T> where T : DataObject
    {
        /// <summary>
        /// Создание списковой формы с отложенной инициализацией представления, по которому будут зачитаны объекты данных.
        /// </summary>
        protected BaseListForm()
        {
        }

        /// <summary>
        /// Создание списковой формы с указанием имени представления, по которому будут зачитаны объекты данных.
        /// </summary>
        /// <param name="viewName">Представление по которому будут зачитаны объекты данных для списка.</param>
        protected BaseListForm(string viewName) : base(viewName)
        {
        }

        /// <summary>
        /// Создание списковой формы с указанием представления, по которому будут зачитаны объекты данных.
        /// </summary>
        /// <param name="view">Представление по которому будут зачитаны объекты данных для списка.</param>
        protected BaseListForm(View view) : base(view)
        {
        }

        /// <summary>
        /// Вызывается самым первым в OnLoad.
        /// </summary>
        protected override void Preload()
        {
            WebObjectListView1.Operations.AdjustListHeight = true;
            base.Preload();
        }
        
        /// <summary>
        /// Применение настроек к wolv лежащему на списковой форме.
        /// </summary>
        protected override void ApplyWolvSettings()
        {
            var wolvSettApplyer = new WOLVSettApplyer();
            wolvSettApplyer.SettingsApply(WebObjectListView1);
        }
    }
}