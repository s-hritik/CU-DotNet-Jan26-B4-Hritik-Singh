using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiService.DTOs;
using ApiService.Repositories;

namespace ApiService.Controllers;

[ApiController]
[Route("api/products")]
[Produces("application/json")]
public class ProductsApiController : ControllerBase
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public ProductsApiController(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var products = await _repo.GetByCategoryIdAsync(categoryId);

        if (!products.Any())
            return NotFound(new { message = $"No products found for category ID {categoryId}." });

        return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        var data = await _repo.GetCategorySummariesAsync();
        return Ok(data);
    }
}
