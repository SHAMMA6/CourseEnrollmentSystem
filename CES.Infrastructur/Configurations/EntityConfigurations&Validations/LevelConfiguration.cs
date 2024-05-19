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
    public class LevelConfiguration : IEntityConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {

        }
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
