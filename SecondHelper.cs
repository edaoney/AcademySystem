using AcademySystem.Data;
using AcademySystem.Models;

namespace AcademySystem;

public class SecondHelper
{
     private static AppDbContext _db = new AppDbContext();

     public static List<Student> GetStudents()
     {
         return _db.Students.ToList();
     }

     public static void ListStudents()
     {
         // var students = GetStudents();
         // foreach (var student in students)
         // {
         //     Console.WriteLine($"{student.Name} {student.Surname}");
         // }
         if (!_db.Students.Any())
         {
             _db.Students.AddRange(
                 new Student { Name = "Sudenaz", Surname = "Öney" },
                 new Student { Name = "Sümeyye", Surname = "Kosova" },
                 new Student { Name = "Büşra", Surname = "Eşmen" }
             );
             _db.SaveChanges();
             Console.WriteLine("Veritabanında öğrenci yoktu, veriler eklendi.");
         }
         else
         {
             Console.WriteLine("Veritabanında zaten öğrenci verisi var:");
             foreach (var student in _db.Students.ToList())
             {
                 Console.WriteLine($"Ad: {student.Name}, Soyad: {student.Surname}");
             }
         }
     }

    
    
    public static void ListTeachers()
    {
        if (_db.Teachers.Any())
        {
            return;
        }

        _db.Teachers.AddRange(
            new Teacher { Name = "Orhan", Surname = "Ekici" },
            new Teacher { Name = "Nihat", Surname = "Duysak" },
            new Teacher { Name = "Ozan Çağatay", Surname = "Alıcı" }
        );
        _db.SaveChanges();
    }     
    
    public static void ListClass()
    {
        if (_db.Classrooms.Any())
        {
            return;
        }

        _db.Classrooms.AddRange(
            new Classroom{ ClassName = "BE Focu"},
            new Classroom{ ClassName = "BE Flex"}
        );
        _db.SaveChanges();
        Helper.ShowErrorMsg("Listelendi");
    }                 

    
     public static void AddStudent()
    {
        using var _db = new AppDbContext();
        Console.Clear();
        Console.Write("Ad: ");
        string name = Console.ReadLine();
        
        Console.Write("Soyad: ");
        string surname = Console.ReadLine();
        
        Helper.ShowErrorMsg("Kaydın Yapıldı");
        
        Student newStudent = new Student
        {
            Name = name,
            Surname = surname,
        };
        _db.Add(newStudent);
        _db.SaveChanges();
        
    }
     
    public static void AddTeacher()
    {
        using var _db = new AppDbContext();
        Console.Clear();
        Console.Write("Ad: ");
        string name = Console.ReadLine();
        
        Console.Write("Soyad: ");
        string surname = Console.ReadLine();
        
        Helper.ShowErrorMsg("Kaydın Yapıldı");
        
        Teacher newTeacher = new Teacher
        {
            Name = name,
            Surname = surname,
        };
        _db.Add(newTeacher);
        _db.SaveChanges();
        
    }
    
    public static void AddClass()
    {
        using var _db = new AppDbContext();
        Console.Clear();
        Console.Write("Sınıf:  ");
        string name = Console.ReadLine();
        
       Helper.ShowErrorMsg("Kaydın Yapıldı");
       
        Classroom newClassroom = new Classroom
        {
            ClassName = name,
            
        };
        _db.Add(newClassroom);
        _db.SaveChanges();
        
    }

    

    
}