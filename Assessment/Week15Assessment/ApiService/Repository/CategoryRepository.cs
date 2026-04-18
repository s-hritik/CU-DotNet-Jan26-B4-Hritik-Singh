using Microsoft.EntityFrameworkCore;
using ApiService.Data;
using ApiService.Models;

namespace ApiService.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToListAsync();
    }
}
