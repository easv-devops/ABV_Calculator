namespace ABV_Calculator.Services.Services;

using ABV_Calculator.Models;

public interface IAbvService
{
    Calculation CalculateAndSaveAbv(double originalGravity, double finalGravity);

}