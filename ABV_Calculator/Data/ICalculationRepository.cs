using ABV_Calculator.Models;

namespace ABV_Calculator.Data;
using System;
using System.Collections.Generic;



    public interface ICalculationRepository
    {
        void AddCalculation(Calculation calculation);
        IEnumerable<Calculation> GetAllCalculations();
    
}