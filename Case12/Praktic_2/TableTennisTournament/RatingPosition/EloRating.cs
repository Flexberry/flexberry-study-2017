using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTennisTournament.Objects;

namespace RatingPosition
{
    public class EloRating : IRating
    {
        private double FutureBonus(double ratingA, double ratingB)
        {
            double pow = (ratingB - ratingA)/400;
            return 1/(1 + Math.Pow(10, pow));
        }

        public int ChangeInRating(int currentRating, int enemyRating, int matchResult, int gameFactor)
        {

            double bonusRating = FutureBonus(currentRating, enemyRating);
            double change = gameFactor*(matchResult - bonusRating);
            change = Math.Abs(change) < 1 ? 1 : change;
            return (int) Math.Round(gameFactor*(matchResult - bonusRating));
        }

        public void GetNewPlayerRating(Match match)
        {
            if (match.Result != 1 & match.Result != 0)
            {
                return;
            }
            match.PlayerOne.Rating = match.PlayerOne.Rating +
                                     ChangeInRating(match.PlayerOne.Rating, match.PlayerTwo.Rating, match.Result,
                                         match.GameFactor);
            match.PlayerTwo.Rating = match.PlayerTwo.Rating +
                                     ChangeInRating(match.PlayerTwo.Rating, match.PlayerOne.Rating, 1 - match.Result,
                                         match.GameFactor);
        }
    }
}
