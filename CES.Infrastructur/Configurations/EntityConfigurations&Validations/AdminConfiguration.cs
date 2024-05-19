using CES.Application.Entitys;
using CES.Infrastructur.Configurations.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CES.Infrastructur.Configurations.EntityConfigurations
{
    public class AdminConfiguration : IEntityConfiguration<Admin> 
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
           
        }
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
