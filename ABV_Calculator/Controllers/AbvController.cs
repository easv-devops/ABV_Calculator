using ABV_Calculator.Models;
using ABV_Calculator.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABV_Calculator.Controllers;

public class AbvController : Controller
{
    private readonly IAbvService _abvService;

    public AbvController(IAbvService abvService)
    {
        _abvService = abvService;
    }

    [HttpPost]
    public IActionResult CalculateAndSaveAbv(Calculation calculation)
    {
        if (calculation == null)
        {
            return BadRequest("Invalid calculation data.");
        }
        var result = _abvService.CalculateAndSaveAbv(calculation.OriginalGravity, calculation.FinalGravity);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Index()
    {
        // You can fetch and pass necessary data to the view if needed
        return View();
    
    }
}