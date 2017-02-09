using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WorkTimeLibrary;
using ManagementSystemObjects;

namespace WorkTimeLibraryTest
{
    public class WorkTimeBuilderTest
    {
        
        [Fact]
        public void GetDaysCollectionTest()
        {
            //Arrange

            DateTime date1 = new DateTime(2017, 2, 6);
            DateTime date2 = new DateTime(2017, 2, 7);
            DateTime date3 = new DateTime(2017, 2, 8);
            DateTime date4 = new DateTime(2017, 2, 9);
            DateTime date5 = new DateTime(2017, 2, 10);

            //Act
            WorkTimeBuilder workTimeBuilder = new WorkTimeBuilder();
            List<Day> days1 = workTimeBuilder.GetDaysCollection(date1, date5);
            List<Day> days2 = workTimeBuilder.GetDaysCollection(date1, date4);
            List<Day> days3 = workTimeBuilder.GetDaysCollection(date2, date4);
            List<Day> days4 = workTimeBuilder.GetDaysCollection(date3, date5);

            int daysCount1 = days1.Count;
            int daysCount2 = days2.Count;
            int daysCount3 = days3.Count;
            int daysCount4 = days4.Count;

            //Assert
            Assert.Equal(5, daysCount1);
            Assert.Equal(4, daysCount2);
            Assert.Equal(3, daysCount3);
            Assert.Equal(3, daysCount4);
        }

        [Fact]
        public void BuildAllCollectionTest()
        {
            //Arrange

            //Act
            WorkTimeBuilder workTimeBuilder = new WorkTimeBuilder();
            List<Day> dayList;
            dayList = workTimeBuilder.BuildAllCollection();
            //Assert
            Assert.Equal(5, dayList.Count);
        }

    }
}
