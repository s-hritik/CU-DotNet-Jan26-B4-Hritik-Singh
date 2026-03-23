namespace Day63.Assignment2.Services;

public class PricingService : IPricingService
{
    public decimal CalculateDiscountedPrice(decimal basePrice, string promoCode)
    {
        return promoCode?.ToUpper() switch
        {
            "WINTER25" => basePrice * 0.85m, // 15% off 
            "FREESHIP" => basePrice - 5.00m, // Subtract $5.00 
            _ => basePrice
        };
    }
}