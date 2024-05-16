namespace ABV_Calculator.Services;

public class AbvCalculator
{
   
    //private double ABV;
  
    
    public double CalculateAbv(double originalGravity, double finalGravity)
    {
        // Check if originalGravity and finalGravity are valid doubles
        if (double.IsNaN(originalGravity) || double.IsNaN(finalGravity))
        {
            throw new ArgumentException("Invalid input. Please enter a number greater than zero and less than 100.");
        }

        // Check if originalGravity and finalGravity are within valid ranges
        if (originalGravity <= 0 || finalGravity <= 0 || originalGravity > 100 || finalGravity > 100)
        {
            throw new ArgumentException("Invalid input. Please enter a number greater than zero and less than 100.");
        }

        // Calculate ABV
        double abv = (originalGravity - finalGravity) * 131.25;

        // Check if ABV is within a reasonable range (optional)
        if (abv < 0 || abv > 100)
        {
            throw new ArgumentOutOfRangeException("ABV calculation resulted in an invalid value.");
        }

        Console.WriteLine("CalculateABV method:  ABV: " + abv);
        Console.WriteLine("Original Gravity: " + originalGravity);
        Console.WriteLine("Final Gravity: " + finalGravity);
        return abv;
    
    }
}