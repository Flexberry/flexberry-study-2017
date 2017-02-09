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
        public DateTime CalculateDeadLine(int allotedTime,DateTime startDate)
        {
            List<Day> days = new List<Day>();
            WorkTimeBuilder wtb = new WorkTimeBuilder();
            days = wtb.GetDaysCollection(startDate, startDate.AddDays(4));
            Day day = days[0];

            while ((allotedTime > 0) && (days.Count > 0))
            {
                int iterator = 0;
                int lastPositiveHour = allotedTime;
                while ((iterator < days.Count) && (allotedTime > 0))
                {
                    day = days[iterator];
                    allotedTime -= day.WorkTime.Hours;
                    iterator++;    
                }
                days = wtb.GetDaysCollection(startDate, startDate.AddDays(4));
            }
            TimeSpan deadLineTime = new TimeSpan(0,0,0);
            
            if (allotedTime < 0)
            {
                int i = 0;
                List<WorkTimeSpan> wts = day.GetWorkTimeSpans();
                while (allotedTime < 0)
                {
                    allotedTime += wts[i].TotalTime.Hours;
                    i++;
                }
                deadLineTime = wts[i-2].GetStartTime()
                    .Add(new TimeSpan(allotedTime, 0, 0));
            }
            else
            {
                if (allotedTime > 0)
                {
                    Exception ex = new Exception("Не хватает дней");
                }
                else
                {
                    List<WorkTimeSpan> wts = day.GetWorkTimeSpans();
                    deadLineTime = wts[wts.Count - 1].GetFinishTime();
                }
            }
            return day.GetDate().Add(deadLineTime);
        }
    }
}
