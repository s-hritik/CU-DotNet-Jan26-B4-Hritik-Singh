using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using ApiService.DTOs;

namespace NorthwindCatalog.Web.Controllers;

public class CategoriesController : Controller
{
    private readonly HttpClient _client;

    public CategoriesController(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<IActionResult> Index()
    {
        var data = await _client.GetFromJsonAsync<List<CategoryDto>>("api/categories");
        return View(data);
    }
}