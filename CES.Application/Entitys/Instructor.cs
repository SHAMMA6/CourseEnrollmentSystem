using CES.Application.Common.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CES.Application.Entitys
{
    public class Instructor : IEntity
    {
        
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Course> Courses { get; set; }
    }

    public class InstracturValidator : AbstractValidator<Instructor>
    {
        public InstracturValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(2, 40).NotNull();
        }

    }
}

