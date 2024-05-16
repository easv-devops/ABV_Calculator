
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using ABV_Calculator.Services;
using ABV_Calculator.Data;
using ABV_Calculator.Models;

namespace ABV_Calculator.Pages

{
    public class AbvCalculatorModel : PageModel
    {
        private readonly ILogger<AbvCalculatorModel> _logger;
        private readonly AbvCalculator _abvCalculator;
        private readonly ICalculationRepository _calculationRepository;

        public AbvCalculatorModel(ILogger<AbvCalculatorModel> logger, AbvCalculator abvCalculator, ICalculationRepository calculationRepository)
        {
            _logger = logger;
            _abvCalculator = abvCalculator;
            _calculationRepository = calculationRepository;
        }

        [BindProperty] public double OriginalGravity { get; set; }

        [BindProperty] public double FinalGravity { get; set; }

        [BindProperty] public double? Abv { get; private set; }

        public DateTime Date { get; private set; }

        public void OnPost()
        {
            try
            {
                if (OriginalGravity <= 0 || FinalGravity <= 0)
                {
                    ModelState.AddModelError(string.Empty, "Gravity values must be greater than zero.");
                    return;
                }

                Abv = _abvCalculator.CalculateAbv(OriginalGravity, FinalGravity);
                Date = DateTime.Now;
                Console.WriteLine("Original Gravity: " + OriginalGravity);
                Console.WriteLine("Final Gravity: " + FinalGravity);
                Console.WriteLine("ABV: " + Abv);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during ABV calculation.");
                ModelState.AddModelError(string.Empty, "An error occurred during ABV calculation.");
            }
        }
    }
}
