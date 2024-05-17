using ABV_Calculator.Pages;

namespace ABV_Calculator.Services;

public class AbvCalculator
{

    private readonly ILogger _logger;

    public AbvCalculator(ILogger<AbvCalculatorModel> logger)
    {
        _logger = logger;
    }
    
    public double CalculateAbv(double OriginalGravity, double FinalGravity)
    {
        // Check if originalGravity and finalGravity are valid doubles
        if (double.IsNaN(OriginalGravity) || double.IsNaN(FinalGravity))
        {
            throw new ArgumentException("Invalid input. Please enter a number greater than zero and less than 100.");
        }

        // Check if originalGravity and finalGravity are within valid ranges
        if (OriginalGravity <= 0 || FinalGravity <= 0 || OriginalGravity > 100 || FinalGravity > 100)
        {
            _logger.LogError("Invalid input. Please enter a number greater than zero and less than 100.");
            throw new ArgumentException("Invalid input. Please enter a number greater than zero and less than 100.");
        }

        // Calculate ABV
        double abv = (OriginalGravity - FinalGravity) * 131.25;
        _logger.LogInformation("Original Gravity = {OriginalGravity}", OriginalGravity);
        _logger.LogInformation("Final Gravity = {FinalGravity}", FinalGravity);
        _logger.LogInformation("ABV = {ABV},", abv);

        // Check if ABV is within a reasonable range (optional)
        if (abv < 0 || abv > 200)
        {
            _logger.LogError("ABV calculation resulted in an invalid value.");
            throw new ArgumentOutOfRangeException("ABV calculation resulted in an invalid value.");
        }
        
        return abv;
    
    }
}