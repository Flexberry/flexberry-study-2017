using System;
using System.Collections.Generic;
using CostCalculator;
using Task1.Objects;
using Xunit;

namespace Task1.Tests
{

    public class CalcTest 
    {
        double campus_cost = 50;
        List<Group> groups = new List<Group>()
        {
            new Group(GroupName.Group1, 1000),
            new Group(GroupName.Group2, 2000),
            new Group(GroupName.Group3, 3000),
            new Group(GroupName.Group4, 4000)
        };

        [Fact]
        public void CostCalcTest()
        {
            ///Arrange.
            Student student = new Student()
            {
                Name = "Student1",
                privelege = true,
                campus = true,
                group = groups[0]             
            };
            
            double expectedCost = (1000 + 12 * campus_cost) / 2;
            ///Act.
            double cost = CostCalc.Calc(student, campus_cost);
            ///Assert.
            Assert.Equal(expectedCost, cost);   
        }

        [Fact]
        public void CostCalcNullTest()
        {
            ///Arrange.
            Student student = new Student()
            {
                Name = "Student1",
                privelege = true,
                campus = true,
                group = null
            };
            ///Act.
            Exception ex = Assert.Throws<ArgumentNullException>(() => CostCalc.Calc(student, campus_cost));
            ///Assert.
            Assert.Contains("Неверная информация о студенте", ex.Message);


        }
    }
}
