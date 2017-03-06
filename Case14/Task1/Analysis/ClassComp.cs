namespace Analysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClassComp
    {
        public double Comparison(string[] lost, string[] found)
        {
            if (lost == null)
            {
                throw new ArgumentNullException(nameof(lost));
            }

            if (found == null)
            {
                throw new ArgumentNullException(nameof(found));
            }

            double overlap = 0;
            double pct = 0;
            int lenghtLost = lost.Length;
            int lenghtFound = found.Length;
            int lenghtArray = lenghtLost;   

            if (lenghtLost == lenghtFound)
            {
                for (int i = 0; i < lenghtArray; i++)
                {
                    for (int j = 0; j < lenghtArray; j++)
                    {
                        var lostElem = lost[i];
                        var foundElem = found[j];

                        if (lostElem == foundElem & lostElem != null & foundElem != null)
                        {
                            overlap = overlap + 1;
                        }
                        else overlap = overlap + 0;
                    }
                }
                pct = (overlap * 100 / lenghtArray);
                return pct;
            }
            else throw new Exception("Array\'s not equal");
        }
    }
}