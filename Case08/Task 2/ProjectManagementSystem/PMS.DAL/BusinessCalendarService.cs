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

        private List<ExceptionDay> days;
        /// <summary>
        /// Метод для получения информации о днях за заданный промежуток времени
        /// </summary>
        /// <param name="dateStart">дата начала промежутка</param>
        /// <param name="dateFinish">дата окончания промежутка</param>
        /// <returns></returns>
        public IEnumerable<ExceptionDay> GetDaysCollection(DateTime dateStart, DateTime dateFinish)
        {
            List<ExceptionDay> gap =
               days.Where<ExceptionDay>(e => (e.GetDate() >= dateStart) && (e.GetDate() <= dateFinish)).ToList<ExceptionDay>();
            return gap;
        }
         //настоящего источника данных нет(пока), создаём искусственный, чтобы тестировать приложение
        public BusinessCalendarService()
        {
            //Формируем искусственный источник данных
            days = generateArtificialCollection();
        }

        /// <summary>
        /// Метод искусственно создаёт информацию о днях
        /// </summary>
        /// <returns></returns>
        private List<ExceptionDay> generateArtificialCollection()
        {
            List<ExceptionDay> artificialGeneratedDays = new List<ExceptionDay>();
            return artificialGeneratedDays;
        }

        public void AddDay(DateTime DateStart,
            DateTime DateFinish,
            int IterationCount,
            IterationTipe IterationTipe,
            bool IsWorkDay,
            string Description,
            List<WorkTimeSpan> workTimeSpanCollection)
        {
            throw new NotImplementedException();
        }
    }
}
