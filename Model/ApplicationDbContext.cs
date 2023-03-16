using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<LevelSection> LevelSection { get; set; }
        public DbSet<LevelSectionTeacher> LevelSectionTeacher { get; set; }
        public DbSet<LevelSubjectTeacher> LevelSubjectTeacher { get; set; }
        public DbSet<PupilsProfile> PupilsProfile { get; set; }
        public DbSet<EnrolmentProfile> EnrolmentProfile { get; set; }
        public DbSet<Credentials> Credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
