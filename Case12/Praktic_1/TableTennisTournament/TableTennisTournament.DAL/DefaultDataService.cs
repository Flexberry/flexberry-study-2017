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
        internal List<Player> _PlayersList;
        internal List<Match> _MatchesList;
        public DefaultDataService()
        {
            _PlayersList = new List<Player>();
            _MatchesList = new List<Match>();
        }
        
        public void AddMatch(Match match)
        {
            
            if (GetMatch(match.PlayerOne,match.PlayerTwo,match.PlayDateTime) == null)
            {
                _MatchesList.Add( match);
            }
        }

        public void CreateNPlayers(int count)
        {
            Random rnd = new Random();
            for (var i = 1; i < count+1; i++)
            {
               var temp =new Player()
                {
                    firstName = "Champion_"+i,
                    MiddleName = "Champ_"+i,
                    LastName = "Player_"+i,
                    Login = "play_"+i,
                    Rating = 1400+ rnd.Next(-200,200),
                    PlayerGuid = Guid.NewGuid()
                };
                AddPlayer(temp);
            }
        }

        public void AddPlayer(Player player)
        {
            if (GetPlayer(player.PlayerGuid)== null)
            {
                _PlayersList.Add(player);
            }
        }

        public Player GetPlayer(Guid playerGuid)
        {
            return _PlayersList.FirstOrDefault(player => player.PlayerGuid == playerGuid);
        }

        public Match GetMatch(Player playerA, Player playerB, DateTime gameTime)
        {
            return _MatchesList.FirstOrDefault(
                    x =>
                        x.PlayDateTime == gameTime &&
                        (x.PlayerOne == playerA & x.PlayerTwo == playerB) ^
                        (x.PlayerOne == playerB & x.PlayerTwo == playerA));
        }
        public void DeletePlayer(Guid playerGuid)
        {
            var player = GetPlayer(playerGuid);
            DeletePlayer(player);
        }

        public void DeletePlayer(Player player)
        {
            _PlayersList.Remove(player);
        }

        public void DropAllPlayer()
        {
           _PlayersList.Clear();
        }

        public void DropAllMatch()
        {
           _MatchesList.Clear();
        }

        public IEnumerable<Player> GetAllPlayer()
        {
            return _PlayersList;
        }

        public IEnumerable<Match> GetAllMatch()
        {
            return _MatchesList;
        }



    }
}
