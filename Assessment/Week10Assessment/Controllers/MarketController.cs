using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers;
public class MarketController : Controller {
    
    public IActionResult Summary() {
        ViewBag.MarketStatus = "Open"; 
        ViewData["TopGainer"] = "NVDA"; 
        ViewData["Volume"] = 150000000L; 
        return View(); 
    }

    [HttpGet("Analyze/{ticker}/{days:int?}")] 
    public IActionResult Analyze(string ticker, int? days) {
        ViewBag.Ticker = ticker;
        ViewBag.Days = days ?? 30; 
        return View();
    }
}