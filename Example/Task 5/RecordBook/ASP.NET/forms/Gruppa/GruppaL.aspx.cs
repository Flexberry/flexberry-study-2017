﻿/*flexberryautogenerated="true"*/
namespace NewPlatform.RecordBook
{
    using System;
    using ICSSoft.STORMNET.Web.Controls;

    using Resources;

    public partial class ГруппаL : BaseListForm<Группа>
    {
        /// <summary>
        /// Конструктор без параметров,
        /// инициализирует свойства, соответствующие конкретной форме.
        /// </summary>
        public ГруппаL() : base(Группа.Views.ГруппаL)
        {
            EditPage = ГруппаE.FormPath;
        }
                
        /// <summary>
        /// Путь до формы.
        /// </summary>
        public static string FormPath
        {
            get { return "~/forms/Gruppa/GruppaL.aspx"; }
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
