using Day63.Assignment1.Models;
using System.Text.Json;
namespace Day63.Assignment1.Repositories;

internal class JsonStudentRepository : BaseStudentRepository
{
    private readonly string _filepath = "students.json";
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions 
    { 
        WriteIndented = true 
    };

    public JsonStudentRepository()
    {
        LoadData(); // Load existing data into the base _students list when instantiated
    }
    private void LoadData()
    {
        if (!File.Exists(_filepath)) return;

        try
        {
            string jsonString = File.ReadAllText(_filepath);
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                _students = JsonSerializer.Deserialize<List<Student>>(jsonString) ?? new List<Student>();
            }
        }
        catch (JsonException) { /* If JSON is corrupted, it will start with an empty list */ }
    }

    public override void AddStudent(Student student)
    {
        base.AddStudent(student);
        SaveAll();
    }

    public override void UpdateStudent(Student updatedStudent)
    {
        base.UpdateStudent(updatedStudent);
        SaveAll();
    }

    public override void DeleteStudent(Student student)
    {
        base.DeleteStudent(student);
        SaveAll();
    }
    
    private void SaveAll()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(_students, _options);
            File.WriteAllText(_filepath, jsonString);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }
}

