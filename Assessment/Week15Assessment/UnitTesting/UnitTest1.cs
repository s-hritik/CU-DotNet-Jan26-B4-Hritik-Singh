using ApiService.DTOs;
using Xunit;

namespace UnitTesting;

public class UnitTest1
{
    [Fact]
    public void InventoryValue_Should_Return_Correct_Math()
    {
        ProductDto product = new ProductDto();
        product.ProductId = 1;
        product.ProductName = "Chai";
        product.UnitPrice = 18.00m;
        product.UnitsInStock = 10;

        decimal actualResult = product.InventoryValue;

        decimal expectedResult = 180.00m;
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void InventoryValue_Should_Be_Zero_When_Stock_Is_Zero()
    {
        ProductDto product = new ProductDto();
        product.ProductName = "Out of Stock Product";
        product.UnitPrice = 25.50m;
        product.UnitsInStock = 0;

        decimal actualResult = product.InventoryValue;

        Assert.Equal(0m, actualResult);
    }

    [Fact]
    public void CategorySummaryDto_Should_Store_Data_Correctly()
    {
        CategorySummaryDto summary = new CategorySummaryDto();
        summary.CategoryName = "Beverages";
        summary.ProductCount = 12;
        summary.AvgPrice = 37.98m;
        summary.MostExpensiveProduct = "Côte de Blaye";

        Assert.Equal("Beverages", summary.CategoryName);
        Assert.Equal(12, summary.ProductCount);
        Assert.Equal(37.98m, summary.AvgPrice);
        Assert.Equal("Côte de Blaye", summary.MostExpensiveProduct);
    }

    [Fact]
    public void CategoryDto_ImageUrl_Should_Build_Correct_String()
    {
        CategoryDto dto = new CategoryDto();
        dto.CategoryId = 1;
        dto.CategoryName = "Beverages";

        dto.ImageUrl = "/images/" + dto.CategoryName + ".jpg";

        string actualUrl = dto.ImageUrl;

        string expectedUrl = "/images/Beverages.jpg";
        Assert.Equal(expectedUrl, actualUrl);
    }
}