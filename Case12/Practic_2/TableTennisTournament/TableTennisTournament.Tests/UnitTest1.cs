using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennisTournament.Objects;

namespace TableTennisTournament.Tests
{
    using RatingPosition;
    [TestClass]
    public class UnitTest1
    {
        Player player_MAX = new Player()
        {
            Login = "Player_Max",
            Rating = 2400
        };
        Player player_middle = new Player()
        {
            Login = "Player_middle",
            Rating = 1200
        };


        //[TestMethod]
        //public void Bonus_zero_max()
        //{
        //    var looser = Rating.FutureBonus(0,1200);
        //    var power = Rating.FutureBonus(1200, 0);
        //    var sum = Math.Round(looser + power, 3);
        //    Assert.AreEqual(1,sum);
        //}

        //[TestMethod]
        //public void Bonus_zero_about_equal()
        //{
        //    var looser = Rating.FutureBonus(1000, 1200);
        //    var power = Rating.FutureBonus(1200, 1000);
        //    var sum = Math.Round(looser + power,3);
        //    Assert.AreEqual(1, sum);
        //}

        //[TestMethod]
        //public void Bonus_equal_win()
        //{
        //    var power = Rating.FutureBonus(1200, 1200);
        //    Assert.AreEqual(0.5, power);
        //}

        [TestMethod]
        public void Rating_Looser_Win()
        {
            player_middle.Rating = 1200;
            player_MAX.Rating = 2400;
            var match = new Match()
            {
                GameFactor = 16,
                PlayerOne = player_middle,
                PlayerTwo = player_MAX,
                Result = 1
            };
           Rating.GetNewPlayerRating(match);
            
            Assert.AreEqual(1216,match.PlayerOne.Rating);
            Assert.AreEqual(2384, match.PlayerTwo.Rating);
        }

        [TestMethod]
        public void Rating_Powerfull_Win()
        {
            player_middle.Rating = 1200;
            player_MAX.Rating = 1300;
            var match = new Match()
            {
                GameFactor = 16,
                PlayerOne = player_middle,
                PlayerTwo = player_MAX,
                Result = 0
            };
            Rating.GetNewPlayerRating(match);
           
            Assert.AreEqual(1194, match.PlayerOne.Rating);
            Assert.AreEqual(1306, match.PlayerTwo.Rating);
        }

        [TestMethod]
        public void Rating_Pair()
        {
            player_middle.Rating = 1200;
            player_MAX.Rating = 1300;
            var match = new Match()
            {
                GameFactor = 16,
                PlayerOne = player_middle,
                PlayerTwo = player_MAX,
                Result = 0.5
            };
            Rating.GetNewPlayerRating(match);

            Assert.AreEqual(1202, match.PlayerOne.Rating);
            Assert.AreEqual(1298, match.PlayerTwo.Rating);
        }
    }
}
