using Microsoft.EntityFrameworkCore;
using Nikolaeva_kt_43_21.Database.Configurations;
using Nikolaeva_kt_43_21.Models;

namespace Nikolaeva_kt_43_21.Database
{
    public class TeacherDbContext : DbContext
    {
        DbSet<Cathedra> Cathedras { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Discipline> Disciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CathedraConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }
    }
}
