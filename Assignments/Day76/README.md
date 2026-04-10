Assignment: Azure RBAC using Storage Account (Reader vs Contributor)

🎯 Objective
Understand and demonstrate Role-Based Access Control (RBAC) using a Azure Storage Account by assigning:
Reader Role
Contributor Role
…and validating access differences.

📌 Scenario
You are an Azure administrator. You need to:
Give read-only access to one user
Give full access to another user
on the same Storage Account.

🛠 Tasks to Perform

🔹 Task 1: Create Storage Account
Steps
Go to Azure Portal → Create Resource → Storage Account
Configure:
Resource Group: rg-rbac-demo
Name: storagerbacXXXX
Region: Any
Performance: Standard

📸 Screenshot Required
Storage Account Overview page

🔹 Task 2: Create Test Users
Go to Microsoft Entra ID (Azure AD)
Create 2 users:
readeruser@demo.com
contributoruser@demo.com

📸 Screenshot Required
Users list showing both users

🔹 Task 3: Assign RBAC Roles
Go to Storage Account → Access Control (IAM)

👤 Assign Reader Role
Add Role Assignment:
Role: Reader
Assign to: readeruser

👤 Assign Contributor Role
Add Role Assignment:
Role: Contributor
Assign to: contributoruser

📸 Screenshot Required
IAM page showing both role assignments

🔹 Task 4: Validate Reader Access
Login as readeruser
Try:
View Storage Account → ✅
Access Containers → ✅
Upload/Delete file → ❌ (should fail)

📸 Screenshot Required
Successful view access
Failed upload/delete attempt (error)

🔹 Task 5: Validate Contributor Access
Login as contributoruser
Try:
View Storage Account → ✅
Upload file → ✅
Delete file → ✅

📸 Screenshot Required
Successful upload
Successful delete
