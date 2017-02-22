namespace Task1.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic;
    using Task1.Objects;

    /// <summary>
    /// Реализация нерабочего сервиса доступа к данным.
    /// </summary>
    /// <remarks>
    /// Не хранит данные вообще.
    /// </remarks>
    public class EmptyDataService : IDataService
    {
        /// <summary>
        /// Коллекция для хранения объектов.
        /// </summary>
        private List<Consumer> _consumersStorage;

        public EmptyDataService()
        {
            _consumersStorage = new List<Consumer>();
        }

        /// <summary>
        /// Добавляет объект в хранилище.
        /// </summary>
        /// <param name="consumer">
        /// Объект, которого необходим - добавить в хранилище
        /// </param>
        public void AddConsumer(Consumer consumer)
        {
        }

        /// <summary>
        /// Удалить все объекты из хранилища.
        /// </summary>
        public void ClearConsumers()
        {
        }

        /// <summary>
        /// Удаляет объект из хранилища по коду.
        /// </summary>
        /// <param name="CodeConsumer">
        /// Код объекта, который необходимо использовать для удаления объекта из хранилища.
        /// </param>
        public void DeleteConsumer(string CodeConsumer)
        {
        }

        /// <summary>
        /// Получает объекта из хранилища по коду алгоритма 1.
        /// </summary>
        /// <param name="CodeConsumer">
        /// Код объекта, который необходимо использовать для получения объекта из хранилища.
        /// </param>
        /// <returns>
        /// Объект, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        public Consumer GetConsumer(string CodeConsumer)
        {
            return null;
        }

        /// <summary>
        /// Получает объекта из хранилища по коду алгоритма 2.
        /// </summary>
        /// <param name="CodeConsumer">
        /// Код объекта, который необходимо использовать для получения объекта из хранилища.
        /// </param>
        /// <returns>
        /// Объект, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        public Consumer GetConsumer2(string CodeConsumer)
        {
            return null;
        }

        /// <summary>
        /// Получить всех объектов из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех объектов из хранилища.
        /// </returns>
        public IEnumerable<Consumer> GetAllConsumers()
        {
            return _consumersStorage;
        }
    }
}
