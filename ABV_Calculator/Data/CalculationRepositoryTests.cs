using ABV_Calculator.Data;
using ABV_Calculator.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ABV_Calculator.Data
{
    [TestFixture]
    public class CalculationRepositoryTests
    {
        [Test]
        public void AddCalculation_ValidCalculation_AddsToDatabase()
        {
            // Arrange
            var mockDbContext = new Mock<CalculatorDbContext>();
            var repository = new CalculationRepository(mockDbContext.Object);
            var calculation = new Calculation
            {
                OriginalGravity = 1.050,
                FinalGravity = 1.010,
                Abv = 5.5,
                date_time = DateTime.Now
            };

            // Act
            repository.AddCalculation(calculation);

            // Assert
            mockDbContext.Verify(db => db.Calculations.Add(It.IsAny<Calculation>()), Times.Once);
            mockDbContext.Verify(db => db.SaveChanges(), Times.Once);
        }

        [Test]
        public void GetAllCalculations_ReturnsAllCalculationsFromDatabase()
        {
            // Arrange
            var calculations = new List<Calculation>
            {
                new Calculation { Id = 1, OriginalGravity = 1.050, FinalGravity = 1.010, Abv = 5.5, date_time = DateTime.Now },
                new Calculation { Id = 2, OriginalGravity = 1.060, FinalGravity = 1.015, Abv = 6.0, date_time = DateTime.Now }
            };
            var mockDbContext = new Mock<CalculatorDbContext>();
            mockDbContext.Setup(db => db.Calculations).Returns((DbSet<Calculation>)calculations.AsQueryable());
            var repository = new CalculationRepository(mockDbContext.Object);

            // Act
            var result = repository.GetAllCalculations();

            // Assert
            Assert.That(calculations.Count, Is.EqualTo (result.Count()));
            Assert.That(result.All(c => calculations.Any(cc => cc.Id == c.Id && cc.OriginalGravity == c.OriginalGravity && cc.FinalGravity == c.FinalGravity && cc.Abv == c.Abv)));
        }
    }
}
