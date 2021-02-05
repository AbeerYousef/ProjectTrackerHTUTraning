using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<ProjectManager> ProjectManagers { get; set; }
        public virtual DbSet<TeamLeader> TeamLeaders { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<ProjectDeveloper> ProjectDevelopers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<SprintTask> SprintTasks { get; set; }
        public virtual DbSet<Work> Works { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  //on base
            modelBuilder.Entity<ProjectDeveloper>().HasKey(x => new { x.ProjectId, x.DeveloperId });

        }
    }
}
