using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennisTournament.Objects;

namespace TableTennisTournament.Tests
{
    using RatingPosition;
    [TestClass]
    public class UnitTest1
    {
        private readonly Rating ratingElo = new Rating();

        private readonly Player _playerMax = new Player()
        {
            Login = "Player_Max",
            Rating = 2400
        };

        private readonly Player _playerMiddle = new Player()
        {
            Login = "Player_middle",
            Rating = 1200
        };
        [TestMethod]
        public void Rating_Looser_Win()
        {
            _playerMiddle.Rating = 1200;
            _playerMax.Rating = 2400;
            var match = new Match()
            {
                GameFactor = 16,
                PlayerOne = _playerMiddle,
                PlayerTwo = _playerMax,
                Result = 1
            };
            ratingElo.GetNewPlayerRating(match);
            
            Assert.AreEqual(1216,match.PlayerOne.Rating);
            Assert.AreEqual(2384, match.PlayerTwo.Rating);
        }

        [TestMethod]
        public void Rating_Powerfull_Win()
        {
            _playerMiddle.Rating = 1200;
            _playerMax.Rating = 1300;
            var match = new Match()
            {
                GameFactor = 16,
                PlayerOne = _playerMiddle,
                PlayerTwo = _playerMax,
                Result = 0
            };
            ratingElo.GetNewPlayerRating(match);
           
            Assert.AreEqual(1194, match.PlayerOne.Rating);
            Assert.AreEqual(1306, match.PlayerTwo.Rating);
        }

        [TestMethod]
        public void Rating_Pair()
        {
            _playerMiddle.Rating = 1200;
            _playerMax.Rating = 1300;
            var match = new Match()
            {
                GameFactor = 16,
                PlayerOne = _playerMiddle,
                PlayerTwo = _playerMax,
                Result = -1
            };
            ratingElo.GetNewPlayerRating(match);

            Assert.AreEqual(1200, match.PlayerOne.Rating);
            Assert.AreEqual(1300, match.PlayerTwo.Rating);
        }
    }
}
