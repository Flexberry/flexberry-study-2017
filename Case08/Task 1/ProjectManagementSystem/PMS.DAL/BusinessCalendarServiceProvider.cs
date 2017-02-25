using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL
{
    /// <summary>
    /// Класс для получения сервиса доступа к данным <see cref="IBusinessCalendarService"/> 
    /// </summary>
    public class BusinessCalendarServiceProvider
    {
        /// <summary>
        /// Отложенный инициализатор сервиса доступа к данным по умолчанию.
        /// </summary>
        private static readonly Lazy<IBusinessCalendarService> DefaultHolder = new Lazy<IBusinessCalendarService>();

        /// <summary>
        /// Исправляем проблему с многопоточностью
        /// </summary>
        private static object syncRoot = new object();
        /// <summary>
        /// Текущий (установленный извне) сервис доступа к данным.
        /// </summary>
        private static IBusinessCalendarService _dataService;

        /// <summary>
        /// Текущий сервис доступа к данным.
        /// </summary>
        /// <remarks>
        /// Не может быть <c>null</c>.
        /// Если пользовательский сервис данных не установлен, используется реализация по умолчанию.
        /// </remarks>
        public static IBusinessCalendarService Current
        {
            get {
                lock (syncRoot)
                {
                    return _dataService ?? Default;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    _dataService = value;
                }
            }
        }
        /// <summary>
        /// Сервис доступа к данным по умолчанию
        /// </summary>
        internal static IBusinessCalendarService Default => DefaultHolder.Value;
    }
}
