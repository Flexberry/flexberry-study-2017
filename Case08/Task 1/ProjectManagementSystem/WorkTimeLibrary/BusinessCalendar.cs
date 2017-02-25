using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeLibrary
{
    using PMS.Objects;
    using PMS.DAL;

    /// <summary>
    /// Класс для определения даты и времени окончания временного промежутка, а также суммы рабочего времени
    /// </summary>
    public class BusinessCalendar
    {
        /// <summary>
        /// Экземпляр доступа к данным
        /// </summary>
        private IBusinessCalendarService businessCalendarService;

        /// <summary>
        /// Коструктор для класса работы со временем
        /// </summary>
        /// <param name="bcs">экземпляр класса доступа к данным</param>
        public BusinessCalendar(IBusinessCalendarService bcs)
        {
            businessCalendarService = bcs;
        }
        /// <summary>
        /// Метод вычисляет дату окончания временного промежутка
        /// </summary>
        /// <param name="allotedTime"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public DateTime CalculateDeadLine(int allotedTime,DateTime startDate)
        {
            if(allotedTime > 0)
            {
                List<Day> days;
                Day day = new Day(startDate, "");
                TimeSpan deadLineTime = new TimeSpan(0, 0, 0);
                int allotedTimePrev = 0;

                while (allotedTime > 0)
                {
                    days = new List<Day>(businessCalendarService.GetDays(startDate, startDate.AddDays(10)).OrderBy<Day, DateTime>(e => e.GetDate()));
                    int iterator = 0;
                    while ((iterator < days.Count) && (allotedTime > 0))
                    {
                        day = days[iterator];
                        if (day.WorkTime.Hours != 0)
                            allotedTimePrev = allotedTime;
                        allotedTime -= day.WorkTime.Hours;
                        iterator++;
                    }
                    startDate = startDate.AddDays(11);
                }
                List<WorkTimeSpan> wts = day.GetWorkTimeSpans();
                if (allotedTimePrev > day.GetWorkTimeSpans()[0].TotalTime.Hours)
                {
                    int i = 0;

                    while (allotedTimePrev > day.GetWorkTimeSpans()[i].TotalTime.Hours)
                    {
                        allotedTimePrev -= wts[i].TotalTime.Hours;
                        i++;
                    }
                    deadLineTime = wts[i].GetStartTime()
                        .Add(new TimeSpan(allotedTimePrev, 0, 0));
                }
                else
                {
                    if (allotedTimePrev < day.GetWorkTimeSpans()[0].TotalTime.Hours)
                    {
                        deadLineTime = wts[0].GetStartTime().Add(new TimeSpan(allotedTimePrev, 0, 0));
                    }
                    else
                    {
                        deadLineTime = wts[wts.Count - 1].GetFinishTime();
                    }
                }
                return day.GetDate().Add(deadLineTime);
            }
            else
            {
                return startDate;
            }
        }

        /// <summary>
        /// Метод для подсчета общей суммы рабочих часов за указанный интервал дат
        /// </summary>
        /// <param name="startDate">Дата начала инервала</param>
        /// <param name="finishDate">Дата окончания интервала</param>
        /// <returns></returns>
        public int CalculateWorkTime(DateTime startDate, DateTime finishDate)
        {
            int resultTime = 0;
            List<Day> days = new List<Day>(businessCalendarService.GetDays(startDate, finishDate).OrderBy<Day, DateTime>(e => e.GetDate()));

            foreach (Day day in days)
            {
                resultTime += day.WorkTime.Hours;
            }

            return resultTime;
        }
    }
}
