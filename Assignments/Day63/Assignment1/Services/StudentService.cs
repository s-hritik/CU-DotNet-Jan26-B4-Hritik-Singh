using Day63.Assignment1.Repositories;
using Day63.Assignment1.Models;

namespace Day63.Assignment1.Services;

internal class StudentService : IStudentService
{
    private IStudentRepository _repo { get; set; }
    
    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

    public void AddStudent(Student student)
    {
        ValidateGrade(student.Grade);
        _repo.AddStudent(student);
    }

    public IEnumerable<Student> GetStudents()
    {
        return _repo.GetStudents();
    }

    public void UpdateStudent(Student updatedStudent)
    {
        ValidateGrade(updatedStudent.Grade);
        _repo.UpdateStudent(updatedStudent);
    }

    public void DeleteStudent(Student student)
    {
        _repo.DeleteStudent(student);
    }

    private void ValidateGrade(int grade)
    {
        if (grade < 0 || grade > 100)
        {
            throw new ArgumentException("Grade must be between 0 and 100.");
        }
    }
}