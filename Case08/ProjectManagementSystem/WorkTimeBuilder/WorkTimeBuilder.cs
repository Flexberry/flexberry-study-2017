
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeLibrary
{
    using ManagementSystemObjects;

    public class WorkTimeBuilder:IBusinessCalendarService
    {
        //Метод для выделения части списка от заданной начальной даты до заданной конечной даты
        public List<Day> GetDaysCollection(DateTime startDate, DateTime finishDate)
        {
            
            List<Day> days = BuildAllCollection();
            List<Day> gap = 
                new List<Day>(days.Where<Day>(e => (e.GetDate() >= startDate) && (e.GetDate() <= finishDate)).OrderBy(e => e.GetDate()));
            return gap;
        }

        //Метод для создания списка дней
        public List<Day> BuildAllCollection()
        {
            WorkTimeSpan beforeDinner = new WorkTimeSpan(8, 30, 12, 30);
            WorkTimeSpan afterDinner = new WorkTimeSpan(13, 30, 16, 30);

            Day workDay = new Day(new DateTime(2017, 2, 6), "Стандартный рабочий день");
            workDay.AddWorkTimeSpan(beforeDinner);
            workDay.AddWorkTimeSpan(afterDinner);
            Day workDay1 = new Day(new DateTime(2017, 2, 7), "Стандартный рабочий день");
            workDay1.AddWorkTimeSpan(beforeDinner);
            workDay1.AddWorkTimeSpan(afterDinner);
            Day workDay2 = new Day(new DateTime(2017, 2, 8), "Стандартный рабочий день");
            workDay2.AddWorkTimeSpan(beforeDinner);
            workDay2.AddWorkTimeSpan(afterDinner);
            Day workDay3 = new Day(new DateTime(2017, 2, 9), "Стандартный рабочий день");
            workDay3.AddWorkTimeSpan(beforeDinner);
            workDay3.AddWorkTimeSpan(afterDinner);
            Day workDay4 = new Day(new DateTime(2017, 2, 10), "Стандартный рабочий день");
            workDay4.AddWorkTimeSpan(beforeDinner);
            workDay4.AddWorkTimeSpan(afterDinner);

            List<Day> dayCollection = new List<Day>();
            dayCollection.Add(workDay);
            dayCollection.Add(workDay1);
            dayCollection.Add(workDay2);
            dayCollection.Add(workDay3);
            dayCollection.Add(workDay4);

            return dayCollection;
        }
    }
}
