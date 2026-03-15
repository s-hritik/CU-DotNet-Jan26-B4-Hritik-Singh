using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Week10Assessment.Models;

namespace Week10Assessment.Controllers;
public class PortfolioController : Controller {
    private static List<Asset> _assets = new List<Asset> {
        new Asset { Id = 1, Ticker = "AAPL", Value = 150.00 },
        new Asset { Id = 2, Ticker = "GOOGL", Value = 2800.00 }
    };

    public IActionResult Index() {
        ViewData["Total"] = _assets.Sum(a => a.Value); 
        return View(_assets);
    }

    [Route("Asset/Info/{id:int}")]
    public IActionResult Details(int id) {
        var asset = _assets.FirstOrDefault(a => a.Id == id);
        if (asset == null) return NotFound();
        return View(asset);
    }

     public IActionResult Delete(int id)
    {
        var asset = _assets.FirstOrDefault(a => a.Id == id);
        if (asset != null)
        {
            _assets.Remove(asset);
            TempData["Message"] = "Success: Asset deleted.";
        }
        return RedirectToAction(nameof(Index));
    }
}

