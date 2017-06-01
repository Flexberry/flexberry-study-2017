namespace AcademicPerformance.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AcademicPerformance.Objects;

    /// <summary>
    /// Интерфейс для сервиса доступа к данным.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Добавляет договоры в хранилище.
        /// </summary>
        /// <param name="договор">
        /// Договор, который необходим добавить в хранилище
        /// </param>
        void AddDogovor(Договор договор);

        /// <summary>
        /// Получает договоры из хранилища по номеру договора.
        /// </summary>
        /// <param name="кодДоговора">
        /// Номер договора, который необходимо использовать для получения договора из хранилища.
        /// </param>
        /// <returns>
        /// Договор, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        Договор GetDogovor(string кодДоговора);

        /// <summary>
        /// Удаляет договоры из хранилища по номеру договора.
        /// </summary>
        /// <param name="кодДоговора">
        /// Номер договора, который необходимо использовать для удаления договора из хранилища.
        /// </param>
        void DeleteDogovor(string кодДоговора);

        /// <summary>
        /// Удалить все договоры из хранилища.
        /// </summary>
        void ClearDogovors();

        /// <summary>
        /// Получить все договоры из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех договоров из хранилища.
        /// </returns>
        IEnumerable<Договор> GetAllDogovors();
    }
}
