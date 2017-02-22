namespace Task1.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Task1.Objects;

    /// <summary>
    /// Интерфейс для сервиса доступа к данным.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Добавляет объект в хранилище.
        /// </summary>
        /// <param name="consumer">
        /// объект, которого необходим добавить в хранилище
        /// </param>
        void AddConsumer(Consumer consumer);

        /// <summary>
        /// Получает объект из хранилища по коду алгоритма 1.
        /// </summary>
        /// <param name="CodeObject">
        /// Код объекта, который необходимо использовать для получения записи из хранилища.
        /// </param>
        /// <returns>
        /// Объект, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        Consumer GetConsumer(string CodeObject);

        /// <summary>
        /// Получает объект из хранилища по коду алгоритма 2 .
        /// </summary>
        /// <param name="CodeObject">
        /// Код объекта, который необходимо использовать для получения записи из хранилища.
        /// </param>
        /// <returns>
        /// Объект, найденный в хранилище данных, либо <c>null</c>.
        /// </returns>
        Consumer GetConsumer2(string CodeObject);

        /// <summary>
        /// Удаляет объект из хранилища по коду.
        /// </summary>
        /// <param name="CodeObject">
        /// Код, который необходимо использовать для удаления объекта из хранилища.
        /// </param>
        void DeleteConsumer(string CodeObject);

        /// <summary>
        /// Удалить все объекты из хранилища.
        /// </summary>
        void ClearConsumers();

        /// <summary>
        /// Получить все объекты из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех объектов из хранилища.
        /// </returns>
        IEnumerable<Consumer> GetAllConsumers();
    }
}
