namespace ABV_Calculator.Data;

using ABV_Calculator.Models;
using System.Collections.Generic;

  
    public class CalculationRepository : ICalculationRepository
    {
        private readonly List<Calculation>? _calculations;
        private readonly CalculatorDbContext _dbContext;
        
        public CalculationRepository(CalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCalculation(Calculation calculation)
        {
            _dbContext.Calculations.Add(calculation);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Calculation> GetAllCalculations()
        {
            return _dbContext.Calculations ?? Enumerable.Empty<Calculation>();

        }
}