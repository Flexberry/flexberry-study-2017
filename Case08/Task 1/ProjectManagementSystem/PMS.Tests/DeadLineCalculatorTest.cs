using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Tests
{
    using Xunit;
    using PMS.DAL;
    using WorkTimeLibrary;

    public class DeadLineCalculatorTest
    {
        [Fact]
        public void CalculateDeadLineTest()
        {
            //Arrange
            DateTime date1 = new DateTime(2017, 2, 6);
            DateTime date2 = new DateTime(2017, 2, 7);
            DateTime date3 = new DateTime(2017, 2, 8);
            DateTime date4 = new DateTime(2017, 2, 9);
            DateTime date5 = new DateTime(2017, 2, 10);

            int allotedHours1 = 14;
            int allotedHours2 = 9;
            int allotedHours3 = 35;
            int allotedHours4 = 20;
            int allotedHours5 = 16;
            DateTime startDate = new DateTime(2017, 2, 6);

            BusinessCalendarService businessCalendarService = new BusinessCalendarService();
            BusinessCalendar businessCalendar = new BusinessCalendar(businessCalendarService);

            //Act
            
            DateTime deadline1 = businessCalendar.CalculateDeadLine(allotedHours1, date1);
            DateTime deadline2 = businessCalendar.CalculateDeadLine(allotedHours2, date1);
            DateTime deadline3 = businessCalendar.CalculateDeadLine(allotedHours2, date3);
            DateTime deadline4 = businessCalendar.CalculateDeadLine(allotedHours3, date1);
            DateTime deadline5 = businessCalendar.CalculateDeadLine(allotedHours4, date1);
            DateTime deadline6 = businessCalendar.CalculateDeadLine(allotedHours5, date2);

            //Assert
            Assert.Equal(deadline1, (new DateTime(2017, 2, 7, 16, 30, 0)));
            Assert.Equal(deadline2, (new DateTime(2017, 2, 7, 10, 30, 0)));
            Assert.Equal(deadline3, (new DateTime(2017, 2, 10, 10, 30, 0)));
            Assert.Equal(deadline4, (new DateTime(2017, 2, 15, 16, 30, 0)));
            Assert.Equal(deadline5, (new DateTime(2017, 2, 9, 15, 30, 0)));
        }

    }
}
