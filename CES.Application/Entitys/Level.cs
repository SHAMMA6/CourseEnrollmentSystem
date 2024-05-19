using CES.Application.Common.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CES.Application.Entitys
{
    public class Level : IEntity
    {
        
        public string Name { get; set; }
        public int MinCredits { get; set; }
        public int MaxCredits { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

    }

    public class LevelValidator : AbstractValidator<Level>
    {
        public LevelValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(2, 40).NotNull();
            RuleFor(x => x.MinCredits).ExclusiveBetween(1, 500);
            RuleFor(x => x.MaxCredits).ExclusiveBetween(1, 500);
        }
    }

}