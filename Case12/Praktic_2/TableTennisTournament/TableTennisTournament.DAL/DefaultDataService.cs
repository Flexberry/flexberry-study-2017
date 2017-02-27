using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTennisTournament.Objects;

namespace TableTennisTournament.DAL
{
    public class DefaultDataService : IDataService
    {
        internal List<Player> PlayersList;
        internal List<Match> MatchesList;

        public DefaultDataService()
        {
            PlayersList = new List<Player>();
            MatchesList = new List<Match>();
        }

        public void AddMatch(Match match)
        {

            if (GetMatch(match.PlayerOne, match.PlayerTwo, match.PlayDateTime) == null)
            {
                MatchesList.Add(match);
            }
        }

        public void AddPlayer(Player player)
        {
            if (GetPlayer(player.PlayerGuid) == null)
            {
                PlayersList.Add(player);
            }
        }

        public Player GetPlayer(string playerLogin)
        {
            return PlayersList.FirstOrDefault(player => player.Login == playerLogin);
        }

        public Player GetPlayer(Guid playerGuid)
        {
            return PlayersList.FirstOrDefault(player => player.PlayerGuid == playerGuid);
        }

        public Match GetMatch(Player playerA, Player playerB, DateTime gameTime)
        {
            return MatchesList.FirstOrDefault(
                x =>
                    x.PlayDateTime == gameTime &&
                    ((x.PlayerOne == playerA & x.PlayerTwo == playerB) |
                     (x.PlayerOne == playerB & x.PlayerTwo == playerA)));
        }

        public Match GetMatch(Guid matchGuid)
        {
            return MatchesList.FirstOrDefault(
                x => x.MatchGuid == matchGuid);
        }

        public void DeletePlayer(Guid playerGuid)
        {
            var player = GetPlayer(playerGuid);
            DeletePlayer(player);
        }

        public void DeletePlayer(Player player)
        {
            PlayersList.Remove(player);
        }

        public void DropAllPlayer()
        {
            PlayersList.Clear();
        }

        public void DropAllMatch()
        {
            MatchesList.Clear();
        }

        public IEnumerable<Player> GetAllPlayer()
        {
            return PlayersList;
        }

        public IEnumerable<Match> GetAllMatch()
        {
            return MatchesList;
        }
    }
}
