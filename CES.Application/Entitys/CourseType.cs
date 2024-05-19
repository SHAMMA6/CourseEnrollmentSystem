using CES.Application.Common.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CES.Application.Entitys
{
    public class CourseType : IEntity
    {
        
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }

    public class CourseTypeValidator : AbstractValidator<CourseType>
    {
        public CourseTypeValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(2, 40);
          
        }
    }
}

