📘 Assignment: Role-Based Authentication & Authorization in ASP.NET Core MVC
🎯 Objective
Build a secure ASP.NET Core MVC application using Identity with:
User Registration & Login
Role Management
Role-based Authorization
Controlled access to different actions

🧩 Problem Statement
You are required to develop a Car Management MVC Application with authentication and role-based authorization.
The system must support 3 types of users:


🏗️ Functional Requirements
1. Authentication
Implement ASP.NET Core Identity
Features:
Register
Login
Logout

2. Role Setup (Mandatory)
Seed or create the following roles:
Admin Customer User

3. User Creation Requirement
Create 3 users (either via UI or seeding):


4. Module: Car Management
Create a Car entity:
public class Car {     public int Id { get; set; }     public string Brand { get; set; }     public string Model { get; set; }     public int Year { get; set; }     public decimal Price { get; set; } }

🔐 Authorization Rules (Core of Assignment)
Apply role-based authorization using [Authorize]
Controller: CarController
1. View Cars
[Authorize(Roles = "Admin,Customer,User")] public IActionResult Index()
✅ All users can view

2. Create Car
[Authorize(Roles = "Admin,Customer")] public IActionResult Create()
✅ Only Admin & Customer

3. Edit Car
[Authorize(Roles = "Admin")] public IActionResult Edit(int id)
✅ Only Admin

4. Delete Car
[Authorize(Roles = "Admin")] public IActionResult Delete(int id)
✅ Only Admin

🧪 Expected Behavior (Test Cases)


⚙️ Technical Requirements
1. Use Identity
AddDefaultIdentity or AddIdentity
Use EF Core

📂 Expected Project Structure
Controllers/     AccountController     CarController  Models/     Car.cs  Data/     ApplicationDbContext.cs  Views/     Car/     Account/     Shared/  Areas/     Identity/


Add Identity Pages and customize Login page for Company name, logo, theme etc
