using Day63.Assignment1.Models;

namespace Day63.Assignment1.Repositories;

internal interface IStudentRepository
{
   public void AddStudent(Student student);
   public IEnumerable<Student> GetStudents();

   public void UpdateStudent(Student updatedStudent);
   
   public void DeleteStudent(Student student);
}