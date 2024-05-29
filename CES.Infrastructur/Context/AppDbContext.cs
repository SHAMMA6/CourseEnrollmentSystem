using CES.Application.Entitys;
using CES.Infrastructur.Configurations.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Infrastructur.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Apply configurations for other entities
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);



            // Make Restrict By Default
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
