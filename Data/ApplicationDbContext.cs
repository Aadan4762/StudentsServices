using Microsoft.EntityFrameworkCore;
using StudentsServices.Models.Entities;

namespace StudentsServices.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Student> Students { get; set; }
}