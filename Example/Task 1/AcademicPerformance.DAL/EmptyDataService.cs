namespace AcademicPerformance.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CodeGenerator;
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
        /// Коллекция для ъранения студентов.
        /// </summary>
        private List<Студент> _studentsStorage;

        public EmptyDataService()
        {
            _studentsStorage = new List<Студент>();
        }

        /// <summary>
        /// Добавляет студента в хранилище.
        /// </summary>
        /// <param name="студент">
        /// Студент, которого необходим добавить в хранилище
        /// </param>
        public void AddStudent(Студент студент)
        {
        }

        /// <summary>
        /// Удалить всех студентов из хранилища.
        /// </summary>
        public void ClearStudents()
        {
        }

        /// <summary>
        /// Удаляет студента из хранилища по коду зачетки.
        /// </summary>
        /// <param name="кодЗачетки">
        /// Код зачетки, который необходимо использовать для удаления студента из хранилища.
        /// </param>
        public void DeleteStudent(string кодЗачетки)
        {
        }

        /// <summary>
        /// Получает студента из хранилища по коду зачетки.
        /// </summary>
        /// <param name="кодЗачетки">
        /// Код зачетки, который необходимо использовать для получения студента из хранилища.
        /// </param>
        /// <returns>
        /// Студент, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        public Студент GetStudent(string кодЗачетки)
        {
            return null;
        }

        /// <summary>
        /// Получить всех студентов из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех студентов из хранилища.
        /// </returns>
        public IEnumerable<Студент> GetAllStudents()
        {
            return _studentsStorage;
        }
    }
}
