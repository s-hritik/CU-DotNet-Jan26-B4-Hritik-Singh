using Day63.Assignment1.Models;
using Day63.Assignment1.Services;
using Day63.Assignment1.Repositories;

namespace Day63.Assignment1.UI;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select Storage Mechanism:");
        Console.WriteLine("1. In-Memory List");
        Console.WriteLine("2. JSON File");
        Console.Write("Choice (1 or 2): ");
        
        if (!int.TryParse(Console.ReadLine(), out int input) || (input != 1 && input != 2))
        {
            Console.WriteLine("Invalid Input. Exiting application.");
            return;
        }

        IStudentService service;
        
        // Architectural Test Passed: Decision is made here at the very top.
        if (input == 1)
        {
            service = new StudentService(new ListStudentRepository());
        }
        else
        {
            service = new StudentService(new JsonStudentRepository());
        }

        RunMenu(service);
    }

    private static void RunMenu(IStudentService service)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Student Management Menu ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddStudentUI(service);
                    break;
                case "2":
                    DisplayStudents(service.GetStudents());
                    break;
                case "3":
                    UpdateStudentUI(service);
                    break;
                case "4":
                    DeleteStudentUI(service);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void AddStudentUI(IStudentService service)
    {
        try
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Grade (0-100): ");
            int grade = int.Parse(Console.ReadLine() ?? "0");

            service.AddStudent(new Student { Id = id, Name = name, Grade = grade });
            Console.WriteLine("Student added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateStudentUI(IStudentService service)
    {
        try
        {
            Console.Write("Enter ID of student to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter New Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter New Grade (0-100): ");
            int grade = int.Parse(Console.ReadLine() ?? "0");

            service.UpdateStudent(new Student { Id = id, Name = name, Grade = grade });
            Console.WriteLine("Student updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DeleteStudentUI(IStudentService service)
    {
        try
        {
            Console.Write("Enter ID of student to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            service.DeleteStudent(new Student { Id = id });
            Console.WriteLine("Student deletion process completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void DisplayStudents(IEnumerable<Student> students)
    {
        Console.WriteLine("\n--- Student List ---");
        if (!students.Any())
        {
            Console.WriteLine("No students found in the database.");
            return;
        }

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}