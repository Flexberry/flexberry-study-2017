using System;
using System.Collections.Generic;

namespace SportSchool.Objects
{
    public class Training
    {
        public Sportsman sportsman { get; set; }
        public Dictionary<int, TimeSpan> TimeInZones { get; set; }
    }
}
