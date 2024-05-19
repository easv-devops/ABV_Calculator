
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using ABV_Calculator.Services;
using ABV_Calculator.Data;
using ABV_Calculator.Models;
using ABV_Calculator.Services.Services;

namespace ABV_Calculator.Pages

{
    public class AbvCalculatorModel : PageModel
    {
        private readonly ILogger<AbvCalculatorModel> _logger;
        private readonly IAbvService _abvService;
       // private readonly AbvCalculator _abvCalculator;
       // private readonly ICalculationRepository _calculationRepository;

        public AbvCalculatorModel(ILogger<AbvCalculatorModel> logger, IAbvService abvService)
        {
            _logger = logger;
            _abvService = abvService;
        }

        [BindProperty] public double OriginalGravity { get; set; }

        [BindProperty] public double FinalGravity { get; set; }

        [BindProperty] public double? Abv { get; private set; }

        public DateTime DateTime { get; private set; }

        public void OnPost()
        {
            _logger.LogInformation("OnPost method called.");
            try
            {
                if (OriginalGravity <= 0 || FinalGravity <= 0)
                {
                    ModelState.AddModelError(string.Empty, "Gravity values must be greater than zero.");
                    return;
                }

                var result = _abvService.CalculateAndSaveAbv(OriginalGravity, FinalGravity);
                Abv = result.Abv;
                DateTime = result.date_time;
                
                _logger.LogInformation("Original Gravity = {OriginalGravity}", OriginalGravity);
                _logger.LogInformation("ABV = {ABV}", Abv);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during ABV calculation.");
                ModelState.AddModelError(string.Empty, "An error occurred during ABV calculation.");
            }
            _logger.LogInformation("OnPost method finished.");

        }
    }
}
