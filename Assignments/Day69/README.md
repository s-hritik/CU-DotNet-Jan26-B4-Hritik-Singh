Assignment: Student Course Management API

🎯 Objective
Build a RESTful Web API to manage Students and Courses using:
Entity Framework Core
Fluent API configurations
Content Negotiation (JSON & XML)

🧱 Functional Requirements

1. Entities (Models)
   Create two entities:
   📌 Student
   Id (int, PK)
   Name (string, required, max 100)
   Email (string, unique)
   Age (int)
   📌 Course
   Id (int, PK)
   Title (string, required)
   Credits (int)
   📌 Relationship
   One Student can enroll in many Courses
   Many-to-Many relationship

🗄️ Database Requirements
✔ Use EF Core Code First
Create DbContext
Add DbSets
✔ Use Fluent API (MANDATORY)
Configure:
Table names
Required fields
Max length
Unique constraint on Email
Many-to-Many relationship (StudentCourses table)
👉 Do NOT use Data Annotations for these rules (test Fluent API understanding)

🔌 API Endpoints
📌 Student APIs
GET /api/students
GET /api/students/{id}
POST /api/students
PUT /api/students/{id}
DELETE /api/students/{id}
📌 Course APIs
Same CRUD operations
📌 Enrollment API
POST /api/enroll
Input: StudentId, CourseId

🔄 Content Negotiation (IMPORTANT)
✔ Configure API to support:
JSON (default)
XML
✔ Behavior:
If client sends:
Accept: application/json → return JSON
Accept: application/xml → return XML
✔ Task:
Test APIs using:
Postman
Browser (optional)

🧪 Testing Scenarios
Students must demonstrate:
Create Student & Course
Enroll student in course
Fetch data in:
JSON
XML (using headers)
Validate:
Email uniqueness
Required fields

⚙️ Technical Constraints
Use Repository Pattern (optional bonus)
Use DTOs (recommended)
Proper HTTP status codes:
200 OK
201 Created
400 Bad Request
404 Not Found
