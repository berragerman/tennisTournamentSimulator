using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tournament.Command.Create
{
    public class CreateTournamentCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public Domain.Enums.TournamentType Type { get; set; }

        public int[] Players { get; set; }
    }

    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTournamentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            var tournament = new Domain.Entities.Tournament()
            {
                Name = request.Name,
                Type = request.Type,
                Status = Domain.Enums.TournamentStatus.Pending,
                Players = request.Players.Select(id => new Domain.Entities.Player() { Id = id }).ToArray()
            };

            _context.Tournaments.Add(tournament);

            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
