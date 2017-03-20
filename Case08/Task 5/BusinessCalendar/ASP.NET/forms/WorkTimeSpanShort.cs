using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIS.BusinessCalendar.forms
{
    public class WorkTimeSpanShort
    {
        public Guid PrimaryKey { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
    }
}