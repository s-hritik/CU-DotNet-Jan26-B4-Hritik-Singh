using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using weeek10.Models;

namespace weeek10.Controllers;

public class PortfolioController : Controller
{
    private static List<Asset> _asset = new()
    {
        new Asset { Id=1, Symbol="RELIANCE", Name="Reliance Industries",
                    PurchasedPrice=2400, CurrentPrice=2650, Quantity=10 },
        new Asset { Id=2, Symbol="TCS",      Name="Tata Consultancy",
                    PurchasedPrice=3500, CurrentPrice=3820, Quantity=5  },
        new Asset { Id=3, Symbol="INFY",     Name="Infosys Ltd",
                    PurchasedPrice=1450, CurrentPrice=1380, Quantity=20 },
    };

    private static int _nextId = 4;
    public IActionResult Index()
    {
        var total = _asset.Sum(i => i.TotalPrice);
        ViewData["TotalPrice"] = total;
        return View(_asset);
    }

    [Route("Asset/Info/{id:int}")]
    public IActionResult Details(int id)
    {
        var asset = _asset.FirstOrDefault(i => i.Id == id);
        if (asset == null) return NotFound();
        return View(asset);
    }

    public IActionResult Create()
    {
        return View(new Asset());
    }
    [HttpPost]
    public IActionResult Create(Asset asset)
    {
        if (!ModelState.IsValid) return View(asset);

        asset.Id = _nextId++;
        _asset.Add(asset);

        TempData["Message"] = $"Asset '{asset.Symbol}' added to portfolio.";

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var asset = _asset.FirstOrDefault(i => i.Id == id);
        if (asset == null) return NotFound();

        _asset.Remove(asset);
        TempData["Message"] = $"Asset '{asset.Symbol}' removed from portfolio.";

        return RedirectToAction("Index");
    }
}
