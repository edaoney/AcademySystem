namespace AcademySystem.Models;

public class Classroom
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Teacher> Teachers { get; set; }

}