using System;
using Microsoft.AspNetCore.Mvc;
using TravelFrontend.Services;

namespace TravelFrontend.Controllers;

public class DestinationsController : Controller
{
    private readonly ITravelApiService _service;

    public DestinationsController(ITravelApiService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var destinations = await _service.GetAllAsync();
        return View(destinations);
    }
}
