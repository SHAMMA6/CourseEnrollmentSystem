using CES.Application.Common.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace CES.Application.Entitys
{
    public class Department : IEntity
    {
        
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }


    }


    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(5, 80);
        }
    }
}
