using System;
using System.Collections.Generic;
using System.Linq;


namespace WorkTimeLibrary
{
    using PMS.Objects;
    using PMS.DAL;

    public class SumTimeCalculator
    {
        /// <summary>
        /// Метод для подсчета общей суммы рабочих часов за указанный интервал дат
        /// </summary>
        /// <param name="startDate">Дата начала инервала</param>
        /// <param name="finishDate">Дата окончания интервала</param>
        /// <param name="workTimeBuilder">Сервис доступа к данным о днях</param>
        /// <returns></returns>
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
