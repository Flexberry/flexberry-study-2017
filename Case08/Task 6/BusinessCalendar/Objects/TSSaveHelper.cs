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
                        fillWorkTimeDefinition(UpdatedObject);
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
    }
}
