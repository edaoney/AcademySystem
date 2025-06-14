﻿
using AcademySystem;

class Program
{
    private static ConsoleMenu _consoleMenu = new("AKADEMİ YÖNETİMİ");

     static void Main()
     {
         _consoleMenu
             .AddMenu("Öğrenci Yönetimi", StudentMenu)
             .AddMenu("Öğretmen Yönetim", TeacherMenu)
             .AddMenu("Sınıf Yönetimi", ClassMenu);
        _consoleMenu.Show();


    }

    static void StudentMenu()
    {
        var studentMenu = new ConsoleMenu("Öğrenci Yönetimi")
            .AddOption("Listele ", SecondHelper.ListStudents)
            .AddOption("Ekle ", SecondHelper.AddStudent)
            .AddOption("Sınıfa Ekle", SecondHelper.ClassStudent)
            .AddOption("Sınıfları göster ", SecondHelper.ClassStudentShow);
        
        studentMenu.Show();
        
    }

    static void TeacherMenu()
    {
        var teacherMenu = new ConsoleMenu("Öğretmen Yönetimi")
            .AddOption("Listele ", SecondHelper.ListTeachers)
            .AddOption("Ekle ", SecondHelper.AddTeacher)
            .AddOption("Sınıfa Ekle", SecondHelper.ClassTeacher)
            .AddOption("Sınıfları göster ", SecondHelper.ClassTeacherShow);
        teacherMenu.Show();

    }

    static void ClassMenu()
    {
        var classMenu = new ConsoleMenu("Sınıf Yönetimi")
            .AddOption("Listele",SecondHelper.ListClass)
            .AddOption("Ekle",SecondHelper.AddClass);
        classMenu.Show();
        
    }
    
    

}