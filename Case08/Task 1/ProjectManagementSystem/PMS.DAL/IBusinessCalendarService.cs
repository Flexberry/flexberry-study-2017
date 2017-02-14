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
        IEnumerable<Day> GetDaysCollection(DateTime dateStart, DateTime dateFinish);
    }
}
