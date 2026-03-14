Assignment: Build a Simple Company Website Using ASP.NET MVC and Bootstrap
Objective
Create an ASP.NET MVC application that demonstrates multiple controllers and views, all integrated using a shared _Layout.cshtml page with Bootstrap navigation.
The focus is on UI structure and MVC routing, not backend logic.

Step 1 – Create MVC Project
Create a project:
ASP.NET Core Web App (Model-View-Controller)
Project name:
CompanyPortal
Run the project once to verify it works.

Step 2 – Create Controllers
Create the following controllers.
1. HomeController

2. ServicesController

3. ProductsController

4. ContactController

Step 3 – Create Views
Create corresponding views.
Example:
Views/Home/Index.cshtml Views/Home/About.cshtml Views/Services/Index.cshtml Views/Services/Consulting.cshtml Views/Services/Training.cshtml Views/Products/Index.cshtml Views/Products/Software.cshtml Views/Products/Tools.cshtml Views/Contact/Index.cshtml
Each page should contain Bootstrap components.

Step 4 – Modify _Layout.cshtml
Add a Bootstrap Navbar.
Views/Shared/_Layout.cshtml

Use Dropdown menus for each controller, for sample-

Step 5 – Use Bootstrap Components in Pages
Students must use different Bootstrap components in each page.
Home Page
Use:
Jumbotron / Hero section
Cards
Example components:
Bootstrap Card Bootstrap Button

About Page
Use:
Bootstrap Alert Bootstrap List Group

Services Pages
Use:
Bootstrap Accordion Bootstrap Cards

Products Pages
Use:
Bootstrap Table Bootstrap Badges

Contact Page
Use:
Bootstrap Form Bootstrap Input fields Bootstrap Button
(No form submission logic required.)


Expected Output
Application should contain:
4 controllers
8+ views
Shared layout
Bootstrap navbar
Dropdown menus
Bootstrap UI components

Learning Outcomes
Students will understand:
MVC project structure
Controllers and actions
Razor Views
Shared layout (_Layout.cshtml)
Navigation with asp-controller and asp-action
Bootstrap UI integration
View routing
