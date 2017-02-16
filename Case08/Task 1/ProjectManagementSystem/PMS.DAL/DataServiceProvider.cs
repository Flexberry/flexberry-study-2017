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
    public class DataServiceProvider
    {
        private static readonly Lazy<IBusinessCalendarService> DefaultHolder = new Lazy<IBusinessCalendarService>();

        private static IBusinessCalendarService _dataService;

        public static IBusinessCalendarService Current
        {
            get { return _dataService ?? Default; }
            set { _dataService = value; }
        }

        /// <summary>
        /// Сервис доступа к данным по умолчанию
        /// </summary>
        internal static IBusinessCalendarService Default => DefaultHolder.Value;
    }
}
