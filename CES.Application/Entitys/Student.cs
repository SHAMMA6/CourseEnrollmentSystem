using CES.Application.Common.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CES.Application.Entitys
{
    public class Student : IEntity
    {
        
        public string Name { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }

    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(2, 40).NotNull();
        }
    }
}
