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
    
    
    // *** Start programmer edit section *** (Using statements)
    using System.Collections.Generic;
    using System.Linq;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Business server.
    /// </summary>
    // *** Start programmer edit section *** (BusinessServer CustomAttributes)

    // *** End programmer edit section *** (BusinessServer CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class BusinessServer : ICSSoft.STORMNET.Business.BusinessServer
    {
        
        // *** Start programmer edit section *** (BusinessServer CustomMembers)

        // *** End programmer edit section *** (BusinessServer CustomMembers)

        
        // *** Start programmer edit section *** (OnUpdateExceptionDay CustomAttributes)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpdatedObject"></param>
        /// <returns></returns>
        // *** End programmer edit section *** (OnUpdateExceptionDay CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateExceptionDay(IIS.BusinessCalendar.ExceptionDay UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateExceptionDay)
            if(UpdatedObject.GetStatus() == ObjectStatus.Deleted)
            {
                DataServiceProvider.DataService.LoadObject(ExceptionDay.Views.ExceptionDayE, UpdatedObject, false, false);
                if (UpdatedObject.WorkTimeDefinition != null)
                {
                    TSSaveHelper.DeleteTimeSpans(UpdatedObject);
                    WorkTimeDefinition tempWts = UpdatedObject.WorkTimeDefinition;
                    UpdatedObject.WorkTimeDefinition = null;
                    DataServiceProvider.DataService.UpdateObject(UpdatedObject);
                    UpdatedObject.SetStatus(ObjectStatus.Deleted);
                    return new DataObject[2] { tempWts, UpdatedObject };
                } 
                else
                {
                    UpdatedObject.SetStatus(ObjectStatus.Deleted);
                }
            }
            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateExceptionDay)
        }
        
        // *** Start programmer edit section *** (OnUpdateWeek CustomAttributes)
        /// <summary>
        /// Метод обрабатывает дополнительную логику обновления "Стандартной рабочей недели" в базе данных
        /// </summary>
        /// <param name="UpdatedObject">Изменяема неделя</param>
        /// <returns></returns>
        // *** End programmer edit section *** (OnUpdateWeek CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateWeek(IIS.BusinessCalendar.Week UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateWeek)
            if(UpdatedObject.GetStatus() == ObjectStatus.Deleted)
            {
                DataServiceProvider.DataService.LoadObject(Week.Views.WeekE, UpdatedObject, false, false);
                if((UpdatedObject.Monday != null)||(UpdatedObject.Tuesday != null)||(UpdatedObject.Wednesday != null)||(UpdatedObject.Thursday != null) ||(UpdatedObject.Friday != null) ||(UpdatedObject.Saturday != null) ||(UpdatedObject.Sunday != null))
                {
                    TSSaveHelper.DeleteTimeSpans(UpdatedObject);

                    WorkTimeDefinition tempMon = UpdatedObject.Monday;
                    WorkTimeDefinition tempTue = UpdatedObject.Tuesday;
                    WorkTimeDefinition tempWed = UpdatedObject.Wednesday;
                    WorkTimeDefinition tempThu = UpdatedObject.Thursday;
                    WorkTimeDefinition tempFri = UpdatedObject.Friday;
                    WorkTimeDefinition tempSun = UpdatedObject.Sunday;
                    WorkTimeDefinition tempSat = UpdatedObject.Saturday;

                    UpdatedObject.Monday = null;
                    UpdatedObject.Tuesday = null;
                    UpdatedObject.Wednesday = null;
                    UpdatedObject.Thursday = null;
                    UpdatedObject.Friday = null;
                    UpdatedObject.Saturday = null;
                    UpdatedObject.Sunday = null;
                    DataServiceProvider.DataService.UpdateObject(UpdatedObject);

                    UpdatedObject.SetStatus(ObjectStatus.Deleted);
                    
                    return new DataObject[8] { tempMon, tempTue, tempWed, tempThu, tempFri, tempSat, tempSun, UpdatedObject };
                }
                else
                {
                    UpdatedObject.SetStatus(ObjectStatus.Deleted);
                }
            }
            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateWeek)
        }
        
        // *** Start programmer edit section *** (OnUpdateWorkTimeDefinition CustomAttributes)

        // *** End programmer edit section *** (OnUpdateWorkTimeDefinition CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateWorkTimeDefinition(IIS.BusinessCalendar.WorkTimeDefinition UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateWorkTimeDefinition)
            
            return new ICSSoft.STORMNET.DataObject[0];
            // *** End programmer edit section *** (OnUpdateWorkTimeDefinition)
        }
    }
}
