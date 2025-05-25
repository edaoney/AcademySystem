using AcademySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademySystem.Data;

public class AppDbContext : DbContext
{
   
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost;Database=AcademySystem;Trusted_Connection=True;TrustServerCertificate=True;");
    }
   
}