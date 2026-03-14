To turn this assignment into a formal challenge, you need a Problem Statement that describes a real-world scenario. This helps the student understand why they are using these specific coding techniques.

🏢 Problem Statement: The Corporate "Pulse" Portal
Background
TechStream Solutions needs a read-only internal dashboard for their staff. The portal is designed to provide employees with a quick snapshot of their department's status, important company-wide announcements, and a list of team members.
Since this is a "Pulse" (at-a-glance) portal, it does not require any data entry or editing features—it only needs to fetch data from the server and display it beautifully.

The Challenge
You have been tasked with building the Dashboard Page. The lead architect has requested that you demonstrate your ability to handle different types of data by using three specific ASP.NET Core MVC data-passing mechanisms:
Core Entity Data: The list of employees must be passed using a Strongly Typed Model to ensure the table is type-safe and performant.
Volatile Metadata: Temporary information, like the "Daily Announcement," should be passed using ViewBag.
Static Configuration: Environmental data, such as the "Department Name" and "Server Status," must be passed using ViewData.

Requirements & Constraints
The Entity: You must define an Employee class with properties for Id, Name, Position, and Salary.
The Controller: You must instantiate a List<Employee> manually (simulating a database fetch) and populate both ViewBag and ViewData.
The View: * Use a Bootstrap Table to render the employee list.
Display the ViewBag announcement in a prominent "Alert" box at the top.
Use a Conditional Check (@if) on a ViewData boolean value to show whether the department is "Active" or "Under Maintenance."
No Persistence: Do not use a database (SQL/Entity Framework) for this task; use a static list or a local list inside the action method.

🎯 Success Criteria
The assignment is successful if:
The URL /Company/Dashboard loads without errors.
The employee table correctly maps the properties from the Employee entity.
The student can explain why Casting was necessary for the ViewData boolean but not for the ViewBag string.
The page uses Razor syntax (@foreach) to iterate through the model.
