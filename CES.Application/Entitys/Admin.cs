using CES.Application.Common.Interfaces;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace CES.Application.Entitys
{
    public class Admin : IEntity
    {
        
        public string AdminName { get; set; }

    }

    

    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.AdminName).Length(2, 40);
        }
    }


}
