namespace AcademicPerformance.DAL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CheckNumber;
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
        /// Коллекция для хранения договоров.
        /// </summary>
        private List<Договор> _dogovorsStorage;

        public DefaultDataService()
        {
            _dogovorsStorage = new List<Договор>();
        }

        /// <summary>
        /// Добавляет договоры в хранилище.
        /// </summary>
        /// <param name="договор">
        /// Договор, который необходимо добавить в хранилище
        /// </param>
        public void AddDogovor(Договор договор)
        {
            if (CheckNumber.GetCodeForRecordBook(договор) == true)
            { 
                var номер = договор.номерДоговора;
            foreach (Договор c in _dogovorsStorage)
            {
                if (c.номерДоговора == номер)
                {
                    throw new Exception("Договор с таким номером уже существует!");
                }
            }

            _dogovorsStorage.Add(договор);
        }
            else
            {
                throw new Exception("Номер договора некорректен или есть незаполненные поля!");
            }
                 
        }

        /// <summary>
        /// Удалить всех договоры из хранилища.
        /// </summary>
        public void ClearDogovors()
        {
            _dogovorsStorage.Clear();
        }

        /// <summary>
        /// Удаляет договоры из хранилища по номеру.
        /// </summary>
        /// <param name="номерДоговора">
        /// Номер договора, который необходимо использовать для удаления договора из хранилища.
        /// </param>
        public void DeleteDogovor(string номерДоговора)
        {
            var договор = GetDogovor(номерДоговора);
            _dogovorsStorage.Remove(договор);
        }

        /// <summary>
        /// Получает договоры из хранилища по номеру.
        /// </summary>
        /// <param name="кодДоговора">
        /// Номер договора, который необходимо использовать для получения договора из хранилища.
        /// </param>
        /// <returns>
        /// Договор, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        public Договор GetDogovor(string номер)
        {
            return _dogovorsStorage.FirstOrDefault(договор =>  договор.номерДоговора == номер);
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
