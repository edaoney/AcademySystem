namespace AcademySystem.Models;

public class Classroom
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

}