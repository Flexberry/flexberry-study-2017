namespace AcademicPerformance.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CheckNumber;
    using AcademicPerformance.Objects;

    /// <summary>
    /// Реализация нерабочего сервиса доступа к данным.
    /// </summary>
    /// <remarks>
    /// Не хранит данные вообще.
    /// </remarks>
    public class EmptyDataService : IDataService
    {
        /// <summary>
        /// Коллекция для хранения договоров.
        /// </summary>
        private List<Договор> _dogovorsStorage;

        public EmptyDataService()
        {
            _dogovorsStorage = new List<Договор>();
        }

        /// <summary>
        /// Добавляет договоры в хранилище.
        /// </summary>
        /// <param name="договор">
        /// Договор, который необходим добавить в хранилище
        /// </param>
        public void AddDogovor(Договор договор)
        {
        }

        /// <summary>
        /// Удалить все договоры из хранилища.
        /// </summary>
        public void ClearDogovors()
        {
        }

        /// <summary>
        /// Удаляет договоры из хранилища по номеру договора.
        /// </summary>
        /// <param name="номерДоговора">
        /// Номер договора, который необходимо использовать для удаления договора из хранилища.
        /// </param>
        public void DeleteDogovor(string номерДоговора)
        {
        }

        /// <summary>
        /// Получает договоры из хранилища по номеру договора.
        /// </summary>
        /// <param name="кодДоговора">
        /// Номер договора, который необходимо использовать для получения договора из хранилища.
        /// </param>
        /// <returns>
        /// Договор, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        public Договор GetDogovor(string кодДоговора)
        {
            return null;
        }

        /// <summary>
        /// Получить все договоры из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех договоров из хранилища.
        /// </returns>
        public IEnumerable<Договор> GetAllDogovors()
        {
            return _dogovorsStorage;
        }
    }
}
