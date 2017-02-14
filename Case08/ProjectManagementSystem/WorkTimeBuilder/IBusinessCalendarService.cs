using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemObjects;

namespace WorkTimeLibrary
{
    public interface IBusinessCalendarService
    {
        List<Day> GetDaysCollection(DateTime dateStart,DateTime dateFinish);
    }
}
