using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS.BusinessCalendar.forms
{
    using IIS.BusinessCalendar;
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
                    StartTimeH = (int)Math.Truncate(wts.StartTime),
                    StartTimeM = (int)(wts.StartTime - Math.Truncate(wts.StartTime)),
                    EndTimeH = (int)Math.Truncate(wts.EndTime),
                    EndTimeM = (int)(wts.EndTime - Math.Truncate(wts.EndTime))
                });
            }
            return result;
        }
    }
}