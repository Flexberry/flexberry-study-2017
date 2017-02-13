using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemObjects
{
    /// <summary>
    /// Класс для работы с временными промежутками
    /// </summary>
    public class WorkTimeSpan
    {
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
                return (new TimeSpan(hourFinish,minuteFinish,0) - (new TimeSpan(hourStart, minuteStart, 0)));
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

    /// <summary>
    /// Класс для работы с информацией о днях
    /// </summary>
    public class Day
    {
        public Day(
            DateTime DayDate,       //Дата дня
            string Description)     //Описание дня
        {
            workTimeSpanCollection = new List<WorkTimeSpan>();  
            date = DayDate;
            description = Description;
        }
        private List<WorkTimeSpan> workTimeSpanCollection;  //Список для хранения временных промежутков 
        private DateTime date;                              
        private string description;

        /// <summary>
        /// Возвращает общую длительность временных промежутков за один день
        /// </summary>
        public TimeSpan WorkTime 
        { 
            get
            {
                TimeSpan workTime = new TimeSpan(0,0,0);
                foreach (WorkTimeSpan item in workTimeSpanCollection)
                    workTime += item.TotalTime;
                return workTime;
            }
        }
        /// <summary>
        /// Установить или задать тип дня true - рабочий день, false - день исключение
        /// </summary>
        public bool IsWorkDay
        {
            get
            {
                if ((WorkTime.Hours > 0) || (WorkTime.Minutes > 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Возвращает дату начала дня
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return this.date;
        }

        /// <summary>
        /// Добавить временной промежуток
        /// </summary>
        /// <param name="item"></param>
        public void AddWorkTimeSpan(WorkTimeSpan item)
        {
            workTimeSpanCollection.Add(item);
        }

        /// <summary>
        /// Возвращает список временных промежутков
        /// </summary>
        /// <returns></returns>
        public List<WorkTimeSpan> GetWorkTimeSpans()
        {
            return workTimeSpanCollection;
        }
    }
}
