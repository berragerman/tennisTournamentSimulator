using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Command.Create
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator()
        {
            RuleFor(v => v.Ability)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

            RuleFor(v => v.Strength)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);
            
            RuleFor(v => v.Speed)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

            RuleFor(v => v.Reaction)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

            RuleFor(v => v.Lucky)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

            RuleFor(v => v.Name)
                .MinimumLength(10)
                .MaximumLength(100)
                .NotEmpty();

        }
    }
}
