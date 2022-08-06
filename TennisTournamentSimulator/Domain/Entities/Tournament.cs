using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Tournament : AuditableEntity
    {
        public TournamentType Type { get; set; }
        public TournamentStatus Status { get; set; }
        public Player[] Players { get; set; }
        public Player Winner { get; set; }
        public DateTime Date { get; set; }
    }
}
