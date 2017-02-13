using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculations;
using SportSchool.Objects;

namespace SportSchool.Tests
{
    [TestClass]
    public class CalculationTest
    {
        [TestMethod]
        public void CalculatePointsTest()
        {
            // arrange
            var training = new Training()
            {
                FirstZoneMinutes = 10,
                FirstZoneSeconds = 5,
                SecondZoneMinutes = 3,
                SecondZoneSeconds = 2,
                ThirdZoneMinutes = 4,
                ThirdZoneSeconds = 6
            };
            // act
            double result = Calculate.Points(training);
            // assert double result = 15.22
            Assert.AreEqual(result, 15.22, 0.01, "Вычисление очков не верно");
        }

        [TestMethod]
        public void ExeptionTest()
        {
            // arrange
            var training = new Training()
            {
                FirstZoneMinutes = -10,
                FirstZoneSeconds = -5,
                SecondZoneMinutes = 3,
                SecondZoneSeconds = 2,
                ThirdZoneMinutes = 4,
                ThirdZoneSeconds = 6
            };
            // act
            try
            {
                var ex = Calculate.Points(training);
            }
            catch (Exception ex)
            {
            // assert
                Assert.AreEqual("Число секунд или минут должно быть не отрицательным", ex.Message);
            }
        }
    }
}