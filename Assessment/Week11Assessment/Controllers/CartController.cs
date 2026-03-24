using Microsoft.AspNetCore.Mvc;
using Day63.Assignment2.Services;

namespace Day63.Assignment2.Controllers;

public class CartController : Controller
{
    private readonly IPricingService _pricingService;

    public CartController(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }

    public IActionResult Checkout()
    {

        decimal cartTotal = 150.00m;
        string userCode = "FREESHIP";

        var finalTotal = _pricingService.CalculateDiscountedPrice(cartTotal, userCode);
        
        ViewBag.FinalTotal = finalTotal;
        ViewBag.AppliedCode = userCode;
        
        return View();
    }
}