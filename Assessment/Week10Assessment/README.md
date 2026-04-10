This assessment is designed to test your ability to architect a multi-controller ASP.NET Core MVC application using the Finance domain. It combines data persistence (EF Core), in-memory logic, and advanced data-passing techniques.

Project Structure: "FinTrack Pro"
Part 1: The Model (Shared Entity)
Create a Transaction.cs model that will be used across your controllers.
C#
public class Transaction {
public int Id { get; set; }
public string Description { get; set; }
public double Amount { get; set; }
public string Category { get; set; } // e.g., Income, Expense
public DateTime Date { get; set; }
}

🏗️ Part 2: The Three Controllers
Controller 1: AccountController (Entity Framework Core)
Goal: Implement persistent storage for bank accounts.
Action: Index (List all accounts from DB).
Action: Create (Add a new account record).
Constraint: Use Conventional Routing here.
Data Passing: Pass the list of accounts using a Strongly Typed Model (List<Account>).
Controller 2: PortfolioController (In-Memory List)
Goal: Manage a list of Stocks/Assets without a database.
Logic: Define a private static List<Asset> inside the controller.
Action: Details(int id) — Use Attribute Routing: [Route("Asset/Info/{id:int}")].
Action: Delete(int id) — After deleting, use TempData to pass a "Success" message back to the Index.
Data Passing: Use TempData["Message"] to confirm deletions.
Controller 3: MarketController (Data Passing & Bootstrap)
Goal: Display market trends and status metadata.
Action: Summary — This action should not use a Model.
Data Passing: \* Use ViewBag to pass the "Market Status" (e.g., Open/Closed).
Use ViewData to pass "Top Gainer" (string) and "Volume" (long).
Display: Use Bootstrap Alerts to show the Market Status and a Bootstrap Card for the Top Gainer.

📝 Assignment Requirements (The Task)
Task A: Routing Challenge
In the MarketController, create a search action using specialized attribute routing:
Route: [HttpGet("Analyze/{ticker}/{days:int?}")]
Logic: If days is null, default it to 30. Pass these parameters to the view using ViewBag.
Task B: The "Toast" Implementation
In the AccountController, after a user successfully creates an account and is redirected to the Index:
Use TempData to store the success message.
Implement a Bootstrap Toast in the Index.cshtml that automatically pops up if TempData["Success"] is not null.
Task C: Type Safety & Casting
In the PortfolioController's Index view:
Pass a "Total Portfolio Value" using ViewData["Total"].
In the View, perform a calculation (e.g., Total + 500) which will require you to cast the ViewData back to a double.

🎯 Success Criteria
AccountController: Successfully performs CRUD using \_context.
PortfolioController: Routes work specifically via the custom [Route] attributes defined.
MarketController: Displays data correctly without a model, using only ViewBag and ViewData.
Validation: All forms include asp-validation-summary and asp-validation-for.
