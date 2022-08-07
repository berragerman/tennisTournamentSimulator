using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tournament.Command.Delete
{
    public class DeleteTournamentCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteTournamentCommandHandler : IRequestHandler<DeleteTournamentCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTournamentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tournaments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Player), request.Id);
            }

            entity.Inactive = true;
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
