using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tournament.Command.Update
{

    public class UpdateTournamentCommandValidator : AbstractValidator<UpdateTournamentCommand>
    {

        public UpdateTournamentCommandValidator()
        {
            
            RuleFor(v => v.Name)
                .MinimumLength(10)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(v => v.Type)
                .IsInEnum();

            RuleFor(v => v.Players)
                .NotEmpty();
        }
    }
}
