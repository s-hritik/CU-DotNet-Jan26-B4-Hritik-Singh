This assignment is designed to test proficiency in Database First development using Entity Framework Core and integrating a robust logging framework like Serilog.

Assignment: Building a Library Management API
Scenario
You have been provided with an existing SQL Server database named LibraryDB. Your task is to build a RESTful Web API that allows users to manage books and authors. To ensure the application is production-ready, you must implement centralized logging using Serilog.
Technical Requirements
Framework: ASP.NET Core Web API (.NET 6/7/8+).
ORM: Entity Framework Core (Database First approach).
Logging: Serilog with Console and File sinks.
Database: SQL Server.

Task 1: Database Reverse Engineering
Assuming the database has two tables, Authors and Books (where a Book has an AuthorId), use the Scaffold-DbContext command (or dotnet ef dbcontext scaffold) to generate your models and the DbContext.
Ensure you use the -OutputDir Models flag to keep your project organized.
The connection string should be managed via appsettings.json.

Task 2: Controller Development
Create a BooksController with the following endpoints:
GET /api/books: Retrieve all books including their Author details.
GET /api/books/{id}: Retrieve a specific book.
POST /api/books: Add a new book.
PUT /api/books/{id}: Update an existing book.
DELETE /api/books/{id}: Remove a book.

Task 3: Implement Serilog
Configure Serilog in Program.cs to replace the default .NET logger.
Sinks: Log output to both the Console and a File (e.g., logs/library-log-.txt).
Log Levels: \* Log an Information message when an endpoint is hit.
Log a Warning if a user tries to access a non-existent ID.
Log an Error (with exception details) inside a global exception handler or try-catch block.
Enrichment: Include the machine name or thread ID in the logs.

Task 4: Error Handling
Implement a simple middleware or use a try-catch block in your actions to ensure that any unhandled exceptions are caught, logged via Serilog, and return a clean 500 Internal Server Error response to the client.

Submission Deliverables
Source Code: The complete ASP.NET Web API project.
Configuration: The appsettings.json showing the Serilog configuration.
Log File: A sample .txt log file generated after performing a few API calls (GET, POST, and a failed DELETE).
