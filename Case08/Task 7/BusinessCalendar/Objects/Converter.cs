using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.BusinessCalendar
{
    /// <summary>
    /// 
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
            foreach (WorkTimeSpan wts in wtsArray)
            {
                result.Add(new TimeSpan()
                {
                    StartTimeH = (int)Math.Truncate(wts.StartTime),
                    StartTimeM = (int)((wts.StartTime - Math.Truncate(wts.StartTime))*100),
                    EndTimeH = (int)Math.Truncate(wts.EndTime),
                    EndTimeM = (int)((wts.EndTime - Math.Truncate(wts.EndTime))*100)
                });
            }
            return result.OrderBy(ts => ts.StartTimeH).ToList<TimeSpan>();
        }

        /// <summary>
        /// Метод преобразует все элементы в коллекции из "ExceptionDay" в "ExcDay"
        /// </summary>
        /// <param name="exceptionDays">Коллекция дней-исключений(ExceptionDay)</param>
        /// <returns>Возваращает коллекцию сокращённых дней-исключений(ExcDay)</returns>
        public static List<ExcDay> ExceptionDaysToShort(IEnumerable<ExceptionDay> exceptionDays)
        {
            List<ExcDay> result = new List<ExcDay>();
            foreach(ExceptionDay day in exceptionDays)
            {
                result.Add(day.ToShort());
            }
            return result;
        }
    }
}
