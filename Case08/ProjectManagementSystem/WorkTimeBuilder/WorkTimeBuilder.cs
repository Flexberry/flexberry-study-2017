
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
        private List<Day> days; //настоящего источника данных нет(пока), создаём искусственный, чтобы тестировать приложение
        public WorkTimeBuilder()
        {
            //Формируем искусственный источник данных
            days = BuildAllCollection();
        }
        //Метод для выделения части списка от заданной начальной даты до заданной конечной даты
        public List<Day> GetDaysCollection(DateTime startDate, DateTime finishDate)
        {
            List<Day> gap = 
                new List<Day>(days.Where<Day>(e => (e.GetDate() >= startDate) && (e.GetDate() <= finishDate)));
            return gap;
        }

        //Метод для создания искусственного источника данных
        public List<Day> BuildAllCollection()
        {
            WorkTimeSpan beforeDinner = new WorkTimeSpan(8, 30, 12, 30);
            WorkTimeSpan afterDinner = new WorkTimeSpan(13, 30, 16, 30);

            Day workDay0 = new Day(new DateTime(2017, 2, 1), "Сокращенный рабочий день");
            workDay0.AddWorkTimeSpan(beforeDinner);
            Day workDay = new Day(new DateTime(2017, 2, 6), "Стандартный рабочий день");
            workDay.AddWorkTimeSpan(beforeDinner);
            workDay.AddWorkTimeSpan(afterDinner);
            Day workDay1 = new Day(new DateTime(2017, 2, 7), "Стандартный рабочий день");
            workDay1.AddWorkTimeSpan(beforeDinner);
            workDay1.AddWorkTimeSpan(afterDinner);
            Day workDay2 = new Day(new DateTime(2017, 2, 8), "Пустой день");
            Day workDay3 = new Day(new DateTime(2017, 2, 9), "Стандартный рабочий день");
            workDay3.AddWorkTimeSpan(beforeDinner);
            workDay3.AddWorkTimeSpan(afterDinner);
            Day workDay4 = new Day(new DateTime(2017, 2, 10), "Стандартный рабочий день");
            workDay4.AddWorkTimeSpan(beforeDinner);
            workDay4.AddWorkTimeSpan(afterDinner);
            Day workDay5 = new Day(new DateTime(2017, 2, 15), "Стандартный рабочий день");
            workDay5.AddWorkTimeSpan(beforeDinner);
            workDay5.AddWorkTimeSpan(afterDinner);
            Day workDay6 = new Day(new DateTime(2017, 2, 16), "Стандартный рабочий день");
            workDay6.AddWorkTimeSpan(beforeDinner);
            workDay6.AddWorkTimeSpan(afterDinner);
            Day workDay7 = new Day(new DateTime(2017, 2, 17), "Стандартный рабочий день");
            workDay7.AddWorkTimeSpan(beforeDinner);
            workDay7.AddWorkTimeSpan(afterDinner);
            Day workDay8 = new Day(new DateTime(2017, 2, 18), "Выходной");
            Day workDay9 = new Day(new DateTime(2017, 2, 19), "Выходной");
            Day workDay10 = new Day(new DateTime(2017, 2, 20), "Стандартный рабочий день");
            workDay10.AddWorkTimeSpan(beforeDinner);
            workDay10.AddWorkTimeSpan(afterDinner);
            Day workDay11 = new Day(new DateTime(2017, 2, 21), "Стандартный рабочий день");
            workDay11.AddWorkTimeSpan(beforeDinner);
            workDay11.AddWorkTimeSpan(afterDinner);
            Day workDay12 = new Day(new DateTime(2017, 2, 22), "Стандартный рабочий день");
            workDay12.AddWorkTimeSpan(beforeDinner);
            workDay12.AddWorkTimeSpan(afterDinner);
            Day workDay13 = new Day(new DateTime(2017, 2, 23), "Праздник 23 - февраля!!!");
            Day workDay14 = new Day(new DateTime(2017, 2, 24), "Стандартный рабочий день");
            workDay14.AddWorkTimeSpan(beforeDinner);
            workDay14.AddWorkTimeSpan(afterDinner);
            Day workDay15 = new Day(new DateTime(2017, 2, 25), "Выходной");
            Day workDay16 = new Day(new DateTime(2017, 2, 26), "Выходной");
            Day workDay17 = new Day(new DateTime(2017, 2, 27), "Стандартный рабочий день");
            workDay17.AddWorkTimeSpan(beforeDinner);
            workDay17.AddWorkTimeSpan(afterDinner);
            Day workDay18 = new Day(new DateTime(2017, 2, 28), "Стандартный рабочий день");
            workDay18.AddWorkTimeSpan(beforeDinner);
            workDay18.AddWorkTimeSpan(afterDinner);
            Day workDay19 = new Day(new DateTime(2017, 3, 1), "Стандартный рабочий день");
            workDay19.AddWorkTimeSpan(beforeDinner);
            workDay19.AddWorkTimeSpan(afterDinner);
            Day workDay20 = new Day(new DateTime(2017, 3, 2), "Стандартный рабочий день");
            workDay20.AddWorkTimeSpan(beforeDinner);
            workDay20.AddWorkTimeSpan(afterDinner);
            Day workDay21 = new Day(new DateTime(2017, 3, 4), "Выходной");
            Day workDay22 = new Day(new DateTime(2017, 3, 5), "Выходной");
            Day workDay23 = new Day(new DateTime(2017, 3, 6), "Стандартный рабочий день");
            workDay23.AddWorkTimeSpan(beforeDinner);
            workDay23.AddWorkTimeSpan(afterDinner);
            Day workDay24 = new Day(new DateTime(2017, 3, 7), "Стандартный рабочий день");
            workDay24.AddWorkTimeSpan(beforeDinner);
            workDay24.AddWorkTimeSpan(afterDinner);
            Day workDay25 = new Day(new DateTime(2017, 3, 8), "Праздник 8 марта!!!");
            workDay25.AddWorkTimeSpan(beforeDinner);
            workDay25.AddWorkTimeSpan(afterDinner);
            Day workDay26 = new Day(new DateTime(2017, 3, 9), "Стандартный рабочий день");
            workDay26.AddWorkTimeSpan(beforeDinner);
            workDay26.AddWorkTimeSpan(afterDinner);
            Day workDay27 = new Day(new DateTime(2017, 3, 10), "Стандартный рабочий день");
            workDay27.AddWorkTimeSpan(beforeDinner);
            workDay27.AddWorkTimeSpan(afterDinner);
            Day workDay28 = new Day(new DateTime(2017, 3, 11), "Выходной");
            Day workDay29 = new Day(new DateTime(2017, 3, 12), "Выходной");
            Day workDay30 = new Day(new DateTime(2017, 3, 13), "Стандартный рабочий день");
            workDay30.AddWorkTimeSpan(beforeDinner);
            workDay30.AddWorkTimeSpan(afterDinner);
            

            List<Day> dayCollection = new List<Day>();

            dayCollection.Add(workDay17);
            dayCollection.Add(workDay18);
            dayCollection.Add(workDay19);
            dayCollection.Add(workDay20);
            dayCollection.Add(workDay21);
            dayCollection.Add(workDay22);
            dayCollection.Add(workDay23);
            dayCollection.Add(workDay24);
            dayCollection.Add(workDay25);
            dayCollection.Add(workDay26);


            dayCollection.Add(workDay);
            dayCollection.Add(workDay1);
            dayCollection.Add(workDay2);
            dayCollection.Add(workDay3);
            dayCollection.Add(workDay4);
            dayCollection.Add(workDay5);
            dayCollection.Add(workDay6);
            dayCollection.Add(workDay7);
            dayCollection.Add(workDay8);
            dayCollection.Add(workDay9);
            dayCollection.Add(workDay10);
            dayCollection.Add(workDay11);
            dayCollection.Add(workDay12);
            dayCollection.Add(workDay13);
            dayCollection.Add(workDay14);
            dayCollection.Add(workDay15);
            dayCollection.Add(workDay16);
            
            dayCollection.Add(workDay27);
            dayCollection.Add(workDay28);
            dayCollection.Add(workDay29);
            dayCollection.Add(workDay30);

            return dayCollection;
        }
    }
}
