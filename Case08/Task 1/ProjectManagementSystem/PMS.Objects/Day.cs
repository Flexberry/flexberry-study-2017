using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Objects
{
    

    /// <summary>
    /// Класс для работы с информацией о днях
    /// </summary>
    public class Day
    {
        /// <summary>
        /// Конструктор дня
        /// </summary>
        /// <param name="DayDate">дата дня исключения</param>
        /// <param name="Description">описание</param>
        public Day(
            DateTime DayDate,       
            string Description)     
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
