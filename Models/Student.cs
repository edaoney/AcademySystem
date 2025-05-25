namespace AcademySystem.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
        
}