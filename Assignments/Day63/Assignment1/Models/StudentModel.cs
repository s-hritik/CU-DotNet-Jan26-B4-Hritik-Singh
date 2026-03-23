namespace Day63.Assignment1.Models;

internal class Student
{
    public int Id {get;set;}
    public string? Name {get;set;}
    public int Grade {get;set;}

    public override string ToString()
    {
        return $"{Id} - {Name} - {Grade}";
    }
}