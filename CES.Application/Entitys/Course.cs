using CES.Application.Common.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CES.Application.Entitys
{
    public class Course : IEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int CourseTypeId { get; set; } 
        public CourseType CourseType { get; set; } 
        public List<StudentCourse> StudentCourses { get; set; }

    }

    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(2, 40);
            RuleFor(x => x.Description).MaximumLength(400);
            RuleFor(x => x.CreditHours).ExclusiveBetween(5, 50);
        }
    }
}
