using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTennisTournament.DAL
{
    using TableTennisTournament.Objects;

    public interface IDataService
    {
        /// <summary>
        /// Добавить матч в хранилище.
        /// </summary>
        /// <param name="player_A">Первый игрок.</param>
        /// <param name="player_B">Второй игрок.</param>
        /// <param name="gameTime">Дата и время матча.</param>
        void AddMatch(Match match);

        /// <summary>
        /// Добавить игрока в хранилище.
        /// </summary>
        /// <param name="player">Игрок, которого необходим добавить в хранилище.</param>
        void AddPlayer(Player player);
        
        /// <summary>
        /// Получет игрока по индексу.
        /// </summary>
        /// <param name="playerGuid">Индекс игрока.</param>
        Player GetPlayer(Guid playerGuid);

        Match GetMatch(Player playerA, Player playerB, DateTime gameTime);

        /// <summary>
        /// Удаление игрока по его guid.
        /// </summary>
        /// <param name="playerGuid"></param>
        void DeletePlayer(Guid playerGuid);


        void DeletePlayer(Player player);
        /// <summary>
        /// Удалить всех игроков из хранилища
        /// </summary>
        void DropAllPlayer();

        /// <summary>
        /// Удалить все матчи из хранлища.
        /// </summary>
        void DropAllMatch();

        /// <summary>
        /// Получить всех игроков из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех игроков
        /// </returns>
        IEnumerable<Player> GetAllPlayer();

        /// <summary>
        /// Получить все матчи из хранилища.
        /// </summary>
        /// <returns>
        /// Список всех матчей.
        /// </returns>
        IEnumerable<Match> GetAllMatch();
    }
}
