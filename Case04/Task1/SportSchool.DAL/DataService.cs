using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSchool.Objects;
using Calculations;

namespace SportSchool.DAL
{

    public static class DataService
    {
        private static List<Sportsman> sportsmen = new List<Sportsman>();

        private static List<Training> trainings = new List<Training>();

        public static void AddSportsman(Sportsman sportsman)
        {
            sportsmen.Add(sportsman);
        }

        public static void ClearSportsmen()
        {
            sportsmen.Clear();
        }

        public static void DeleteSportsman(Sportsman sportsman)
        {
            Sportsman deleted = null;
            foreach (Sportsman current in sportsmen)
                if (current.LastName == sportsman.LastName && current.FirstName == sportsman.FirstName && current.Patronymic == sportsman.Patronymic && current.CodeGroup == sportsman.CodeGroup)
                    deleted = current;
            sportsmen.Remove(deleted);
        }

        public static List<Sportsman> GetSportsmen(string lastName, string firstName, string patronymic, string codeGroup)
        {
            List<Sportsman> result = new List<Sportsman>();
            //Проверяем по имени
            if (!String.IsNullOrEmpty(firstName))
            {
                foreach (Sportsman sportsman in sportsmen)
                {
                    if (sportsman.FirstName == firstName)
                    {
                        result.Add(sportsman);
                    }
                }
                if (result.Count == 0) return result;
            }
            //Проверяем по фамилии  
            if (!String.IsNullOrWhiteSpace(lastName))
            {
                if (result.Count > 0)
                {
                    foreach (Sportsman sportsman in result)
                    {
                        if (sportsman.LastName != lastName)
                        {
                            result.Remove(sportsman);
                        }
                    }
                } else
                {
                    foreach (Sportsman sportsman in sportsmen)
                    {
                        if (sportsman.LastName == lastName)
                        {
                            result.Add(sportsman);
                        }
                    }
                }
                if (result.Count == 0) return result;
            }
            //Проверяем по отчеству
            if (!String.IsNullOrWhiteSpace(patronymic))
            {
                if (result.Count > 0)
                {
                    foreach (Sportsman sportsman in result)
                    {
                        if (sportsman.Patronymic != patronymic)
                        {
                            result.Remove(sportsman);
                        }
                    }
                }
                else
                {
                    foreach (Sportsman sportsman in sportsmen)
                    {
                        if (sportsman.Patronymic == patronymic)
                        {
                            result.Add(sportsman);
                        }
                    }
                }
                if (result.Count == 0) return result;
            }
            //Проверяем по коду группы
            if (!String.IsNullOrWhiteSpace(codeGroup))
            {
                if (result.Count > 0)
                {
                    foreach (Sportsman sportsman in result)
                    {
                        if (sportsman.CodeGroup != codeGroup)
                        {
                            result.Remove(sportsman);
                        }
                    }
                }
                else
                {
                    foreach (Sportsman sportsman in sportsmen)
                    {
                        if (sportsman.CodeGroup == codeGroup)
                        {
                            result.Add(sportsman);
                        }
                    }
                }
                if (result.Count == 0) return result;
            }
            return result;
        }

        public static List<Sportsman> GetAllSportsmen()
        {
            return sportsmen;
        }

        public static double CalculatePoints(Training training)
        {
            return Calculate.Points(training);
        }
        
    }

}
