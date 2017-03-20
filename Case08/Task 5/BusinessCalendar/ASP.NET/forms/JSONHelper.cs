using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS.BusinessCalendar.forms
{
    /// <summary>
    /// Класс для приведения сущностей к сериализуемому виду
    /// </summary>
    public static class JSONHelper
    {
        public static List<WorkTimeSpanShort> convertWorkTimeSpans(IEnumerable<WorkTimeSpan> wtsArray)
        {
            List<WorkTimeSpanShort> result = new List<WorkTimeSpanShort>();
            foreach(WorkTimeSpan wts in wtsArray)
            {
                result.Add(new WorkTimeSpanShort()
                {
                    PrimaryKey = ((ICSSoft.STORMNET.KeyGen.KeyGuid)wts.__PrimaryKey).Guid,
                    StartTime = wts.StartTime,
                    EndTime = wts.EndTime
                });
            }
            return result;
        }
    }
}