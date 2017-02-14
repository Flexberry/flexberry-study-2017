using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSchool.Objects;

namespace Calculations
{
    public class Calculate
    {
        public static double Points(Training training)
        {
            double m1 = training.FirstZoneMinutes,
                   s1 = training.FirstZoneSeconds,
                   m2 = training.SecondZoneMinutes,
                   s2 = training.SecondZoneSeconds,
                   m3 = training.ThirdZoneMinutes,
                   s3 = training.ThirdZoneSeconds;

            if (m1 < 0 || s1 < 0 || m2 < 0 || s2 < 0 || m3 < 0 || s3 < 0)
            {
                throw new Exception("Число секунд или минут должно быть не отрицательным");
            }

            double points = (s1 / 60 + m1) / 60 * 40 + (s2 / 60 + m2) / 60 * 60 + (s3 / 60 + m3) / 60 * 80;
            return points;
        }
    }
}

