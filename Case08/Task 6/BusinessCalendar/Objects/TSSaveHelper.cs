using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.BusinessCalendar
{
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;

    /// <summary>
    /// Класс для работы с обновлением временных промежутков в базе данных
    /// </summary>
    public static class TSSaveHelper
    {
        /// <summary>
        /// Метод помогает сохранить временные промежутки для дня-исключения
        /// </summary>
        /// <param name="UpdatedObject">Изменяемы день-исключение</param>
        public static void SaveTimeSpans(IIS.BusinessCalendar.ExceptionDay UpdatedObject)
        {
            switch (UpdatedObject.GetStatus())
            {
                case ObjectStatus.Created:
                    {
                        fillWorkTimeDefinition(UpdatedObject);
                    }
                    break;
                case ObjectStatus.Deleted:
                    {
                        deleteExsTimeSpans(UpdatedObject);
                    }
                    break;
                default:
                    {
                        deleteExsTimeSpans(UpdatedObject);
                        if (UpdatedObject.WorkTimeSpans.Count > 0)
                        {
                            fillWorkTimeDefinition(UpdatedObject);
                        }
                        else
                        {
                            if (UpdatedObject.WorkTimeDefinition != null)
                            {
                                UpdatedObject.WorkTimeDefinition.SetStatus(ObjectStatus.Deleted);
                                using (var ds = (SQLDataService)DataServiceProvider.DataService)
                                {
                                    ds.UpdateObject(UpdatedObject.WorkTimeDefinition);
                                }
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Метод преобразует временные промежутки из сериализованного вида к виду, хранящемуся в базе данных и сохраняет их в WorkTimeDefinition
        /// </summary>
        /// <param name="UpdatedObject">Изменяемый день-исключение</param>
        private static void fillWorkTimeDefinition(IIS.BusinessCalendar.ExceptionDay UpdatedObject)
        {
            List<TimeSpan> wtss = UpdatedObject.WorkTimeSpans;
            if (wtss != null)
            {
                using (var ds = (SQLDataService)DataServiceProvider.DataService)
                {
                    if (UpdatedObject.WorkTimeDefinition == null)
                    {
                        UpdatedObject.WorkTimeDefinition = new WorkTimeDefinition();
                        ds.UpdateObject(UpdatedObject.WorkTimeDefinition);
                    }
                    List<DataObject> wtsList = new List<DataObject>();

                    foreach (TimeSpan ts in wtss)
                    {
                        WorkTimeSpan wts = new WorkTimeSpan();
                        wts.StartTime = (decimal)(ts.StartTimeH + ts.StartTimeM * 0.01);
                        wts.EndTime = (decimal)(ts.EndTimeH + ts.EndTimeM * 0.01);
                        wts.WorkTimeDefinition = UpdatedObject.WorkTimeDefinition;
                        wtsList.Add(wts);
                    }
                    var dataObjects = wtsList.ToArray();
                    ds.UpdateObjects(ref dataObjects);
                }
            }
            else
            {
                UpdatedObject.WorkTimeDefinition = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workTimeDefinition"></param>
        /// <param name="workTimeSpans"></param>
        private static void fillWorkTimeDefinition(IIS.BusinessCalendar.WorkTimeDefinition workTimeDefinition, List<TimeSpan> workTimeSpans)
        {
            if (workTimeSpans.Count > 0)
            {
                using (var ds = (SQLDataService)DataServiceProvider.DataService)
                {
                    List<DataObject> wtsList = new List<DataObject>();
                    foreach (TimeSpan ts in workTimeSpans)
                    {
                        WorkTimeSpan wts = new WorkTimeSpan();
                        wts.StartTime = (decimal)(ts.StartTimeH + ts.StartTimeM * 0.01);
                        wts.EndTime = (decimal)(ts.EndTimeH + ts.EndTimeM * 0.01);
                        wts.WorkTimeDefinition = workTimeDefinition;
                        wtsList.Add(wts);
                    }
                    var dataObjects = wtsList.ToArray();
                    ds.UpdateObjects(ref dataObjects);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workTimeDefinition"></param>
        private static void deleteExsTimeSpans(IIS.BusinessCalendar.WorkTimeDefinition workTimeDefinition)
        {
            using (var ds = (SQLDataService)DataServiceProvider.DataService)
            {
                IQueryable<WorkTimeSpan> wtsQuery = ds.Query<WorkTimeSpan>();
                IQueryable<WorkTimeSpan> query = wtsQuery.Where<WorkTimeSpan>(w => w.WorkTimeDefinition == workTimeDefinition);
                List<DataObject> wtsList = query.Cast<DataObject>().ToList();
                foreach (DataObject wts in wtsList)
                {
                    wts.SetStatus(ObjectStatus.Deleted);
                }
                var dataObjects = wtsList.ToArray();
                ds.UpdateObjects(ref dataObjects);
            }
        }
        /// <summary>
        /// Метод удаляет временные промежутки, которые уже храняться в базе данных
        /// </summary>
        /// <param name="updatedObject">Изменяемый день-исключение</param>
        private static void deleteExsTimeSpans(IIS.BusinessCalendar.ExceptionDay updatedObject)
        {
            if (updatedObject.WorkTimeDefinition != null)
            {
                using (var ds = (SQLDataService)DataServiceProvider.DataService)
                {
                    IQueryable<WorkTimeSpan> wtsQuery = ds.Query<WorkTimeSpan>();
                    IQueryable<WorkTimeSpan> query = wtsQuery.Where<WorkTimeSpan>(w => w.WorkTimeDefinition == updatedObject.WorkTimeDefinition);
                    List<DataObject> wtsList = query.Cast<DataObject>().ToList();
                    foreach (DataObject wts in wtsList)
                    {
                        wts.SetStatus(ObjectStatus.Deleted);
                    }
                    var dataObjects = wtsList.ToArray();
                    ds.UpdateObjects(ref dataObjects);
                }
            }
        }


        /// <summary>
        /// Метод сохраняет временные промежутки для стандартной рабочей недели в базу данных
        /// </summary>
        /// <param name="week">сохраняемая стандартная рабочаа неделя</param>
        public static void CreateTimeSpans(IIS.BusinessCalendar.Week week)
        {
            using (var ds = (SQLDataService)DataServiceProvider.DataService)
            {
                week.Monday = new WorkTimeDefinition();
                week.Tuesday = new WorkTimeDefinition();
                week.Wednesday = new WorkTimeDefinition();
                week.Thursday = new WorkTimeDefinition();
                week.Friday = new WorkTimeDefinition();
                week.Saturday = new WorkTimeDefinition();
                week.Sunday = new WorkTimeDefinition();

                ds.UpdateObject(week);

                fillWorkTimeDefinition(week.Monday, week.MondayTS);
                fillWorkTimeDefinition(week.Tuesday, week.TuesdayTS);
                fillWorkTimeDefinition(week.Wednesday, week.WednesdayTS);
                fillWorkTimeDefinition(week.Thursday, week.ThursdayTS);
                fillWorkTimeDefinition(week.Friday, week.FridayTS);
                fillWorkTimeDefinition(week.Saturday, week.SaturdayTS);
                fillWorkTimeDefinition(week.Sunday, week.SundayTS);
            }
        }

        /// <summary>
        /// Метод удаляет временные промежутки из базы данных
        /// </summary>
        /// <param name="week"></param>
        public static void DeleteTimeSpans(IIS.BusinessCalendar.Week week)
        {
            using (var ds = (SQLDataService)DataServiceProvider.DataService)
            {
                deleteExsTimeSpans(week.Monday);
                deleteExsTimeSpans(week.Tuesday);
                deleteExsTimeSpans(week.Wednesday);
                deleteExsTimeSpans(week.Thursday);
                deleteExsTimeSpans(week.Friday);
                deleteExsTimeSpans(week.Saturday);
                deleteExsTimeSpans(week.Sunday);

                week.Monday.SetStatus(ObjectStatus.Deleted);
                week.Tuesday.SetStatus(ObjectStatus.Deleted);
                week.Wednesday.SetStatus(ObjectStatus.Deleted);
                week.Thursday.SetStatus(ObjectStatus.Deleted);
                week.Friday.SetStatus(ObjectStatus.Deleted);
                week.Saturday.SetStatus(ObjectStatus.Deleted);
                week.Sunday.SetStatus(ObjectStatus.Deleted);

                var objects = new List<DataObject>() { week.Monday, week.Tuesday, week.Wednesday, week.Thursday, week.Friday, week.Saturday, week.Sunday };
                var dataObjects = objects.ToArray();

                ds.UpdateObjects(ref dataObjects);
            }
        }

        /// <summary>
        /// Метод обновляет временные промежутки для выбранного дня-исключения/дня стандартной рабочей недели
        /// </summary>
        /// <param name="workTimeDefinition">определение дня, который нужно обновить</param>
        /// <param name="workTimeSpans">новые временные промежутки</param>
        public static void UpdateTimeSpans(IIS.BusinessCalendar.WorkTimeDefinition workTimeDefinition,List<TimeSpan> workTimeSpans)
        {
            using (var ds = (SQLDataService)DataServiceProvider.DataService)
            {
                deleteExsTimeSpans(workTimeDefinition);
                fillWorkTimeDefinition(workTimeDefinition, workTimeSpans);
            }
        }
    }
}
