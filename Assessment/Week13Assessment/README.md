Week 13 Assessment: The "Vagabond" Travel Destination API

Back-End

Objective
Develop a RESTful Web API for managing travel destinations using Entity Framework Core (Code First), the Repository Pattern, and Fluent API for data modeling.

1. Domain Model
   Create a single entity class named Destination. Use the following properties:
   Id (Primary Key)
   CityName (Required)
   Country (Required)
   Description (Optional)
   Rating (Scale of 1-5)
   LastVisited (DateTime)

2. Technical Requirements
   Data Layer & Fluent API
   Code First: Generate your database schema using EF Migrations.
   Fluent API Configuration: Instead of using Data Annotations (like [Required]), use the OnModelCreating method in your DbContext to:
   Set CityName and Country as required.
   Set a maximum length of 200 for Description.
   Configure Rating to have a default value of 3.
   Repository Pattern
   Define an interface IDestinationRepository.
   Implement a DestinationRepository class to handle CRUD operations:
   GetAllAsync()
   GetByIdAsync(int id)
   AddAsync(Destination destination)
   UpdateAsync(Destination destination)
   DeleteAsync(int id)
   Global Exception Handling
   Implement a Custom Middleware or an Exception Filter to catch unhandled exceptions.
   Return a consistent JSON error response (e.g., containing a StatusCode and a Message).
   Ensure that if a user requests a Destination ID that doesn't exist, a 404 Not Found is returned gracefully.
   API Controller
   Create a DestinationsController.
   Inject the repository via Dependency Injection (DI).
   Implement the following endpoints:
   GET /api/destinations
   GET /api/destinations/{id}
   POST /api/destinations
   PUT /api/destinations/{id}
   DELETE /api/destinations/{id}

3. Submission Checklist

Challenge
Implement a Custom Exception class (e.g., DestinationNotFoundException) and catch it specifically in your middleware to return a tailored message to the client.

Front-End
Decoupled MVC Integration
The Scenario
To simulate a real-world distributed system, you are now required to decouple the UI from the Data Layer. The MVC project must not have a direct reference to the IDestinationRepository or the DbContext. Instead, it must treat the Web API as its sole data provider.
Requirements

1. Service Abstraction
   Create an interface IDestinationService and an implementation DestinationService within the MVC project.
   This service must use IHttpClientFactory to create an instance of HttpClient.
   All data fetching logic (GET All) must be performed via asynchronous HTTP calls to the Web API’s URL (e.g., https://localhost:xxxx/api/destinations).
2. Dependency Injection & Configuration
   Register the HttpClient in Program.cs using the typed client pattern:
   C#
   builder.Services.AddHttpClient<IDestinationService, DestinationService>(client => {
   client.BaseAddress = new Uri("https://localhost:xxxx/");
   });
3. MVC Controller Logic
   Update your TravelController to inject IDestinationService instead of the repository.
   The Index action should use HttpClient to Get All data.
4. Handling the "Double Start"
   Configure the solution to use Multiple Startup Projects so that both the Web API and the MVC App run simultaneously when you press F5.
