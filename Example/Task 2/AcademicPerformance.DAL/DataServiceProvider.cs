using System;
using System.Collections.Generic;
using System.Linq;
namespace AcademicPerformance.DAL
{
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Класс для получения сервиса доступа к данным <see cref="IDataService"/>.
    /// </summary>
    public class DataServiceProvider
    {
        /// <summary>
        /// Ленивый инициализатор сервиса доступа к данным по умолчанию.
        /// </summary>
        private static readonly Lazy<IDataService> DefaultHolder = new Lazy<IDataService>();

        /// <summary>
        /// Текущий (установленный извне) сервис доступа к данным.
        /// </summary>
        private static IDataService _dataService;

        /// <summary>
        /// Текущий сервис доступа к данным.
        /// </summary>
        /// <remarks>
        /// Не может быть <c>null</c>.
        /// Если пользовательский сервис данных не установлен, используется реализация по умолчанию.
        /// </remarks>
        public static IDataService Current
        {
            get { return _dataService ?? Default; }
            set { _dataService = value;  }
        }

        /// <summary>
        /// Сервис доступа к данным по умолчанию.
        /// </summary>
        /// <remarks>
        /// Не может быть <c>null</c>.
        /// </remarks>
        internal static IDataService Default => DefaultHolder.Value;
    }
}
