using AcademicPerformance.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicPerformance.Helpers
{
    public class DomainObjectsHelper
    {
        public static КодСпециальности GetКодСпециальности(string кодСпециальности)
        {
            switch (кодСпециальности)
            {
                case "КБ":
                    return КодСпециальности.КБ;
                case "ММ":
                    return КодСпециальности.ММ;
                case "МТТ":
                    return КодСпециальности.МТТ;
                case "ПМИ":
                    return КодСпециальности.ПМИ;

                default:
                    return КодСпециальности.ПМИ;
            }
        }
    }
}