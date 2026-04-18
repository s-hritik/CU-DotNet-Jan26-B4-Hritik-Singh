using Microsoft.EntityFrameworkCore;
using ApiService.Data;
using ApiService.DTOs;
using ApiService.Models;

namespace ApiService.Repositories;


public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId && !p.Discontinued)
            .OrderBy(p => p.ProductName)
            .ToListAsync();
    }

    public async Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync()
    {
        return await _context.Categories
            .Select(c => new CategorySummaryDto
            {
                CategoryName = c.CategoryName,
                ProductCount = c.Products.Count(p => !p.Discontinued),
                AvgPrice = c.Products.Any()
                    ? c.Products.Average(p => p.UnitPrice ?? 0m)
                    : 0m,
                MostExpensiveProduct = c.Products
                    .OrderByDescending(p => p.UnitPrice)
                    .Select(p => p.ProductName)
                    .FirstOrDefault()
            })
            .OrderBy(s => s.CategoryName)
            .ToListAsync();
    }
}
