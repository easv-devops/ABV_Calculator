using ABV_Calculator.Data;
using ABV_Calculator.Models;
using ABV_Calculator.Pages;
using ABV_Calculator.Services.Services;

namespace ABV_Calculator.Services;

public class AbvService : IAbvService
{
    private readonly AbvCalculator _abvCalculator;
    private readonly ICalculationRepository _calculationRepository;

    public AbvService(AbvCalculator abvCalculator, ICalculationRepository calculationRepository)
    {
        _abvCalculator = abvCalculator;
        _calculationRepository = calculationRepository;
    }

    public Calculation CalculateAndSaveAbv(double originalGravity, double finalGravity)
    {
        var abv = _abvCalculator.CalculateAbv(originalGravity, finalGravity);
        var calculation = new Calculation
        {
            OriginalGravity = originalGravity,
            FinalGravity = finalGravity,
            Abv = abv,
            date_time = DateTime.UtcNow
        };
        _calculationRepository.AddCalculation(calculation);
        return calculation;
    }
}