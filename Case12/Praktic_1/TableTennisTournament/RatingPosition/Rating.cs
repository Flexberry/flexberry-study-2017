using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTennisTournament.Objects;

namespace RatingPosition
{
    public class Rating
    {
        private static int magicK = 16;

        public static double FutureBonus(double ratingA, double ratingB)
        {
            var pow = (ratingB - ratingA)/400;
            return 1/(1 + Math.Pow(10, pow));
        }

        public static int GetNewRating(int currentRating,double matchResult, double bonusRating)
        {
            return currentRating + (int) Math.Round(magicK * (matchResult - bonusRating));
        }

        public static void GetNewPlayerRating(Match match)
        {
            magicK = match.GameFactor;
            var matchResult_ViewA = match.Result;
            var matchResult_ViewB = 1 - matchResult_ViewA;
            var bonus_ViewA = FutureBonus(match.PlayerOne.Rating,match.PlayerTwo.Rating);
            var bonus_ViewB= 1-bonus_ViewA;
            match.PlayerOne.Rating = GetNewRating(match.PlayerOne.Rating, matchResult_ViewA, bonus_ViewA);
            match.PlayerTwo.Rating = GetNewRating(match.PlayerTwo.Rating, matchResult_ViewB, bonus_ViewB);
        }
    }
}
