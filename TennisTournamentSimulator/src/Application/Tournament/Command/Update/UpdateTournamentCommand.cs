using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tournament.Command.Update
{
    public class UpdateTournamentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Domain.Enums.TournamentType Type { get; set; }

        public int[] Players { get; set; }

        public bool Inactive { get; set; }
    }

    public class UpdateTournamentCommandHandler : IRequestHandler<UpdateTournamentCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateTournamentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tournaments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Tournament), request.Id);
            }

            entity.Name = request.Name;
            entity.Type = request.Type;
            entity.Players = request.Players.Select(id => new Domain.Entities.Player() { Id = id }).ToArray();
            entity.Inactive = request.Inactive;


            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
