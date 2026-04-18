namespace ApiService.DTOs;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}

public class ProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public decimal InventoryValue => UnitPrice * UnitsInStock;
}

public class CategorySummaryDto
{
    public string CategoryName { get; set; } = string.Empty;
    public int ProductCount { get; set; }
    public decimal AvgPrice { get; set; }
    public string? MostExpensiveProduct { get; set; }
}
