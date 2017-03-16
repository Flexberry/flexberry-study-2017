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
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Дни исключения.
    /// </summary>
    // *** Start programmer edit section *** (ExceptionDay CustomAttributes)

    // *** End programmer edit section *** (ExceptionDay CustomAttributes)
    [AutoAltered()]
    [Caption("Дни исключения")]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    [View("ExceptionDayE", new string[] {
            "Name as \'Название\'",
            "DayType as \'Тип дня\'",
            "RecurrenceType as \'Тип повторения\'",
            "RepeatStep as \'Шаг повторения\'",
            "StartDate as \'Дата начала\'",
            "EndDate as \'Дата окончания\'",
            "RecurrenceCount as \'Число повторений\'",
            "WorkTimeDefinition.*",
            "WorkTimeDefinition as \'Временные промежутки\'",
            "Calendar as \'Календарь\'",
            "Calendar.Name as \'Название календаря\'"}, Hidden=new string[] {
            "WorkTimeDefinition.*"})]
    [View("ExceptionDayL", new string[] {
            "Name as \'Название\'",
            "DayType as \'Тип дня\'",
            "RecurrenceType as \'Тип повторения\'",
            "RepeatStep as \'Шаг повторения\'",
            "StartDate as \'Дата начала\'",
            "EndDate as \'Дата окончания\'",
            "RecurrenceCount as \'Количество повторений\'",
            "Calendar.Name as \'Название календаря\'"})]
    public class ExceptionDay : ICSSoft.STORMNET.DataObject
    {
        
        private string fName;
        
        private IIS.BusinessCalendar.DayType fDayType;
        
        private IIS.BusinessCalendar.RecurrenceType fRecurrenceType;
        
        private int fRepeatStep;
        
        private System.DateTime fStartDate;
        
        private System.DateTime fEndDate;
        
        private int fRecurrenceCount;
        
        private IIS.BusinessCalendar.WorkTimeDefinition fWorkTimeDefinition;
        
        private IIS.BusinessCalendar.Calendar fCalendar;
        
        // *** Start programmer edit section *** (ExceptionDay CustomMembers)

        // *** End programmer edit section *** (ExceptionDay CustomMembers)

        
        /// <summary>
        /// Name.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.Name CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.Name CustomAttributes)
        [StrLen(255)]
        public virtual string Name
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.Name Get start)

                // *** End programmer edit section *** (ExceptionDay.Name Get start)
                string result = this.fName;
                // *** Start programmer edit section *** (ExceptionDay.Name Get end)

                // *** End programmer edit section *** (ExceptionDay.Name Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.Name Set start)

                // *** End programmer edit section *** (ExceptionDay.Name Set start)
                this.fName = value;
                // *** Start programmer edit section *** (ExceptionDay.Name Set end)

                // *** End programmer edit section *** (ExceptionDay.Name Set end)
            }
        }
        
        /// <summary>
        /// DayType.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.DayType CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.DayType CustomAttributes)
        public virtual IIS.BusinessCalendar.DayType DayType
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.DayType Get start)

                // *** End programmer edit section *** (ExceptionDay.DayType Get start)
                IIS.BusinessCalendar.DayType result = this.fDayType;
                // *** Start programmer edit section *** (ExceptionDay.DayType Get end)

                // *** End programmer edit section *** (ExceptionDay.DayType Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.DayType Set start)

                // *** End programmer edit section *** (ExceptionDay.DayType Set start)
                this.fDayType = value;
                // *** Start programmer edit section *** (ExceptionDay.DayType Set end)

                // *** End programmer edit section *** (ExceptionDay.DayType Set end)
            }
        }
        
        /// <summary>
        /// RecurrenceType.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.RecurrenceType CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.RecurrenceType CustomAttributes)
        public virtual IIS.BusinessCalendar.RecurrenceType RecurrenceType
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceType Get start)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceType Get start)
                IIS.BusinessCalendar.RecurrenceType result = this.fRecurrenceType;
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceType Get end)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceType Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceType Set start)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceType Set start)
                this.fRecurrenceType = value;
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceType Set end)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceType Set end)
            }
        }
        
        /// <summary>
        /// RepeatStep.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.RepeatStep CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.RepeatStep CustomAttributes)
        public virtual int RepeatStep
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.RepeatStep Get start)

                // *** End programmer edit section *** (ExceptionDay.RepeatStep Get start)
                int result = this.fRepeatStep;
                // *** Start programmer edit section *** (ExceptionDay.RepeatStep Get end)

                // *** End programmer edit section *** (ExceptionDay.RepeatStep Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.RepeatStep Set start)

                // *** End programmer edit section *** (ExceptionDay.RepeatStep Set start)
                this.fRepeatStep = value;
                // *** Start programmer edit section *** (ExceptionDay.RepeatStep Set end)

                // *** End programmer edit section *** (ExceptionDay.RepeatStep Set end)
            }
        }
        
        /// <summary>
        /// StartDate.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.StartDate CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.StartDate CustomAttributes)
        public virtual System.DateTime StartDate
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.StartDate Get start)

                // *** End programmer edit section *** (ExceptionDay.StartDate Get start)
                System.DateTime result = this.fStartDate;
                // *** Start programmer edit section *** (ExceptionDay.StartDate Get end)

                // *** End programmer edit section *** (ExceptionDay.StartDate Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.StartDate Set start)

                // *** End programmer edit section *** (ExceptionDay.StartDate Set start)
                this.fStartDate = value;
                // *** Start programmer edit section *** (ExceptionDay.StartDate Set end)

                // *** End programmer edit section *** (ExceptionDay.StartDate Set end)
            }
        }
        
        /// <summary>
        /// EndDate.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.EndDate CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.EndDate CustomAttributes)
        public virtual System.DateTime EndDate
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.EndDate Get start)

                // *** End programmer edit section *** (ExceptionDay.EndDate Get start)
                System.DateTime result = this.fEndDate;
                // *** Start programmer edit section *** (ExceptionDay.EndDate Get end)

                // *** End programmer edit section *** (ExceptionDay.EndDate Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.EndDate Set start)

                // *** End programmer edit section *** (ExceptionDay.EndDate Set start)
                this.fEndDate = value;
                // *** Start programmer edit section *** (ExceptionDay.EndDate Set end)

                // *** End programmer edit section *** (ExceptionDay.EndDate Set end)
            }
        }
        
        /// <summary>
        /// RecurrenceCount.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.RecurrenceCount CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.RecurrenceCount CustomAttributes)
        public virtual int RecurrenceCount
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceCount Get start)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceCount Get start)
                int result = this.fRecurrenceCount;
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceCount Get end)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceCount Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceCount Set start)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceCount Set start)
                this.fRecurrenceCount = value;
                // *** Start programmer edit section *** (ExceptionDay.RecurrenceCount Set end)

                // *** End programmer edit section *** (ExceptionDay.RecurrenceCount Set end)
            }
        }
        
        /// <summary>
        /// Дни исключения.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.WorkTimeDefinition CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.WorkTimeDefinition CustomAttributes)
        [PropertyStorage(new string[] {
                "WorkTimeDefinition"})]
        [NotNull()]
        public virtual IIS.BusinessCalendar.WorkTimeDefinition WorkTimeDefinition
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.WorkTimeDefinition Get start)

                // *** End programmer edit section *** (ExceptionDay.WorkTimeDefinition Get start)
                IIS.BusinessCalendar.WorkTimeDefinition result = this.fWorkTimeDefinition;
                // *** Start programmer edit section *** (ExceptionDay.WorkTimeDefinition Get end)

                // *** End programmer edit section *** (ExceptionDay.WorkTimeDefinition Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.WorkTimeDefinition Set start)

                // *** End programmer edit section *** (ExceptionDay.WorkTimeDefinition Set start)
                this.fWorkTimeDefinition = value;
                // *** Start programmer edit section *** (ExceptionDay.WorkTimeDefinition Set end)

                // *** End programmer edit section *** (ExceptionDay.WorkTimeDefinition Set end)
            }
        }
        
        /// <summary>
        /// Дни исключения.
        /// </summary>
        // *** Start programmer edit section *** (ExceptionDay.Calendar CustomAttributes)

        // *** End programmer edit section *** (ExceptionDay.Calendar CustomAttributes)
        [PropertyStorage(new string[] {
                "Calendar"})]
        [NotNull()]
        public virtual IIS.BusinessCalendar.Calendar Calendar
        {
            get
            {
                // *** Start programmer edit section *** (ExceptionDay.Calendar Get start)

                // *** End programmer edit section *** (ExceptionDay.Calendar Get start)
                IIS.BusinessCalendar.Calendar result = this.fCalendar;
                // *** Start programmer edit section *** (ExceptionDay.Calendar Get end)

                // *** End programmer edit section *** (ExceptionDay.Calendar Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (ExceptionDay.Calendar Set start)

                // *** End programmer edit section *** (ExceptionDay.Calendar Set start)
                this.fCalendar = value;
                // *** Start programmer edit section *** (ExceptionDay.Calendar Set end)

                // *** End programmer edit section *** (ExceptionDay.Calendar Set end)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// "ExceptionDayE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View ExceptionDayE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("ExceptionDayE", typeof(IIS.BusinessCalendar.ExceptionDay));
                }
            }
            
            /// <summary>
            /// "ExceptionDayL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View ExceptionDayL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("ExceptionDayL", typeof(IIS.BusinessCalendar.ExceptionDay));
                }
            }
        }
    }
}