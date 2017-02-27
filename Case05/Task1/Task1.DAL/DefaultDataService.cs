namespace Task1.DAL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Logic;
    using Task1.Objects;

    /// <summary>
    /// Реализация сервиса доступа к данным по умолчанию.
    /// </summary>
    /// <remarks>
    /// Не хранит данные персистентно. Не использует базы данных.
    /// </remarks>
    public class DefaultDataService : IDataService
    {
        /// <summary>
        /// Коллекция для хранения объектов.
        /// </summary>
        private List<Consumer> _consumersStorage;

        public DefaultDataService()
        {
            _consumersStorage = new List<Consumer>();
        }

        /// <summary>
        /// Добавляет объект в хранилище по двум алгоритмам.
        /// </summary>
        /// <param name="consumer">
        /// Объект, который необходимо добавить в хранилище
        /// </param>
        public void AddConsumer(Consumer consumer)
        {
            var CodeConsumer = Logic1.GenerateCode(consumer);
            var availableConsumers = from с in _consumersStorage
                where Logic1.GenerateCode(с) == CodeConsumer
                select с;

            var CodeConsumer2 = Logic2.GenerateCode(consumer);
            var availableConsumers2 = from с in _consumersStorage
                                     where Logic2.GenerateCode(с) == CodeConsumer
                                     select с;

            if (availableConsumers.FirstOrDefault() != null)
            {
                throw new Exception("Невозможно добавить объект с такими данными, т.к. код для него не будет уникальным!");
            }

            if (availableConsumers2.FirstOrDefault() != null)
            {
                throw new Exception("Невозможно добавить объект с такими данными, т.к. код для него не будет уникальным!");
            }

            _consumersStorage.Add(consumer);
        }

       /* /// <summary>
        /// Добавляет объект в хранилище по алгоритму 2.
        /// </summary>
        /// <param name="consumer2">
        /// Объект, который необходимо добавить в хранилище
        /// </param>
        public void Add2Consumer(Consumer consumer)
        {   
            var CodeConsumer = Logic2.GenerateCode(consumer);
            var availableConsumers = from с in _consumersStorage
                                     where Logic2.GenerateCode(с) == CodeConsumer
                                     select с;

            if (availableConsumers.FirstOrDefault() != null)
            {
                throw new Exception("Невозможно добавить объект с такими данными, т.к. код для него не будет уникальным!");
            }

            _consumersStorage.Add(consumer);
        }*/

        /// <summary>
        /// Удалить всеобхекты из хранилища.
        /// </summary>
        public void ClearConsumers()
        {
            _consumersStorage.Clear();
        }

        /// <summary>
        /// Удаляет объекты из хранилища по коду.
        /// </summary>
        /// <param name="CodeConsumer">
        /// Код объекта, который необходимо использовать для удаления объекта из хранилища.
        /// </param>
        public void DeleteConsumer(string CodeConsumer)
        {
            var consumer = GetConsumer(CodeConsumer);
            _consumersStorage.Remove(consumer);
        }

        /// <summary>
        /// Получает объект из хранилища по коду алгоритма 1.
        /// </summary>
        /// <param name="CodeConsumer">
        /// Код, который необходимо использовать для получения объекта из хранилища.
        /// </param>
        /// <returns>
        /// Объект, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        public Consumer GetConsumer(string CodeConsumer)
        {
            return _consumersStorage.FirstOrDefault(Consumer => Logic1.GenerateCode(Consumer) == CodeConsumer);
        }

        /// <summary>
        /// Получает объект из хранилища по коду алгоритма 2.
        /// </summary>
        /// <param name="CodeConsumer">
        /// Код, который необходимо использовать для получения объекта из хранилища.
        /// </param>
        /// <returns>
        /// Объект, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        public Consumer GetConsumer2(string CodeConsumer)
        {
            return _consumersStorage.FirstOrDefault(Consumer => Logic2.GenerateCode(Consumer) == CodeConsumer);
        }
        /// <summary>
        /// Получить все объекты из хранилища.
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
