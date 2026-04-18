using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using ApiService.DTOs;

namespace NorthwindCatalog.Web.Controllers;

public class SummaryController : Controller
{
    private readonly HttpClient _client;

    public SummaryController(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<IActionResult> Index()
    {
        var summary = await _client.GetFromJsonAsync<List<CategorySummaryDto>>("api/products/summary");
        return View(summary);
    }
}