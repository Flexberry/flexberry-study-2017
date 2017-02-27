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
        private int _rating;
        public Guid PlayerGuid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Login { get; set; }

        public int Rating
        {
            get
            {
               return _rating;
            }
            set {
                _rating = value < 0 ? 0 : value;
            }
        }

    }
}
