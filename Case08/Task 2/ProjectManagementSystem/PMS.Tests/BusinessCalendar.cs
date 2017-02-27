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

    public class BusinessCalendar
    {
        [Fact]
        public void CalculateDeadLineTest()
        {
            /*
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

            DeadLineCalculator deadLineCalculator = new DeadLineCalculator();

            //Act
            BusinessCalendarService wtb = new BusinessCalendarService();
            DateTime deadline1 = deadLineCalculator.CalculateDeadLine(allotedHours1, date1,wtb);
            DateTime deadline2 = deadLineCalculator.CalculateDeadLine(allotedHours2, date1,wtb);
            DateTime deadline3 = deadLineCalculator.CalculateDeadLine(allotedHours2, date3,wtb);
            DateTime deadline4 = deadLineCalculator.CalculateDeadLine(allotedHours3, date1,wtb);
            DateTime deadline5 = deadLineCalculator.CalculateDeadLine(allotedHours4, date1, wtb);
            DateTime deadline6 = deadLineCalculator.CalculateDeadLine(allotedHours5, date2, wtb);

            //Assert
            Assert.Equal(deadline1, (new DateTime(2017, 2, 7, 16, 30, 0)));
            Assert.Equal(deadline2, (new DateTime(2017, 2, 7, 10, 30, 0)));
            Assert.Equal(deadline3, (new DateTime(2017, 2, 10, 10, 30, 0)));
            Assert.Equal(deadline4, (new DateTime(2017, 2, 15, 16, 30, 0)));
            Assert.Equal(deadline5, (new DateTime(2017, 2, 9, 15, 30, 0)));
             */
        }
            
    }
    public class SumTimeCalculatorTest
    {
        [Fact]
        public void CalculateTimeTest()
        {
            /*
            //Arrange

            DateTime date1 = new DateTime(2017, 2, 6);
            DateTime date2 = new DateTime(2017, 2, 7);
            DateTime date3 = new DateTime(2017, 2, 8);
            DateTime date4 = new DateTime(2017, 2, 9);
            DateTime date5 = new DateTime(2017, 2, 10);

            //Act
            SumTimeCalculator sumTimeCalculator = new SumTimeCalculator();
            BusinessCalendarService businessCalendarService = new BusinessCalendarService();
            int sumTimeHours1 = sumTimeCalculator.CalculateTime(date1, date5, businessCalendarService);
            int sumTimeHours2 = sumTimeCalculator.CalculateTime(date1, date4, businessCalendarService);
            int sumTimeHours3 = sumTimeCalculator.CalculateTime(date2, date4, businessCalendarService);
            int sumTimeHours4 = sumTimeCalculator.CalculateTime(date2, date5, businessCalendarService);


            //Assert
            Assert.Equal(28, sumTimeHours1);
            Assert.Equal(21, sumTimeHours2);
            Assert.Equal(14, sumTimeHours3);
            Assert.Equal(21, sumTimeHours4);
             * */
        }
    }
}
