using Application.Common.Mappings;
using Application.Player.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tournament.Queries
{
    public class TournamentDTO : IMapFrom<Domain.Entities.Tournament>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public PlayerDTO Players { get; set; }

        public PlayerDTO Winner { get; set; }

        public bool Inactive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.Tournament, TournamentDTO>()
                .ForMember(t => t.Status, opt => opt.MapFrom(t => Enum.GetName(typeof(Domain.Enums.TournamentStatus), t.Status )))
                .ForMember(t => t.Type, opt => opt.MapFrom(t =>  Enum.GetName(typeof(Domain.Enums.TournamentType), t.Type)))
                .ForMember(t => t.CreatedAt, opt => opt.MapFrom(p => p.Created))
                .ForMember(t => t.UpdatedAt, opt => opt.MapFrom(p => p.Updated));
        }
    }
}
