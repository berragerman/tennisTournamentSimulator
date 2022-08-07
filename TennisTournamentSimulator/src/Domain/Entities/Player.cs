using Domain.Common;

namespace Domain.Entities
{
    public class Player : AuditableEntity
    {
        public int Ability { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Reaction { get; set; }
        public int Lucky { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public ICollection<PlayerTournament> PlayerTournaments { get; set; }
    }
}
