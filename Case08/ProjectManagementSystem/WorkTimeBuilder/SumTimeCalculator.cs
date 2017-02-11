using System;
using System.Collections.Generic;
using System.Linq;


namespace WorkTimeLibrary
{
    using ManagementSystemObjects;

    public class SumTimeCalculator
    {
        //Метод для суммирования суммы рабочих часов за определённый интервал времени
        public int CalculateTime(DateTime startDate,DateTime finishDate,IBusinessCalendarService workTimeBuilder)
        {
            int resultTime = 0;
            List<Day> days = new List<Day>(workTimeBuilder.GetDaysCollection(startDate, finishDate).OrderBy<Day,DateTime>(e => e.GetDate()));
           
            foreach (Day day in days)
            {
                resultTime += day.WorkTime.Hours;
            }

            return resultTime;
        }
    }
}
