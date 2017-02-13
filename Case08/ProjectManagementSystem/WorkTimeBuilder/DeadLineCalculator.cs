using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeLibrary
{
    using ManagementSystemObjects;

    //Класс для определения даты и времени окончания временного промежутка с заданными началом и заданной продолжительностью, учитывая выходные и нерабочее время
    public class DeadLineCalculator
    {
        public DateTime CalculateDeadLine(int allotedTime,DateTime startDate, IBusinessCalendarService workTimeBuilder)
        {
            if(allotedTime > 0)
            {
                List<Day> days;
                Day day = new Day(startDate, "");
                TimeSpan deadLineTime = new TimeSpan(0, 0, 0);
                int allotedTimePrev = 0;

                while (allotedTime > 0)
                {
                    days = new List<Day>(workTimeBuilder.GetDaysCollection(startDate, startDate.AddDays(10)).OrderBy<Day, DateTime>(e => e.GetDate()));
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
    }
}
