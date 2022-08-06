using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Command.Delete
{
    public class DeletePlayerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeletePlayerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Players.FindAsync(request.Id);

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
