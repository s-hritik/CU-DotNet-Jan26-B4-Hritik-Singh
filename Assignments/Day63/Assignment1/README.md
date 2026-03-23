
Problem Statement: "The Adaptive Student Data Layer"

1. Context
A local educational institution needs a lightweight Student Management System to track academic performance. However, their IT environment is currently in transition. Half of their labs have access to a shared network drive (requiring JSON file storage), while the other half are temporary kiosks that only need to hold data In-Memory for quick testing and demonstration purposes.

2. The Challenge
Build a C# Console Application using a 3-Layer Architecture (Presentation, Business Logic, and Data Access) that can switch between different storage mechanisms at runtime without changing the core business logic.

3. Requirements
Domain Entity: Create a Student class with properties for Id, Name, and Grade.
Logical Layers:
Data Access Layer (DAL): Define an interface IStudentRepository. Implement two versions:
ListStudentRepository: Stores data in a List<T>.
JsonStudentRepository: Persists data to a local students.json file.
Business Logic Layer (BLL): Create a StudentService that handles data validation (e.g., ensuring grades are between 0–100) and communicates with the repository.
Presentation Layer: A Console interface that asks the user which storage method to use at startup.
Core Principles:
Dependency Inversion: The StudentService must depend on the IStudentRepository interface, not a specific class.
Single Responsibility: The service should not know how the data is saved, and the repository should not know why the data is being saved.

4. Expected Output
The user selects "1" or "2" on the console.
The application instantiates the correct repository.
The user can enter values for a student.
Create Menu based app for all CRUD operations.
If JSON is selected, the data must persist even after the application is closed and restarted.

💡 Why this is a "Good" Problem
This problem tests whether a developer understands Abstractions. If the code requires an if/else block inside the StudentService to check which repository is being used, the developer has failed the architecture test. The "decision" must happen at the very top (in Program.cs), and the service must remain "blind" to the storage details.
