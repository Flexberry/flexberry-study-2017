﻿/*flexberryautogenerated="true"*/
namespace IIS.BusinessCalendar
{
    using System;
    using ICSSoft.STORMNET.Web.Controls;

    using Resources;

    public partial class Flexberry_ExceptionDayL : BaseListForm<ExceptionDay>
    {
        /// <summary>
        /// Конструктор без параметров,
        /// инициализирует свойства, соответствующие конкретной форме.
        /// </summary>
        public Flexberry_ExceptionDayL() : base(ExceptionDay.Views.Flexberry_ExceptionDayL)
        {
            EditPage = Flexberry_ExceptionDayE.FormPath;
        }
                
        /// <summary>
        /// Путь до формы.
        /// </summary>
        public static string FormPath
        {
            get { return "~/forms/ExceptionDay/Flexberry_ExceptionDayL.aspx"; }
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
