Decentralized Inventory Management System

Background
A growing tech retail company, "VoltGear Systems," is struggling to manage its laptop inventory. Currently, they use manual spreadsheets that lead to data duplication, loss of records, and zero real-time visibility. To modernize, they want a web-based solution that is fast, scalable, and utilizes a non-relational (NoSQL) database to handle varying hardware specifications in the future.

Objective
Build a web application that allows users to catalog hardware (Laptops) into a MongoDB database. You will implement the Repository Pattern to handle data operations and use Razor Pages for the User Interface.

Part 1: Environment Setup
Project Template: Create a new project using ASP.NET Core Web App (Model-View-Controller).
Database: \* Set up a local MongoDB instance or a free MongoDB Atlas cluster.
Create a database named InventoryDB and a collection named Laptops.
NuGet Packages: Install the following drivers:
MongoDB.Driver

Part 2: The Model & Configuration

1. Define the Model
   Create a Laptop class. Since MongoDB uses BSON, you must map the unique identifier correctly.

AppSettings
Add your MongoDB connection string to appsettings.json:
JSON
"DatabaseSettings": {
"ConnectionString": "mongodb://localhost:27017",
"DatabaseName": "InventoryDB",
"CollectionName": "Laptops"
}

Data Access Layer
Create a service called LaptopService.cs to handle the logic. This service should be injected into your application using the Scoped lifetime.
Tasks:
Initialize the MongoClient in the constructor.
Create a method CreateAsync(Laptop newLaptop) to insert data into the collection.
Create a method GetAsync() to retrieve all laptops.

The Challenge
You have been tasked with developing a Proof of Concept (PoC) using ASP.NET Core MVC. The application must demonstrate the ability to capture laptop details through a web interface and persist them into MongoDB. The solution needs to follow modern architectural standards, specifically focusing on Dependency Injection lifetimes and the Repository Pattern to ensure the code is maintainable and testable.

Functional Requirements
Data Capture: Create a "New Equipment" entry form using Razor Pages/Views that captures the Model Name, Serial Number, and Price.
NoSQL Integration: Connect the application to a MongoDB instance. Unlike relational databases (SQL Server), the system should store these records as BSON documents.
Real-Time Listing: Implement a dashboard view that retrieves all stored laptops from MongoDB and displays them in a structured HTML table.
State Management: Use TempData or ViewBag to provide immediate feedback to the user (e.g., "Laptop successfully saved to MongoDB").

Technical Constraints
Architecture: Use the Model-View-Controller (MVC) pattern.
Service Lifetime: You must register your MongoDB access service as Scoped in the DI container to ensure a fresh connection per request.
Data Mapping: Use the MongoDB.Driver and ensure the Laptop model correctly maps the string Id to the MongoDB \_id (ObjectId) using BSON attributes.
Configuration: The Database connection string and Collection names must not be hardcoded; they must be retrieved from appsettings.json.

Success Criteria
Persistence: If the web server restarts, the data remains available (verified by checking the MongoDB collection via Compass or Shell).
Validation: The system should prevent the user from submitting empty fields or a negative price.
Clean UI: Use Bootstrap (included in the MVC template) to ensure the form and table are responsive and professional.
