using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeLibrary
{
    using PMS.Objects;
    using PMS.DAL;

    //Класс для определения даты и времени окончания временного промежутка с заданными началом и заданной продолжительностью, учитывая выходные и нерабочее время
    public class BusinessCalendar
    {

        
        public DateTime CalculateDeadLine(int allotedTime,DateTime startDate, IBusinessCalendarService businessCalendarService, TimeSpan standartWorkTime)
        {

            return startDate;
            /*Надо переделать под новый тип представления данных
            if(allotedTime > 0)
            {
                List<ExceptionDay> days;
                ExceptionDay day = new ExceptionDay(startDate, "");
                TimeSpan deadLineTime = new TimeSpan(0, 0, 0);
                int allotedTimePrev = 0;

                while (allotedTime > 0)
                {
                    days = new List<ExceptionDay>(businessCalendarService.GetDaysCollection(startDate, startDate.AddDays(10)).OrderBy<ExceptionDay, DateTime>(e => e.GetDate()));
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
            */
        }
        /// <summary>
        /// Метод для подсчета общей суммы рабочих часов за указанный интервал дат
        /// </summary>
        /// <param name="startDate">Дата начала инервала</param>
        /// <param name="finishDate">Дата окончания интервала</param>
        /// <param name="bussinessCalendarService"></param>
        /// <returns></returns>
        public int CalculateTime(DateTime startDate, DateTime finishDate, IBusinessCalendarService bussinessCalendarService, TimeSpan standartWorkTime)
        {
            /*Надо переделать под новый тип представления данных
            int resultTime = 0;
            List<ExceptionDay> days = new List<ExceptionDay>(workTimeBuilder.GetDaysCollection(startDate, finishDate).OrderBy<ExceptionDay,DateTime>(e => e.GetDate()));
           
            foreach (ExceptionDay day in days)
            {
                resultTime += day.WorkTime.Hours;
            }
            */

            return 0;
        }

    }
}
