using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournamentSimulator.Domain.Entities
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;
        public int Abillity { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Reaction { get; set; }
        public int Lucky { get; set; }
    }
}
