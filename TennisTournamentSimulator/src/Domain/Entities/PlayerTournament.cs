using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlayerTournament : AuditableEntity
    {
        public int PlayerId { get; set; }
        public int TournamentId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Tournament Tournament { get; set; }

    }
}
