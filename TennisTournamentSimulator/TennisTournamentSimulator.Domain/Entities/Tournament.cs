using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournamentSimulator.Domain.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public TournamentType Type { get; set; }
        public TournamentStatus Status { get; set; }
        public Player[] Players { get; set; }
        public Player Winner { get; set; }
        public DateTime Date { get; set; }
    }
}
