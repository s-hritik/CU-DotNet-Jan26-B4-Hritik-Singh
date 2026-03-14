using Microsoft.AspNetCore.Mvc;
using PulsePortal.Models;

namespace PulsePortal.Controllers;

public class CompanyController : Controller
{
    public static List<Employee> employees = new List<Employee>()
        {
            new Employee {Id = 1, Name = "Hritik Singh", Position = "CEO" , Salary = 100000},
            new Employee {Id = 2, Name = "Samwell Tarley", Position = "Devloper" , Salary = 50000},
            new Employee {Id = 3, Name = "Jorah Mormont", Position = "Manager" , Salary = 60000}
        };

    [HttpGet]
    public IActionResult Dashboard()
    {
        ViewBag.DailyAnnouncement = "Team lunch is moved to Friday at 1:00 PM!";
        ViewData["DepartmentName"] = "Engineering Operations";
        ViewData["IsActive"] = true;
        return View(employees);
    }
    
}