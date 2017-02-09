using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemObjects;

namespace WorkTimeLibrary
{
    public class SumTimeCalculator
    {
        //Метод для суммирования суммы рабочих часов за определённый интервал времени
        public int CalculateTime(DateTime startDate,DateTime finishDate)
        {
            int resultTime = 0;
            WorkTimeBuilder workTimeBuilder = new WorkTimeBuilder();
            List<Day> days = workTimeBuilder.GetDaysCollection(startDate, finishDate);
           
            foreach (Day day in days)
            {
                resultTime += day.WorkTime.Hours;
            }

            return resultTime;
        }
    }
}
