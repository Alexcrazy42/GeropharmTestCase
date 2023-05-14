using Microsoft.EntityFrameworkCore;
using GeropharmTestCase.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = "Host=localhost; Port = 5432; Database=VK; Username=postgres; Password=26031974yula;";
                optionsBuilder.UseNpgsql(connection);
                optionsBuilder.EnableSensitiveDataLogging();
                

            }
            else
            {
                var db = new ApplicationContext();
                if (db.Projects.Count() == 0)
                {
                    var firstProject = new Project()
                    {
                        Name = "Project" + 1.ToString(),
                        Description = "Description" + 1.ToString()
                    };
                    db.Add(firstProject);
                    db.SaveChanges();
                    for (int i = 0; i < 149; i++)
                    {
                        var lastProject = db.Projects
                                .OrderByDescending(p => p.Id)
                                .FirstOrDefault();
                        var newProject = new Project()
                        {

                            Name = "Project" + (lastProject.Id + 1).ToString(),
                            Description = "Description" + (lastProject.Id + 1).ToString()
                        };
                        db.Add(newProject);
                        db.SaveChanges();

                    }
                }
                

            }
        }
    }
}
