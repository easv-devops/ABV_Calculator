using ABV_Calculator.Data;
using ABV_Calculator.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Moq.EntityFrameworkCore;

namespace ABV_Calculator.Data
{
    [TestFixture]
    public class CalculationRepositoryTests
    {
        [Test]
        public void AddCalculation_ShouldAddToDatabase()
        {
            // Arrange
            var dbContextMock = new Mock<CalculatorDbContext>();
            var repository = new CalculationRepository(dbContextMock.Object);

            var calculation = new Calculation {  Id = 1, OriginalGravity = 1.050, FinalGravity = 1.010, Abv = 5.5, date_time = DateTime.Now };
            
            // Act
            repository.AddCalculation(calculation);

            // Assert
            dbContextMock.Verify(db => db.Calculations.Add(calculation), Times.Once);
            dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetAllCalculations_ShouldReturnAllCalculations()
        {
            // Arrange
            var calculations = new List<Calculation>
            {
                new Calculation { Id = 1, OriginalGravity = 1.050, FinalGravity = 1.010, Abv = 5.5, date_time = DateTime.Now },
                new Calculation { Id = 2, OriginalGravity = 1.060, FinalGravity = 1.015, Abv = 6.0, date_time = DateTime.Now }
            };

            var dbContextMock = new Mock<CalculatorDbContext>();
            dbContextMock.Setup(db => db.Calculations).ReturnsDbSet(calculations);

            var repository = new CalculationRepository(dbContextMock.Object);

            // Act
            var result = repository.GetAllCalculations();

            // Assert
            Assert.That(calculations.Count, Is.EqualTo(result.Count()));
        }
    }
}