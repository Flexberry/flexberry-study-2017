using Task1.Objects;
using System;

namespace CostCalculator
{
    public static class CostCalc
    {
        public static double Calc(Student student, double campus_cost)
        {
            double cost = -1;
            if (student != null & student.group != null)
            {
                cost = student.group.cost;
                if (student.campus)
                    cost += 12 * campus_cost;
                if (student.privelege)
                    cost /= 2;
                return cost;
            }
            throw new ArgumentNullException(nameof(student), "Неверная информация о студенте");
        }
    }
}
