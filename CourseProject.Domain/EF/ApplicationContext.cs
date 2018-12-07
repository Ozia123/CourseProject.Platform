using CourseProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Domain.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pattern> Patterns { get; set; }
        public DbSet<GlossaryItem> GlossaryItems { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
        }
    }
}
