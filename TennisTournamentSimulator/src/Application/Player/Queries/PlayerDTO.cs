using Application.Common.Mappings;

namespace Application.Player.Queries
{
    public class PlayerDTO : IMapFrom<Domain.Entities.Player>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Ability { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Reaction { get; set; }
        public int Lucky { get; set; }
        public bool Inactive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Mapping(MappingProfile profile) 
        {
            profile.CreateMap<Domain.Entities.Player, PlayerDTO>()
                .ForMember(p => p.CreatedAt, opt => opt.MapFrom(p => p.Created))
                .ForMember(p => p.UpdatedAt, opt => opt.MapFrom(p => p.Updated));
        }
    }
}
