using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS.BusinessCalendar
{
    /// <summary>
    /// Класс для приведения сущностей к сериализуемому виду
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wtsArray"></param>
        /// <returns></returns>
        public static List<TimeSpan> convertWorkTimeSpans(IEnumerable<WorkTimeSpan> wtsArray)
        {
            List<TimeSpan> result = new List<TimeSpan>();
            foreach(WorkTimeSpan wts in wtsArray)
            {
                result.Add(new TimeSpan()
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