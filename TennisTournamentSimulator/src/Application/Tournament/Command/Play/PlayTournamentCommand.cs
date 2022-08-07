using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Player.Queries;
using AutoMapper;
using Domain.Simulators;
using MediatR;

namespace Application.Tournament.Command.Play
{
    public class PlayTournamentCommand : IRequest<PlayerDTO>
    {
        public int TournamentId { get; set; }
    }

    public class PlayTournamentCommandhandler : IRequestHandler<PlayTournamentCommand, PlayerDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISimulator _simulator;
        private readonly IMapper _mapper;

        public PlayTournamentCommandhandler(IApplicationDbContext context, ISimulator simulator, IMapper mapper)
        {
            _context = context;
            _simulator = simulator;
            _mapper = mapper;
        }
        public async Task<PlayerDTO> Handle(PlayTournamentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tournaments.FindAsync(request.TournamentId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Tournament), request.TournamentId);
            }

            var winner = _simulator.Play(entity);

            entity.Winner = winner;
            entity.Status = Domain.Enums.TournamentStatus.Finished;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PlayerDTO>(winner);
        }
    }
}
