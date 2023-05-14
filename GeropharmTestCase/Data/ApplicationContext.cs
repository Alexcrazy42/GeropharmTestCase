using Microsoft.EntityFrameworkCore;
using GeropharmTestCase.Models;
using System.Configuration;

namespace GeropharmTestCase.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }



        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            List<Project> projects = new List<Project>();
            for (int i = 0; i < 300; i++)
            {
                modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = i+1,
                    Name = "Project" + (i + 1).ToString(),
                    Description = "Description" + (i + 1).ToString()
                });
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                string DbPath = System.IO.Path.Join(path, "Db.db");
                optionsBuilder.UseSqlite($"Data Source=Db.db");
            } 
        }
    }
}
