using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournamentSimulator.Domain.Entities;

namespace TennisTournamentSimulator.Domain.Simulators
{
    public interface IMatchFactory {
        IMatch Create(TournamentType type, Player ParticipantA, Player ParticipantB);
    }
    public class MatchFactory: IMatchFactory
    {
        public IMatch Create(TournamentType type, Player ParticipantA, Player ParticipantB) {
            throw new NotImplementedException();
        }
    }
}
