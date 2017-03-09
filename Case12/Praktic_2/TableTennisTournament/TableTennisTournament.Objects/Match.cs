using System;
using System.Collections.Generic;
using System.Linq;

namespace TableTennisTournament.Objects
{
    public class Match
    {
        public List<GameRound> RoundsList = new List<GameRound>();
        public Guid MatchGuid
        { get; set; }
        public int GameFactor { get; set; }
        public DateTime PlayDateTime { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }

        public int Result { get; set;}

        public bool IsRegistred { get; set; }

    }
}
