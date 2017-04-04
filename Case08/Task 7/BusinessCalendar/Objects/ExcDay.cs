using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS.BusinessCalendar
{
    using ICSSoft.STORMNET;
    /// <summary>
    /// Вспомагательный класс, тот же "ExceptionDay" только без циклических ссылок. Необходим для отправки на клиент объектов типа "ExceptionDay"
    /// </summary>
    public class ExcDay
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public string PrimaryKey { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public double StartDate { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public double EndDate { get; set; }
        /// <summary>
        /// Количество повторений
        /// </summary>
        public int RecurrenceCount { get; set; }
        /// <summary>
        /// Шаг повторения
        /// </summary>
        public int RepeatStep { get; set; }
        /// <summary>
        /// Тип повторения
        /// </summary>
        public string RecurrenceType { get; set; }
    }
}
