Case Study: Shared Greeting Library

Business Scenario
A company is building multiple small console tools. To avoid repeating code, they want a shared library that generates greeting messages, which can be reused by different applications.
Your task is to:
Create a Class Library (.NET Framework)
Add a simple method in the library
Reference the library from a Console Application
Use the library method to display output

Solution Structure (Mandatory)
Create a .NET Framework solution with the following projects:
GreetingSolution
│
├── GreetingLibrary (Class Library – .NET Framework)
└── GreetingApp (Console App – .NET Framework)

Project 1: Class Library – GreetingLibrary
Step 1: Create the Library Project
Project Type: Class Library (.NET Framework)
Project Name: GreetingLibrary

Step 2: Create a Class
Create a class named:
GreetingHelper

Step 3: Add a Method
Add the following method to the class:
public static string GetGreeting(string name)
Method Rules
If name is empty or null → return "Hello, Guest!"
Otherwise → return "Hello, <name>!"
Examples:
Hello, Sharad!
Hello, Guest!

Project 2: Console App – GreetingApp
Step 1: Create Console Application
Project Type: Console App (.NET Framework)
Project Name: GreetingApp

Step 2: Add Reference to Library
Right-click GreetingApp
Add Project Reference
Select GreetingLibrary

Step 3: Use the Library
In Main():
Ask the user to enter their name
Call GreetingHelper.GetGreeting()
Display the returned greeting

Expected Console Interaction
Input
Enter your name:
Sharad
Output
Hello, Sharad!

Input
Enter your name:

Output
Hello, Guest!

What This Exercise Teaches
