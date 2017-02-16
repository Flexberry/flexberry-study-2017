namespace AcademicPerformance.DAL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CodeGenerator;
    using AcademicPerformance.Objects;

    /// <summary>
    /// Реализация сервиса доступа к данным по умолчанию.
    /// </summary>
    /// <remarks>
    /// Не хранит данные персистентно. Не использует базы данных.
    /// </remarks>
    public class DefaultDataService : IDataService
    {
        /// <summary>
        /// Коллекция для ъранения студентов.
        /// </summary>
        private List<Студент> _studentsStorage;

        public DefaultDataService()
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
            var кодЗачетки = CodeGenerator.GetCodeForRecordBook(студент);
            var существующиtСтуденты = from с in _studentsStorage
                where CodeGenerator.GetCodeForRecordBook(с) == кодЗачетки
                select с;
            var существующийСтудент = существующиtСтуденты.FirstOrDefault();

            if (существующийСтудент != null)
            {
                throw new Exception("Невозможно добавить студента с такими данными, т.к. номер зачетки для него не будет уникальным!");
            }

            _studentsStorage.Add(студент);
        }

        /// <summary>
        /// Удалить всех студентов из хранилища.
        /// </summary>
        public void ClearStudents()
        {
            _studentsStorage.Clear();
        }

        /// <summary>
        /// Удаляет студента из хранилища по коду зачетки.
        /// </summary>
        /// <param name="кодЗачетки">
        /// Код зачетки, который необходимо использовать для удаления студента из хранилища.
        /// </param>
        public void DeleteStudent(string кодЗачетки)
        {
            var студент = GetStudent(кодЗачетки);
            _studentsStorage.Remove(студент);
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
            return _studentsStorage.FirstOrDefault(студент => CodeGenerator.GetCodeForRecordBook(студент) == кодЗачетки);
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
