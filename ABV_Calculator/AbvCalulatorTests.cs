using ABV_Calculator.Pages;
using ABV_Calculator.Services;
using NUnit.Framework;

namespace ABV_Calculator;

[TestFixture]
public class AbvCalulatorTests
{
    
    private AbvCalculator _abvCalculator;
    private ILogger<AbvCalculatorModel> logger;
    private AbvCalculatorModel abvCalculatorModel;

    [SetUp]
    public void Setup()
    {
        _abvCalculator = new AbvCalculator( logger);
    }

    [Test]
    public void CalculateAbv_ValidInput_ReturnsCorrectValue()
    {
        // Arrange
        double originalGravity = 1.050;
        double finalGravity = 1.010;
        double expectedAbv = 4.0;

        // Act
        double abv = _abvCalculator.CalculateAbv(originalGravity, finalGravity);

        // Assert
        Assert.That(expectedAbv, Is.EqualTo(abv)); // Assuming the expected ABV is 4.0%

    }

    [Test]
    public void CalculateAbv_InvalidInput_ThrowsArgumentException()
    {
        // Arrange
        double originalGravity = -1.0;
        double finalGravity = 1.010;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _abvCalculator.CalculateAbv(originalGravity, finalGravity));
    }
}