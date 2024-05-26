using ABV_Calculator.Pages;
using ABV_Calculator.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Tests.Unit;

[TestFixture]
    public class AbvCalculatorTests
    {
    
        private AbvCalculator? _abvCalculator;
        private Mock<ILogger<AbvCalculatorModel>>? _loggerMock;

        //private ILogger logger;
        //private AbvCalculatorModel abvCalculatorModel;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<AbvCalculatorModel>>();
            _abvCalculator = new AbvCalculator(_loggerMock.Object);
            //  _abvCalculator = new AbvCalculator(logger);
        }

        [Test]
        public void CalculateAbv_ValidInput_ReturnsCorrectValue()
        {
            // Arrange
            double originalGravity = 1.050;
            double finalGravity = 1.010;
            double expectedAbv = 4.0;

            // Act
            if (_abvCalculator != null)
            {
                double abv = _abvCalculator.CalculateAbv(originalGravity, finalGravity);

                // Assert
                Assert.That(expectedAbv, Is.EqualTo(abv)); // Assuming the expected ABV is 4.0%
            }
        }

        [Test]
        public void CalculateAbv_InvalidInput_ThrowsArgumentException()
        {
            // Arrange
            double originalGravity = -1.0;
            double finalGravity = 1.010;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                if (_abvCalculator != null) _abvCalculator.CalculateAbv(originalGravity, finalGravity);
            });
        }
        
    }
