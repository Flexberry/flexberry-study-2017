using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTennisTournament.Objects
{
    public class Player
    {
        private int rating;
        public Guid PlayerGuid { get; set; }
        public string firstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string FullName => string.Concat(LastName, " ", firstName[0], ". ", MiddleName[0], ".");
        public string Login { get; set; }

        public int Rating
        {
            get
            {
               return this.rating;
            }
            set {
                this.rating = value < 0 ? 0 : value;
            }
        }

    }
}
