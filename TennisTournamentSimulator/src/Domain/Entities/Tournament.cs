using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Tournament : AuditableEntity
    {
        public TournamentType Type { get; set; }
        public TournamentStatus Status { get; set; }
        public int? WinnerId { get; set; }
        public Player Winner { get; set; }
        public DateTime Date { get; set; }
        public List<Player> Players { get => this.PlayerTournaments.Select(pt => pt.Player).ToList(); }
        public List<PlayerTournament> PlayerTournaments { get; set; } = new List<PlayerTournament>();
    }
}
