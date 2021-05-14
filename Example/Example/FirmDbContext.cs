using Example.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Example
{
    public class FirmDbContext : DbContext
    {
        
        public FirmDbContext(DbContextOptions<FirmDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> tblEmployees { get; set; }        
        public DbSet<Job> tblJobs { get; set; }
        public DbSet<JobAvailability> tblJobAvailabilities { get; set; }
        public DbSet<JobType> tblJobTypes { get; set; }        
        public DbSet<Manager> tblManagers { get; set; }
        public DbSet<ManagerType> tblManagerTypes { get; set; }
        public DbSet<Skill> tblSkills { get; set; }
        public DbSet<JobTypeSkill> tblJobTypeSkills { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .ToTable("tblEmployees");
            modelBuilder
                .Entity<Job>()
                .ToTable("tblJobs");
            modelBuilder
                .Entity<JobAvailability>()
                .ToTable("tblJobAvailabilities");
            modelBuilder
                .Entity<JobType>()
                .ToTable("tblJobTypes");                
            modelBuilder
                .Entity<JobType>()
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder
                .Entity<Manager>()
                .ToTable("tblManagers");
            modelBuilder
                .Entity<Employee>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder
                .Entity<ManagerType>()
                .ToTable("tblManagerTypes");
            modelBuilder
                .Entity<ManagerType>()
                .HasData(new ManagerType { Id = 1, TypeName = "Full-Time" },
                         new ManagerType { Id = 2, TypeName = "Part-Time" },
                         new ManagerType { Id = 3, TypeName = "Over-Time" });
            modelBuilder
                .Entity<Skill>()               
                .ToTable("tblSkills");
            modelBuilder
                  .Entity<Skill>()
                  .HasIndex(u => u.Name)
                  .IsUnique();
            modelBuilder
                .Entity<Skill>()
                .HasData(new Skill { Id = 1, Name = "[.NET]" });
            modelBuilder
                .Entity<JobTypeSkill>()
                .ToTable("tblJobTypeSkills");
        }

    }
}
