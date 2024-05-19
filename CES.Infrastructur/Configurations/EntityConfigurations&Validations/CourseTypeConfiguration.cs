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
    public class CourseTypeConfiguration : IEntityConfiguration<CourseType>
    {
        public void Configure(EntityTypeBuilder<CourseType> builder)
        {
           
        }
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
