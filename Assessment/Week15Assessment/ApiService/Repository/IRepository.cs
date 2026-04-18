using ApiService.DTOs;
using ApiService.Models;

namespace ApiService.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
}
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
    Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
}
