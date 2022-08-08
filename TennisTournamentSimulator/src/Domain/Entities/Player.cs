using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Player : AuditableEntity
    {
        public int Ability { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Reaction { get; set; }
        public int Lucky { get; set; }
        [NotMapped]
        public ICollection<Tournament> Tournaments { get; set; }
        public List<PlayerTournament> PlayerTournaments { get; set; }
    }
}
