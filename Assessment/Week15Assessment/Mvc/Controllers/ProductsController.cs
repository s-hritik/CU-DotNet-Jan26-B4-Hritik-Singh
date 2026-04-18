using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using ApiService.DTOs;

namespace NorthwindCatalog.Web.Controllers;

public class ProductsController : Controller
{
    private readonly HttpClient _client;

    public ProductsController(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<IActionResult> ByCategory(int id)
    {
        var response = await _client.GetAsync($"api/products/by-category/{id}");

        if (response.IsSuccessStatusCode)
        {
            var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
            return View(products);
        }
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return View(new List<ProductDto>());
        }

        return View(new List<ProductDto>());
    }
}