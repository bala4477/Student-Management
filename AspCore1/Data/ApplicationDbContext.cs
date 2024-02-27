using AspCore1.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCore1.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Marks> marks { get; set; }
    }
}
