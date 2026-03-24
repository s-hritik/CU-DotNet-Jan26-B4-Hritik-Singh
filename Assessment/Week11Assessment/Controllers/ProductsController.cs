using Microsoft.AspNetCore.Mvc;
using Day63.Assignment2.Services;

namespace Day63.Assignment2.Controllers;
public class ProductsController : Controller
{
    private readonly IPricingService _pricingService;

    public ProductsController(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }

    public IActionResult Index()
    {
        decimal basePrice = 100.00m;
        var discountedPrice = _pricingService.CalculateDiscountedPrice(basePrice, "WINTER25");

        ViewBag.Message = $"The discounted price is: {discountedPrice}";
        
        return View();
    }
}