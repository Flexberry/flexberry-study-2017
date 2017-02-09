using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeLibraryTest
{
    using Xunit;
    using ManagementSystemObjects;

    public class DayTest
    {
        [Fact]
        public void TestDayWorkTime()
        {
            //Arrange
            WorkTimeSpan wts1 = new WorkTimeSpan(8, 30, 12, 30);
            WorkTimeSpan wts2 = new WorkTimeSpan(13, 30, 16, 30);
            WorkTimeSpan wts3 = new WorkTimeSpan(10, 30, 12, 30);
            WorkTimeSpan wts4 = new WorkTimeSpan(13, 30, 15, 30);
            WorkTimeSpan wts5 = new WorkTimeSpan(8, 30, 12, 30);
            WorkTimeSpan wts6 = new WorkTimeSpan(13, 30, 16, 30);

            Day workDay0 = new Day(new DateTime(2017, 2, 6), "Стандартный рабочий день");
            workDay0.AddWorkTimeSpan(wts5);
            workDay0.AddWorkTimeSpan(wts6);

            Day workDay = new Day(new DateTime(2017, 2, 6), "Стандартный рабочий день");
            workDay.AddWorkTimeSpan(wts1);
            workDay.AddWorkTimeSpan(wts2);
            Day workDay1 = new Day(new DateTime(2017, 2, 7), "Сокращенный рабочий день");
            workDay1.AddWorkTimeSpan(wts3);
            workDay1.AddWorkTimeSpan(wts4);

            //Act
            TimeSpan ts1 = new TimeSpan(7, 0, 0);
            TimeSpan ts2 = new TimeSpan(4, 0, 0);

            //Assert
            Assert.Equal(ts1, workDay.WorkTime);
            Assert.Equal(ts2, workDay1.WorkTime);
            Assert.Equal(ts1, workDay0.WorkTime);
        }
    }
}
