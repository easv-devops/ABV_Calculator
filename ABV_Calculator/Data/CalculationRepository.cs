namespace ABV_Calculator.Data;

using ABV_Calculator.Models;
using System.Collections.Generic;

  
    public class CalculationRepository : ICalculationRepository
    {
        private readonly List<Calculation>? _calculations;
        
        
        public void AddCalculation(Calculation calculation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Calculation> GetAllCalculations()
        {
            return _calculations;
        }
}