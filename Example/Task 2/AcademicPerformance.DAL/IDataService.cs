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
        /// Добавляет студента в хранилище.
        /// </summary>
        /// <param name="студент">
        /// Студент, которого необходим добавить в хранилище
        /// </param>
        void AddStudent(Студент студент);

        /// <summary>
        /// Получает студента из хранилища по коду зачетки.
        /// </summary>
        /// <param name="кодЗачетки">
        /// Код зачетки, который необходимо использовать для получения студента из хранилища.
        /// </param>
        /// <returns>
        /// Студент, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        Студент GetStudent(string кодЗачетки);

        /// <summary>
        /// Удаляет студента из хранилища по коду зачетки.
        /// </summary>
        /// <param name="кодЗачетки">
        /// Код зачетки, который необходимо использовать для удаления студента из хранилища.
        /// </param>
        void DeleteStudent(string кодЗачетки);

        /// <summary>
        /// Удалить всех студентов из хранилища.
        /// </summary>
        void ClearStudents();

        /// <summary>
        /// Получить всех студентов из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех студентов из хранилища.
        /// </returns>
        IEnumerable<Студент> GetAllStudents();
    }
}
