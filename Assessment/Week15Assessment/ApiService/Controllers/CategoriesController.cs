using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ApiService.DTOs;
using ApiService.Repositories;

namespace ApiService.Controllers;

[ApiController]
[Route("api/categories")]
[Produces("application/json")]
public class CategoriesApiController : ControllerBase
{
    private readonly ICategoryRepository _repo;
    private readonly IMapper _mapper;

    public CategoriesApiController(ICategoryRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categories = await _repo.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
    }
}
