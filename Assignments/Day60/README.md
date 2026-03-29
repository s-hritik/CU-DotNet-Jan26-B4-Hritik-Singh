"WealthTrack" Portfolio Manager
In this assignment, you will build an ASP.NET Core MVC application that allows users to manage a list of Assets (Stocks/ETFs). You will use Entity Framework Core (EF Core) for data persistence and ViewModels to handle data transfer between the Controller and the View.
1. The Data Model (Database Layer)
Create a Model class representing the database table.
C#
public class Investment
{
    public int Id { get; set; }
    public string TickerSymbol { get; set; } // e.g., "SILVERBEES"
    public string AssetName { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
}
2. The ViewModel (Presentation Layer)
Create a ViewModel to simplify the "Create" view. It should include validation logic and only the fields necessary for user input.
C#
public class InvestmentCreateViewModel
{
    [Required(ErrorMessage = "Ticker is required")]
    [StringLength(10)]
    [Display(Name = "Ticker Symbol")]
    public string TickerSymbol { get; set; }

    [Required]
    [Range(0.01, 1000000)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, 10000)]
    public int Quantity { get; set; }

    [Display(Name = "Total Investment Value")]
    public string TotalValue => (Price * Quantity).ToString("C");
}

Assignment Requirements
Part A: Database Configuration
Implement a DbContext class named PortfolioContext.
Use a LocalDB or SQLite connection string.
Run the necessary commands to create a migration and update the database:
dotnet ef migrations add InitialCreate
dotnet ef database update
Part B: Controller Logic
Implement an InvestmentsController with the following actions:
Index: Display a list of all investments.
Create (GET): Return the view using the InvestmentCreateViewModel.
Create (POST): Receive the ViewModel, validate it, map the data to the Investment Model, and save it to the database via EF Core.
Part C: Mapping Logic
Inside your POST method, perform manual mapping (or use AutoMapper if you are familiar with it):
C#
if (ModelState.IsValid)
{
    var model = new Investment 
    {
        TickerSymbol = vm.TickerSymbol,
        PurchasePrice = vm.Price,
        Quantity = vm.Quantity,
        PurchaseDate = DateTime.Now
    };
    _context.Add(model);
    await _context.SaveChangesAsync();
}
