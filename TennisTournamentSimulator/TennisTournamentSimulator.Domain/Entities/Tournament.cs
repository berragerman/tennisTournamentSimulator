using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournamentSimulator.Domain.Enums;

namespace TennisTournamentSimulator.Domain.Entities
{
    public class Tournament : BaseEntity
    {
        public TournamentType Type { get; set; }
        public TournamentStatus Status { get; set; }
        public Player[] Players { get; set; }
        public Player Winner { get; set; }
        public DateTime Date { get; set; }
    }
}
