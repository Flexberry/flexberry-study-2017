using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RatingPosition
{
   public interface IRating
   {
       int ChangeInRating(int currentRating, int enemyRating, int matchResult, int gameFactor);
   }
}
