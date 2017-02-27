using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Objects
{
    /// <summary>
    /// Класс для работы с временными промежутками
    /// </summary>
    public class WorkTimeSpan
    {
        /// <summary>
        /// Конструктор временного промежутка
        /// </summary>
        /// <param name="HourStart">часы начала</param>
        /// <param name="MinuteStart">минуты начала</param>
        /// <param name="HourFinish">часы окончания</param>
        /// <param name="MinuteFinish">минуты окончания</param>
        public WorkTimeSpan(
            int HourStart,      //час начала временного промежутка
            int MinuteStart,    //минута начала временного промежутка
            int HourFinish,     //час окончания временного промежутка
            int MinuteFinish)   //минута окончания временного промежутка
        {
            hourStart = HourStart;
            minuteStart = MinuteStart;
            hourFinish = HourFinish;
            minuteFinish = MinuteFinish;
        }
        private int hourStart;
        private int minuteStart;
        private int hourFinish;
        private int minuteFinish;

        /// <summary>
        /// Возвращает длительность временного промежутка
        /// </summary>
        public TimeSpan TotalTime
        {
            get
            {
                return (new TimeSpan(hourFinish, minuteFinish, 0) - (new TimeSpan(hourStart, minuteStart, 0)));
            }
        }

        /// <summary>
        /// Возвращает время начала временного промежутка
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetStartTime()
        {
            return (new TimeSpan(hourStart, minuteStart, 0));
        }

        /// <summary>
        /// Возвращает время окончания временного промежутка
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetFinishTime()
        {
            return (new TimeSpan(hourFinish, minuteFinish, 0));
        }
    }
}
