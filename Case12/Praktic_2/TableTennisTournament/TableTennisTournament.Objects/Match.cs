using System;

namespace TableTennisTournament.Objects
{
    public class Match
    {
        
        public Guid MatchGuid
        { get; set; }
        public int GameFactor { get; set; }
        public DateTime PlayDateTime { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public int ScorePlayerOne { get; set; }
        public int ScorePlayerTwo { get; set; }
        public double Result { get; set; }
        public bool IsRegistred { get; set; }
    }
}
