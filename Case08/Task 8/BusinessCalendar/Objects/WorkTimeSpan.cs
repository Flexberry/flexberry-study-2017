﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.BusinessCalendar
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business.Audit;
    using ICSSoft.STORMNET.Business.Audit.Objects;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Work time span.
    /// </summary>
    // *** Start programmer edit section *** (WorkTimeSpan CustomAttributes)

    // *** End programmer edit section *** (WorkTimeSpan CustomAttributes)
    [AutoAltered()]
    [Caption("Work time span")]
    [AccessType(ICSSoft.STORMNET.AccessType.@this)]
    [View("AuditView", new string[] {
            "StartTime as \'Start time\'",
            "EndTime as \'End time\'"})]
    [View("WorkTimeSpanE", new string[] {
            "StartTime as \'Время начала\'",
            "EndTime as \'Время окончания\'"})]
    public class WorkTimeSpan : ICSSoft.STORMNET.DataObject, IDataObjectWithAuditFields
    {
        
        private decimal fStartTime;
        
        private decimal fEndTime;
        
        private System.Nullable<System.DateTime> fCreateTime;
        
        private string fCreator;
        
        private System.Nullable<System.DateTime> fEditTime;
        
        private string fEditor;
        
        private IIS.BusinessCalendar.WorkTimeDefinition fWorkTimeDefinition;
        
        // *** Start programmer edit section *** (WorkTimeSpan CustomMembers)
        /// <summary>
        /// Метод возвращает временной промежуток без циклических ссылок
        /// </summary>
        /// <returns></returns>
        public TimeSpan ToShort()
        {
            return new TimeSpan()
            {
                StartTimeH = (int)Math.Truncate(this.StartTime),
                StartTimeM = (int)((this.StartTime - Math.Truncate(this.StartTime)) * 100),
                EndTimeH = (int)Math.Truncate(this.EndTime),
                EndTimeM = (int)((this.EndTime - Math.Truncate(this.EndTime)) * 100)
            };
        }
        // *** End programmer edit section *** (WorkTimeSpan CustomMembers)

        
        /// <summary>
        /// StartTime.
        /// </summary>
        // *** Start programmer edit section *** (WorkTimeSpan.StartTime CustomAttributes)

        // *** End programmer edit section *** (WorkTimeSpan.StartTime CustomAttributes)
        public virtual decimal StartTime
        {
            get
            {
                // *** Start programmer edit section *** (WorkTimeSpan.StartTime Get start)

                // *** End programmer edit section *** (WorkTimeSpan.StartTime Get start)
                decimal result = this.fStartTime;
                // *** Start programmer edit section *** (WorkTimeSpan.StartTime Get end)

                // *** End programmer edit section *** (WorkTimeSpan.StartTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkTimeSpan.StartTime Set start)

                // *** End programmer edit section *** (WorkTimeSpan.StartTime Set start)
                this.fStartTime = value;
                // *** Start programmer edit section *** (WorkTimeSpan.StartTime Set end)

                // *** End programmer edit section *** (WorkTimeSpan.StartTime Set end)
            }
        }
        
        /// <summary>
        /// EndTime.
        /// </summary>
        // *** Start programmer edit section *** (WorkTimeSpan.EndTime CustomAttributes)

        // *** End programmer edit section *** (WorkTimeSpan.EndTime CustomAttributes)
        public virtual decimal EndTime
        {
            get
            {
                // *** Start programmer edit section *** (WorkTimeSpan.EndTime Get start)

                // *** End programmer edit section *** (WorkTimeSpan.EndTime Get start)
                decimal result = this.fEndTime;
                // *** Start programmer edit section *** (WorkTimeSpan.EndTime Get end)

                // *** End programmer edit section *** (WorkTimeSpan.EndTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkTimeSpan.EndTime Set start)

                // *** End programmer edit section *** (WorkTimeSpan.EndTime Set start)
                this.fEndTime = value;
                // *** Start programmer edit section *** (WorkTimeSpan.EndTime Set end)

                // *** End programmer edit section *** (WorkTimeSpan.EndTime Set end)
            }
        }
        
        /// <summary>
        /// Время создания объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkTimeSpan.CreateTime CustomAttributes)

        // *** End programmer edit section *** (WorkTimeSpan.CreateTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                // *** Start programmer edit section *** (WorkTimeSpan.CreateTime Get start)

                // *** End programmer edit section *** (WorkTimeSpan.CreateTime Get start)
                System.Nullable<System.DateTime> result = this.fCreateTime;
                // *** Start programmer edit section *** (WorkTimeSpan.CreateTime Get end)

                // *** End programmer edit section *** (WorkTimeSpan.CreateTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkTimeSpan.CreateTime Set start)

                // *** End programmer edit section *** (WorkTimeSpan.CreateTime Set start)
                this.fCreateTime = value;
                // *** Start programmer edit section *** (WorkTimeSpan.CreateTime Set end)

                // *** End programmer edit section *** (WorkTimeSpan.CreateTime Set end)
            }
        }
        
        /// <summary>
        /// Создатель объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkTimeSpan.Creator CustomAttributes)

        // *** End programmer edit section *** (WorkTimeSpan.Creator CustomAttributes)
        [StrLen(255)]
        public virtual string Creator
        {
            get
            {
                // *** Start programmer edit section *** (WorkTimeSpan.Creator Get start)

                // *** End programmer edit section *** (WorkTimeSpan.Creator Get start)
                string result = this.fCreator;
                // *** Start programmer edit section *** (WorkTimeSpan.Creator Get end)

                // *** End programmer edit section *** (WorkTimeSpan.Creator Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkTimeSpan.Creator Set start)

                // *** End programmer edit section *** (WorkTimeSpan.Creator Set start)
                this.fCreator = value;
                // *** Start programmer edit section *** (WorkTimeSpan.Creator Set end)

                // *** End programmer edit section *** (WorkTimeSpan.Creator Set end)
            }
        }
        
        /// <summary>
        /// Время последнего редактирования объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkTimeSpan.EditTime CustomAttributes)

        // *** End programmer edit section *** (WorkTimeSpan.EditTime CustomAttributes)
        public virtual System.Nullable<System.DateTime> EditTime
        {
            get
            {
                // *** Start programmer edit section *** (WorkTimeSpan.EditTime Get start)

                // *** End programmer edit section *** (WorkTimeSpan.EditTime Get start)
                System.Nullable<System.DateTime> result = this.fEditTime;
                // *** Start programmer edit section *** (WorkTimeSpan.EditTime Get end)

                // *** End programmer edit section *** (WorkTimeSpan.EditTime Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkTimeSpan.EditTime Set start)

                // *** End programmer edit section *** (WorkTimeSpan.EditTime Set start)
                this.fEditTime = value;
                // *** Start programmer edit section *** (WorkTimeSpan.EditTime Set end)

                // *** End programmer edit section *** (WorkTimeSpan.EditTime Set end)
            }
        }
        
        /// <summary>
        /// Последний редактор объекта.
        /// </summary>
        // *** Start programmer edit section *** (WorkTimeSpan.Editor CustomAttributes)

        // *** End programmer edit section *** (WorkTimeSpan.Editor CustomAttributes)
        [StrLen(255)]
        public virtual string Editor
        {
            get
            {
                // *** Start programmer edit section *** (WorkTimeSpan.Editor Get start)

                // *** End programmer edit section *** (WorkTimeSpan.Editor Get start)
                string result = this.fEditor;
                // *** Start programmer edit section *** (WorkTimeSpan.Editor Get end)

                // *** End programmer edit section *** (WorkTimeSpan.Editor Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkTimeSpan.Editor Set start)

                // *** End programmer edit section *** (WorkTimeSpan.Editor Set start)
                this.fEditor = value;
                // *** Start programmer edit section *** (WorkTimeSpan.Editor Set end)

                // *** End programmer edit section *** (WorkTimeSpan.Editor Set end)
            }
        }
        
        /// <summary>
        /// мастеровая ссылка на шапку IIS.BusinessCalendar.WorkTimeDefinition.
        /// </summary>
        // *** Start programmer edit section *** (WorkTimeSpan.WorkTimeDefinition CustomAttributes)

        // *** End programmer edit section *** (WorkTimeSpan.WorkTimeDefinition CustomAttributes)
        [Agregator()]
        [NotNull()]
        public virtual IIS.BusinessCalendar.WorkTimeDefinition WorkTimeDefinition
        {
            get
            {
                // *** Start programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Get start)

                // *** End programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Get start)
                IIS.BusinessCalendar.WorkTimeDefinition result = this.fWorkTimeDefinition;
                // *** Start programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Get end)

                // *** End programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Set start)

                // *** End programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Set start)
                this.fWorkTimeDefinition = value;
                // *** Start programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Set end)

                // *** End programmer edit section *** (WorkTimeSpan.WorkTimeDefinition Set end)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// "AuditView" view.
            /// </summary>
            public static ICSSoft.STORMNET.View AuditView
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("AuditView", typeof(IIS.BusinessCalendar.WorkTimeSpan));
                }
            }
            
            /// <summary>
            /// "WorkTimeSpanE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View WorkTimeSpanE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("WorkTimeSpanE", typeof(IIS.BusinessCalendar.WorkTimeSpan));
                }
            }
        }
        
        /// <summary>
        /// Audit class settings.
        /// </summary>
        public class AuditSettings
        {
            
            /// <summary>
            /// Включён ли аудит для класса.
            /// </summary>
            public static bool AuditEnabled = true;
            
            /// <summary>
            /// Использовать имя представления для аудита по умолчанию.
            /// </summary>
            public static bool UseDefaultView = false;
            
            /// <summary>
            /// Включён ли аудит операции чтения.
            /// </summary>
            public static bool SelectAudit = false;
            
            /// <summary>
            /// Имя представления для аудирования операции чтения.
            /// </summary>
            public static string SelectAuditViewName = "AuditView";
            
            /// <summary>
            /// Включён ли аудит операции создания.
            /// </summary>
            public static bool InsertAudit = true;
            
            /// <summary>
            /// Имя представления для аудирования операции создания.
            /// </summary>
            public static string InsertAuditViewName = "AuditView";
            
            /// <summary>
            /// Включён ли аудит операции изменения.
            /// </summary>
            public static bool UpdateAudit = false;
            
            /// <summary>
            /// Имя представления для аудирования операции изменения.
            /// </summary>
            public static string UpdateAuditViewName = "AuditView";
            
            /// <summary>
            /// Включён ли аудит операции удаления.
            /// </summary>
            public static bool DeleteAudit = true;
            
            /// <summary>
            /// Имя представления для аудирования операции удаления.
            /// </summary>
            public static string DeleteAuditViewName = "AuditView";
            
            /// <summary>
            /// Путь к форме просмотра результатов аудита.
            /// </summary>
            public static string FormUrl = "";
            
            /// <summary>
            /// Режим записи данных аудита (синхронный или асинхронный).
            /// </summary>
            public static ICSSoft.STORMNET.Business.Audit.Objects.tWriteMode WriteMode = ICSSoft.STORMNET.Business.Audit.Objects.tWriteMode.Synchronous;
            
            /// <summary>
            /// Максимальная длина сохраняемого значения поля (если 0, то строка обрезаться не будет).
            /// </summary>
            public static int PrunningLength = 0;
            
            /// <summary>
            /// Показывать ли пользователям в изменениях первичные ключи.
            /// </summary>
            public static bool ShowPrimaryKey = false;
            
            /// <summary>
            /// Сохранять ли старое значение.
            /// </summary>
            public static bool KeepOldValue = true;
            
            /// <summary>
            /// Сжимать ли сохраняемые значения.
            /// </summary>
            public static bool Compress = false;
            
            /// <summary>
            /// Сохранять ли все значения атрибутов, а не только изменяемые.
            /// </summary>
            public static bool KeepAllValues = false;
        }
    }
    
    /// <summary>
    /// Detail array of WorkTimeSpan.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfWorkTimeSpan CustomAttributes)

    // *** End programmer edit section *** (DetailArrayDetailArrayOfWorkTimeSpan CustomAttributes)
    public class DetailArrayOfWorkTimeSpan : ICSSoft.STORMNET.DetailArray
    {
        
        // *** Start programmer edit section *** (IIS.BusinessCalendar.DetailArrayOfWorkTimeSpan members)

        // *** End programmer edit section *** (IIS.BusinessCalendar.DetailArrayOfWorkTimeSpan members)

        
        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type WorkTimeSpan by index.
        /// </summary>
        /// <summary>
        /// Adds object with type WorkTimeSpan.
        /// </summary>
        public DetailArrayOfWorkTimeSpan(IIS.BusinessCalendar.WorkTimeDefinition fWorkTimeDefinition) : 
                base(typeof(WorkTimeSpan), ((ICSSoft.STORMNET.DataObject)(fWorkTimeDefinition)))
        {
        }
        
        public IIS.BusinessCalendar.WorkTimeSpan this[int index]
        {
            get
            {
                return ((IIS.BusinessCalendar.WorkTimeSpan)(this.ItemByIndex(index)));
            }
        }
        
        public virtual void Add(IIS.BusinessCalendar.WorkTimeSpan dataobject)
        {
            this.AddObject(((ICSSoft.STORMNET.DataObject)(dataobject)));
        }
    }
}