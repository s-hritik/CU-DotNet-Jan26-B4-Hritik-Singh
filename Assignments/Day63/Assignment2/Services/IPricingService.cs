namespace Day63.Assignment2.Services;

public interface IPricingService
{
    decimal CalculateDiscountedPrice(decimal basePrice, string promoCode);
}