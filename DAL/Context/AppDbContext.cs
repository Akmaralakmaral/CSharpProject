
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL.Context
{
    public class AppDbContext : DbContext
    {
        private static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public AppDbContext() { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Domain.Models.Entities.Task> Tasks { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory) // Добавьте эту строку для включения логирования
                         .UseSqlServer("Data Source=DESKTOP-40QVERS;Initial Catalog=AAProjectManagement;User ID=sa;Password=2004;TrustServerCertificate=true");

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Определение отношения "многие-ко-многим" между Project и Employee
            modelBuilder.Entity<Project>()
              .HasMany(p => p.Employees)
              .WithMany(e => e.Projects)
              .UsingEntity<ProjectEmployee>(
                  j => j
                      .HasOne(pe => pe.Employee)
                      .WithMany()
                      .HasForeignKey(pe => pe.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict),
                  j => j
                      .HasOne(pe => pe.Project)
                      .WithMany()
                      .HasForeignKey(pe => pe.ProjectId)
                      .OnDelete(DeleteBehavior.Restrict)
              );

            // Определение отношения "один-ко-многим" между Project и Task
            modelBuilder.Entity<Project>()
                 .HasMany(p => p.Tasks)
                 .WithOne(t => t.Project)
                 .HasForeignKey(t => t.ProjectId);

            // Определение отношений "один-к-одному" с Company

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId);

            ///////////////////////////////////////////////////

            modelBuilder.Entity<Project>()
                .HasOne(p => p.CustomerCompany)
                .WithMany()
                .HasForeignKey(p => p.CustomerCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ExecutorCompany)
                .WithMany()
                .HasForeignKey(p => p.ExecutorCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AuthoredTasks)
                .WithOne(t => t.Author)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AssignedTasks)
                .WithOne(t => t.Assignee)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

