﻿/*flexberryautogenerated="true"*/
namespace IIS.Product_58826
{
    using System;
    using ICSSoft.STORMNET.Web.Controls;

    using Resources;

    public partial class ВыборПриоритетаL : BaseListForm<ВыборПриоритета>
    {
        /// <summary>
        /// Конструктор без параметров,
        /// инициализирует свойства, соответствующие конкретной форме.
        /// </summary>
        public ВыборПриоритетаL() : base(ВыборПриоритета.Views.ВыборПриоритетаL)
        {
            EditPage = ВыборПриоритетаE.FormPath;
        }
                
        /// <summary>
        /// Путь до формы.
        /// </summary>
        public static string FormPath
        {
            get { return "~/forms/VyborPrioriteta/VyborPrioritetaL.aspx"; }
        }

        /// <summary>
        /// Вызывается самым первым в Page_Load.
        /// </summary>
        protected override void Preload()
        {
        }

        /// <summary>
        /// Вызывается самым последним в Page_Load.
        /// </summary>
        protected override void Postload()
        {
        }
    }
}
