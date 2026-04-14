📘 Assignment: End-to-End Azure Web App Deployment
Title: Deploy Web API with EF Core + Azure SQL + MVC Client on Azure

🎯 Objective
Build and deploy a complete cloud-based solution using:
.NET Core Web API
Entity Framework Core
Azure SQL Database
ASP.NET Core MVC
Azure App Service

🧱 Architecture Overview
MVC App (Frontend)  ↓ (HTTP calls) Web API (App Service)  ↓ Azure SQL Database

📝 Functional Requirement
Create a Student Management System
API Features:
Get all students
Get student by ID
Add student
Update student
Delete student
MVC App:
Display list of students
Add / Edit / Delete using API

🔨 Part 1: Create Web API with EF Core
Tasks:
Create ASP.NET Core Web API project
Install EF Core packages
Create Student model:
Id
Name
Age
Course
Create DbContext
Configure connection string (local SQL first)
Add Migration & Update Database
Implement CRUD API

☁️ Part 2: Create Azure SQL Database
Tasks:
Go to Azure Portal
Create:
SQL Server (logical server)
Database
Configure:
Firewall → Allow client IP
Authentication (SQL login)
Copy connection string

🔐 Part 3: Secure Connection String
Update in API project:
"ConnectionStrings": {  "DefaultConnection": "Your Azure SQL Connection String" }
👉 Best Practice:
Use Azure Key Vault (optional advanced task)

🚀 Part 4: Deploy Web API to Azure
Tasks:
Create App Service (Web App)
Publish API from Visual Studio:
Right-click project → Publish
Select Azure → App Service
Configure:
App Settings → Connection String
Runtime: .NET
Test API:
https://your-api-url/api/students

🖥️ Part 5: Create MVC Application
Tasks:
Create ASP.NET Core MVC project
Create Student ViewModel
Call API using:
HttpClient
Implement:
Index (list)
Create
Edit
Delete
Use API URL (deployed one)

🌐 Part 6: Deploy MVC App
Tasks:
Create second App Service
Publish MVC app
Update API base URL in MVC app

🔄 Part 7: CI/CD (Optional but Recommended)
Using GitHub:
Push code to repo
Configure deployment from:
GitHub
Enable:
Continuous Deployment for both apps

🧪 Testing Checklist
API accessible via browser/Postman
MVC app loads data from API
CRUD operations working
Data persists in Azure SQL
