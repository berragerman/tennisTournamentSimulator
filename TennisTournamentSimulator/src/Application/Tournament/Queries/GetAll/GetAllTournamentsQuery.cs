using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tournament.Queries.GetAll
{
    public class GetAllTournamentsQuery : IRequest<TournamentDTO[]>
    {
        public string? Name { get; set; }
        public int? Winner { get; set; }
        public string? Type { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }

    public class GetAllTournamentQueryHandler : IRequestHandler<GetAllTournamentsQuery, TournamentDTO[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTournamentQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<TournamentDTO[]> Handle(GetAllTournamentsQuery request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                var query = _context.Tournaments
                                        .AsQueryable();

                if (!string.IsNullOrEmpty(request.Name))
                    query = query.Where(x => x.Name.Contains(request.Name));

                if (request.Winner.HasValue)
                    query = query.Where(x => x.Winner.Id == request.Winner.Value);

                if (request.From.HasValue && request.To.HasValue)
                    query = query.Where(x => x.Date <= request.From && x.Date >= request.To);

                if (!string.IsNullOrEmpty(request.Type))
                    query = query.Where(x => (Domain.Enums.TournamentType) Enum.Parse(typeof(Domain.Enums.TournamentType), request.Type) == x.Type);

                return query.OrderByDescending(p => p.Name)
                        .ProjectTo<TournamentDTO>(_mapper.ConfigurationProvider)
                        .ToArray();
            });
        }
    }
}
