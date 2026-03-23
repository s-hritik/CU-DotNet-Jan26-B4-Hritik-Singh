using Day63.Assignment1.Models;
namespace Day63.Assignment1.Services;

internal interface IStudentService
{
   public void AddStudent(Student student);
   public IEnumerable<Student> GetStudents();

   public void UpdateStudent(Student updatedStudent);
   
   public void DeleteStudent(Student student);
}