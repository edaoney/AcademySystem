using AcademySystem.Data;
using AcademySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademySystem;

public class SecondHelper
{
     private static AppDbContext _db = new AppDbContext();

     

     public static void ListStudents()
     {
         
         if (!_db.Students.Any())
         {
             _db.Students.AddRange(
                 new Student { Name = "Sudenaz",  Surname = "Öney" },
                 new Student { Name = "Sümeyye",  Surname = "Kosova" },
                 new Student { Name = "Büşra",  Surname = "Esmer" }
             );
             _db.SaveChanges();
         }
         else
         {
             foreach (var student in _db.Students.ToList())
             {
                 Console.WriteLine($"{student.Id}- Ad: {student.Name}, Soyad: {student.Surname}");
             }
         }
     }

    
    
    public static void ListTeachers()
    {
        if (!_db.Teachers.Any())
        {
            _db.Teachers.AddRange(
                new Teacher { Name = "Orhan",  Surname = "Ekici" },
                new Teacher { Name = "Nihat",  Surname = "Duysak" },
                new Teacher { Name = "Ozan Çağatay",  Surname = "Alıcı" }
            );
            _db.SaveChanges();
        }
        else
        {
            foreach (var teacher in _db.Teachers.ToList())
            {
                Console.WriteLine($"{teacher.Id}- Ad: {teacher.Name}, Soyad: {teacher.Surname}");
            }
        }
    }     
    
    public static void ListClass()
    {
        if (!_db.Classrooms.Any())
        {
            _db.Classrooms.AddRange(
                new Classroom { ClassName = "BE Focus" },
                new Classroom { ClassName = "BE Flex"  },
                new Classroom { ClassName = "FE Focus" }
            );
            _db.SaveChanges();
        }
        else
        {
            foreach (var classroom in _db.Classrooms.ToList())
            {
                Console.WriteLine($"{classroom.Id}- Sınıf: {classroom.ClassName}");
            }
        }
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

    public static void ClassStudent()
    {
        ListStudents();
        Console.WriteLine();
        ListClass();
        Console.WriteLine();
        Console.Write("İşlem yapmak istediğiniz öğrenci:  ");
        var studentId = int.Parse(Console.ReadLine());
        
        Console.Write("Öğrenciyi eklemek istediğiniz sınıf: ");
        var classroomId = int.Parse(Console.ReadLine());
        Thread.Sleep(200);
        Console.WriteLine("Öğrenci sınıfa eklendi");
        
        var student = _db.Students
            .Include(c => c.Classrooms)
            .FirstOrDefault(s => s.Id == studentId);
        var classroom = _db.Classrooms.Find(classroomId);
        if (student != null && classroom != null != student.Classrooms.Contains(classroom))
        {
            student.Classrooms.Add(classroom);
        }
         _db.SaveChanges();
    }

    public static void ClassTeacher()
    {
        ListTeachers();
        Console.WriteLine();
        ListClass();
        Console.WriteLine();
        Console.Write("İşlem yapmak istediğiniz öğretmen:  ");
        var teacherId = int.Parse(Console.ReadLine());
        
        Console.Write("Öğretmeni eklemek istediğiniz sınıf: ");
        var classroomId = int.Parse(Console.ReadLine());
        Thread.Sleep(200);
        Console.WriteLine("Öğretmen sınıfa eklendi");
        
        var teacher = _db.Teachers
            .Include(c => c.Classrooms)
            .FirstOrDefault(s => s.Id == teacherId);
        var classroom = _db.Classrooms.Find(classroomId);
        if (teacher != null && classroom != null != teacher.Classrooms.Contains(classroom))
        {
            teacher.Classrooms.Add(classroom);
        }
        _db.SaveChanges();
    }

    public static void ClassStudentShow()
    {
        var classroomList = _db
            .Classrooms
            .Include(s => s.Students)
            .ToList();

        foreach (var classroom in classroomList)
        {
            Console.WriteLine($"{classroom.Id} - {classroom.ClassName}");
            {
                foreach (var student in classroom.Students)
                {
                    Console.WriteLine($"{student.Id} - {student.Name} {student.Surname}");
                }
                Console.WriteLine();
            }
        }
    }

    public static void ClassTeacherShow()
    {
        var classroomList = _db
            .Classrooms
            .Include(t => t.Teachers)
            .ToList();

        foreach (var classroom in classroomList)
        {
            Console.WriteLine($"{classroom.Id} - {classroom.ClassName}");
            {
                foreach (var teacher in classroom.Teachers)
                {
                    Console.WriteLine($"{teacher.Id} - {teacher.Name} {teacher.Surname}");
                }
                Console.WriteLine();
            }
        }
    }

    
}