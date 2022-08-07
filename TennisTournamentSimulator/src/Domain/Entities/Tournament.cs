using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Tournament : AuditableEntity
    {
        public TournamentType Type { get; set; }
        public TournamentStatus Status { get; set; }
        public Player Winner { get; set; }
        public DateTime Date { get; set; }
        public List<Player> Players { get; set; }
        public ICollection<PlayerTournament> PlayerTournaments { get; set; }
    }
}
