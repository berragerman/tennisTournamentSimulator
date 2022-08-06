using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Player.Queries.Get
{
    public class GetAllPlayersQuery: IRequest<PlayerDTO[]>
    {
        public string Name { get; set; } = string.Empty;
    }

    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, PlayerDTO[]>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPlayersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<PlayerDTO[]> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                var query = _context.Players.AsQueryable();

                if (!string.IsNullOrEmpty(request.Name))
                    query = query.Where(x => x.Name.Contains(request.Name));


                return query.OrderByDescending(p => p.Name)
                        .ProjectTo<PlayerDTO>(_mapper.ConfigurationProvider)
                        .ToArray();
            });
        }
    }
}
