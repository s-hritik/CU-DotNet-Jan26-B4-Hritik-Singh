using Day63.Assignment1.Models;

namespace Day63.Assignment1.Repositories;

internal abstract class BaseStudentRepository : IStudentRepository
{
    protected List<Student> _students = new List<Student>();

    public virtual void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public virtual IEnumerable<Student> GetStudents()
    {
        return _students;
    }

    public virtual void UpdateStudent(Student updatedStudent)
    {
        int index = _students.FindIndex(s => s.Id == updatedStudent.Id);
        if (index != -1)
        {
            _students[index] = updatedStudent;
        }
    }

    public virtual void DeleteStudent(Student student)
    {
        _students.RemoveAll(s => s.Id == student.Id);
    }
}