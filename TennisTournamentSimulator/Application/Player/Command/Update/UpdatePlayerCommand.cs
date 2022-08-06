using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Command.Update
{
    public class UpdatePlayerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ability { get; set; }
        public int Reaction { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Lucky { get; set; }
        public bool Inactive { get; set; }
    }

    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdatePlayerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Players.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Player), request.Id);
            }

            entity.Name = request.Name;
            entity.Abillity = request.Ability;
            entity.Reaction = request.Reaction;
            entity.Speed = request.Speed;
            entity.Strength = request.Strength;
            entity.Inactive = request.Inactive;


            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
