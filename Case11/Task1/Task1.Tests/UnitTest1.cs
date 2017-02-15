using System;
using System.Collections.Generic;
using Xunit;
using Task1.Objects;
using CostCalculator;

namespace Task1.Tests
{
    
    public class UnitTest1
    {
        private List<Group> groups = new List<Group>()
            {
                new Group(GroupName.Group1, 1000),
                new Group(GroupName.Group2, 2000),
                new Group(GroupName.Group3, 3000),
                new Group(GroupName.Group4, 4000)
            };
        [Fact]
        public void TestCostCalc()
        {
            Student student = new Student()
            {
                Name = "Student1",
                group = groups[0],
                privelege = true,
                campus = false
            };

            double campus_cost = 500;

            double expectedCost = student.group.cost / 2;

            double result = CostCalc.Calc(student, campus_cost);

            Assert.Equal(expectedCost, campus_cost); 
        }

        [Fact]
        public void TestException()
        {
            Student student = new Student()
            {
                Name = "Student1",
                group = null,
                privelege = true,
                campus = false
            };
            double campus_cost = 500;
            var ex = Assert.Throws<ArgumentNullException>(() => CostCalc.Calc(student, campus_cost));

            Assert.Contains("У студента не указано полное ФИО", ex.Message);
        }
    }
}
