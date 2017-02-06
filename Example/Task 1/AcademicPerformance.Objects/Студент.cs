namespace AcademicPerformance.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Студент
    {
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string НомерГруппы { get; set; }
        public DateTime ДатаРождения { get; set; }
        public КодСпециальности КодСпециальности { get; set; }
    }
}
