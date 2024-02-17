using Microsoft.EntityFrameworkCore;
using PruebaSICO.Model;

namespace PruebaSICO.DB
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options ):base(options)
        {            
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student  { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }


    }
}
