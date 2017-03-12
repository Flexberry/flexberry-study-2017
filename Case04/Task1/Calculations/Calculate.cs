using System;
using System.Collections.Generic;
using SportSchool.Objects;

namespace Calculations
{
    public class Calculate
    {
        public static double TrainingLoad(Training training)
        {
            int points = 0;
            double load = 0;
            foreach (KeyValuePair<int, TimeSpan> item in training.TimeInZones)
            {
                if (item.Key < 8)
                {
                    points = 10 + (10 * item.Key);
                } else
                {
                    points = (item.Key * 10) + (item.Key - 6) * 10;
                }

                load += (item.Value.Hours + item.Value.Minutes / 60 + item.Value.Seconds / 3600) * points;
            }
            return load;
        }
    }
}

