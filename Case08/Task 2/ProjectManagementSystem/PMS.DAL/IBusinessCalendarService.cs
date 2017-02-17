using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL
{
    using PMS.Objects;

    /// <summary>
    /// Интерфейс доступа к информации о днях
    /// </summary>
    public interface IBusinessCalendarService
    {
        IEnumerable<ExceptionDay> GetDaysCollection(DateTime dateStart, DateTime dateFinish);
        void AddDay(DateTime DateStart,
            DateTime DateFinish,
            int IterationCount,
            IterationTipe IterationTipe,
            bool IsWorkDay,
            string Description,
            List<WorkTimeSpan> workTimeSpanCollection);
    }
}
