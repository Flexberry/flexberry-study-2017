using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemObjects
{
    
    //Класс для хранения временных промежутков
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

        //Вычислимое поле для определения длительности временного промежутка
        public TimeSpan TotalTime 
        {
            get
            {
                return (new TimeSpan(hourFinish,minuteFinish,0) - (new TimeSpan(hourStart, minuteStart, 0)));
            }
        }

        //Вычислимое поле, возвращает часы и минуты начала временного промежутка
        public TimeSpan GetStartTime()
        {
            return (new TimeSpan(hourStart, minuteStart, 0));
        }

        //Вычислимое поле, возвращает часы и минуты окончания временного промежутка
        public TimeSpan GetFinishTime()
        {
            return (new TimeSpan(hourFinish, minuteFinish, 0));
        }
    }

    //Класс для хранения информации о днях
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

        //Вычислимое поле, возвращает сумму часов со всех промежутков дня
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
        //Метод возвращает дату дня
        public DateTime GetDate()
        {
            return this.date;
        }

        //Метод для добавления временного промежутка
        public void AddWorkTimeSpan(WorkTimeSpan item)
        {
            workTimeSpanCollection.Add(item);
        }

        //Метод возвращает список временных промежутков
        public List<WorkTimeSpan> GetWorkTimeSpans()
        {
            return workTimeSpanCollection;
        }
    }
}
