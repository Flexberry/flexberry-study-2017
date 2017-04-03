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
        /// Метод обновляет временные промежутки в базе данных для дня-исключения
        /// </summary>
        /// <param name="UpdatedObject">Изменяемый день-исключение</param>
        public static void UpdateTimeSpans(IIS.BusinessCalendar.ExceptionDay UpdatedObject)
        {
            switch (UpdatedObject.GetStatus())
            {
                case ObjectStatus.Created:
                    {
                        fillWorkTimeDefinition(UpdatedObject.WorkTimeDefinition,UpdatedObject.WorkTimeSpans);
                    }
                    break;
                case ObjectStatus.Deleted:
                    {
                        deleteExsTimeSpans(UpdatedObject.WorkTimeDefinition);
                    }
                    break;
                default:
                    {
                        deleteExsTimeSpans(UpdatedObject.WorkTimeDefinition);
                        if (UpdatedObject.WorkTimeSpans.Count > 0)
                        {
                            fillWorkTimeDefinition(UpdatedObject.WorkTimeDefinition,UpdatedObject.WorkTimeSpans);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Метод для удаления временных промежутков и связанного с ними агрегатора из базы данных для дня-исключения
        /// </summary>
        /// <param name="exceptionDay"></param>
        public static void DeleteTimeSpans(ExceptionDay exceptionDay)
        {
            deleteExsTimeSpans(exceptionDay.WorkTimeDefinition);
            exceptionDay.WorkTimeDefinition.SetStatus(ObjectStatus.Deleted);
        }
        /// <summary>
        /// Метод сохраняет временные промежутки в базе данных
        /// </summary>
        /// <param name="workTimeDefinition">Агрегатов временных промежутков</param>
        /// <param name="workTimeSpans">Список временных промежутков</param>
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
        /// Метод удаляет временные промежутки, хранящиеся в базе данных
        /// </summary>
        /// <param name="workTimeDefinition">Агрегатор временных промежутков</param>
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
        /// <param name="week">Стандартная рабочая неделя</param>
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
