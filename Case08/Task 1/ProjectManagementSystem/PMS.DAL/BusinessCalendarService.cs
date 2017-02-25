using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Objects;

namespace PMS.DAL
{
    /// <summary>
    /// Класс доступа к инфомрации о днях
    /// </summary>
    public class BusinessCalendarService : IBusinessCalendarService
    {
        /// <summary>
        /// Метод для получения информации о днях за заданный промежуток времени
        /// </summary>
        /// <param name="dateStart">дата начала промежутка</param>
        /// <param name="dateFinish">дата окончания промежутка</param>
        /// <returns></returns>
        public IEnumerable<Day> GetDays(DateTime dateStart, DateTime dateFinish)
        {
            List<Day> gap =
               days.Where<Day>(e => (e.GetDate() >= dateStart) && (e.GetDate() <= dateFinish)).ToList<Day>();
            return gap;
        }
        private List<Day> days; //настоящего источника данных нет(пока), создаём искусственный, чтобы тестировать приложение
        public BusinessCalendarService()
        {
            //Формируем искусственный источник данных
            days = getArtificialDays();
        }

        /// <summary>
        /// Метод искусственно создаёт информацию о днях
        /// </summary>
        /// <returns></returns>
        private List<Day> getArtificialDays()
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


            List<Day> days = new List<Day>();

            days.Add(workDay17);
            days.Add(workDay18);
            days.Add(workDay19);
            days.Add(workDay20);
            days.Add(workDay21);
            days.Add(workDay22);
            days.Add(workDay23);
            days.Add(workDay24);
            days.Add(workDay25);
            days.Add(workDay26);


            days.Add(workDay);
            days.Add(workDay1);
            days.Add(workDay2);
            days.Add(workDay3);
            days.Add(workDay4);
            days.Add(workDay5);
            days.Add(workDay6);
            days.Add(workDay7);
            days.Add(workDay8);
            days.Add(workDay9);
            days.Add(workDay10);
            days.Add(workDay11);
            days.Add(workDay12);
            days.Add(workDay13);
            days.Add(workDay14);
            days.Add(workDay15);
            days.Add(workDay16);

            days.Add(workDay27);
            days.Add(workDay28);
            days.Add(workDay29);
            days.Add(workDay30);

            return days;
        }
    }
}
