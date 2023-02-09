using Microsoft.EntityFrameworkCore;

namespace SchoolMaris.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Level> Level{ get; set; }
        public DbSet<LevelSubject> LevelSubject { get; set; }
        public DbSet<Section> Section { get; set; }
    }
}
