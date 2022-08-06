using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Command.Create
{
    public class CreatePlayerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Ability { get; set; }
        public int Reaction { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Lucky { get; set; }

    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePlayerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Domain.Entities.Player()
            {
                Name = request.Name,
                Ability = request.Ability,
                Reaction = request.Reaction,
                Speed = request.Speed,
                Strength = request.Strength,
                Lucky = request.Lucky,
            };
            
            _context.Players.Add(player);

            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
