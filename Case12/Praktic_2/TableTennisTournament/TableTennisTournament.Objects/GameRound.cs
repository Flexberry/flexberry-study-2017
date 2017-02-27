using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTennisTournament.Objects
{
    public class GameRound
    {
        public int RoundGoal { get; set; }
        public int ScorePlayerOne { get; set; }
        public int ScorePlayerTwo { get; set; }

        public int WinnerIsPlayer
        {
            get
            {


                if (this.ScorePlayerOne >= RoundGoal && this.ScorePlayerOne - 2 >= this.ScorePlayerTwo)
                {
                    this.ScorePlayerOne = RoundGoal + 1;
                    this.ScorePlayerTwo = RoundGoal - 1;
                    return 1;
                }

                if (this.ScorePlayerTwo >= RoundGoal && this.ScorePlayerTwo - 2 >= this.ScorePlayerOne)
                {
                    this.ScorePlayerOne = RoundGoal - 1;
                    this.ScorePlayerTwo = RoundGoal + 1;
                    return 0;
                }

                return -1;
            }
        }
    }
}
