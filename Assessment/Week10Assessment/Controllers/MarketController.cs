using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;
using Microsoft.AspNetCore.Mvc;

namespace weeek10.Controllers;

public class Market : Controller
{
    public IActionResult Summary()
    {
        var now = DateTime.Now;
        bool isOpen = now.DayOfWeek != DayOfWeek.Saturday && now.DayOfWeek != DayOfWeek.Sunday && now.Hour > 9 && now.Hour < 16;

        ViewBag.MarketStatus = isOpen ? "open" : "Closed";
        ViewBag.StatusColor = isOpen ? "success" : "danger";

        ViewData["TopGainer"] = "TATAMOTORS (+4.2%)";
        ViewData["Volume"] = 1_482_300_000L;

        return View();
    }
    [HttpGet("Analyze/{ticker}/{days:int}")]
    public IActionResult Analyze(string ticker, int? days)
    {
        int analysisDays = days ?? 30;

        ViewBag.Ticker = ticker.ToUpper();
        ViewBag.Days = analysisDays;
        ViewBag.Message = $"Showing {analysisDays}-day analysis for {ticker.ToUpper()}";

        ViewBag.AveragePrice = new Random().Next(1000, 5000);
        ViewBag.Volatility = Math.Round(new Random().NextDouble() * 5, 2);

        return View();
    }
}
