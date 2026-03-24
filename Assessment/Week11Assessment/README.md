Problem Statement: "DI - The Centralized Pricing Engine"

1. The Context
"GlobalMart" is an MVC application that handles product displays and shopping carts. Currently, the logic to calculate discounts and final prices is hardcoded directly inside the ProductsController and the CheckoutController.
As the business grows, the marketing team wants to change discount rules frequently. Modifying every controller whenever a sale starts is becoming a maintenance nightmare and leads to "Bugs" where the price shown on the product page doesn't match the price in the checkout cart.

2. The Challenge
Your task is to decouple the pricing logic from the Controllers by moving it into a dedicated Business Logic Layer (BLL). You will then use Constructor Injection to share this logic across the entire application.

3. Requirements
The Service Contract: * Create an interface IPricingService that defines how prices should be calculated based on a base price and a promo code.
The Implementation: * Create a PricingService class. It must handle at least two specific codes: WINTER25 (15% off) and FREESHIP (subtract $5.00).
The DI Registration: * Configure the .NET Core container to provide the PricingService whenever an IPricingService is requested. You must choose the correct Service Lifetime (Transient, Scoped, or Singleton) and justify your choice.
The Multi-Controller Injection:
Inject the service into ProductsController to show "Discounted Prices" on the landing page.
Inject the same service into CartController to ensure the final total is calculated using the exact same logic.

4. Evaluation Criteria (The "Pass" Test)
Does it compile? The app must run without "Unable to resolve service" errors.
Is it DRY (Don't Repeat Yourself)? Is the math formula written in only one place (the Service)?
Is it Loosely Coupled? If you delete the PricingService class and create a NewDatabasePricingService, can you swap them in Program.cs without changing a single line of code in the Controllers?

💡 Implementation Tip for the Student
When you get to the Program.cs file, remember the "Rule of Thumb":
Use .AddScoped<IPricingService, PricingService>() if you want the service to live for the duration of a single HTTP request (the most common choice for Web/MVC).
