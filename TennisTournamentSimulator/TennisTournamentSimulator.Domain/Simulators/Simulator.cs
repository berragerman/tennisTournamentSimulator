using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournamentSimulator.Domain.Entities;
using TennisTournamentSimulator.Domain.Enums;
using TennisTournamentSimulator.Domain.Exceptions;

namespace TennisTournamentSimulator.Domain.Simulators
{
    public class Simulator 
    {
        private IMatchFactory matchFactory;
        public Simulator(IMatchFactory matchFactory)
        {
            this.matchFactory = matchFactory;
        }
        public Player Play(Tournament tournament) {

            if (tournament.Status != TournamentStatus.Pending)
                throw new InvalidTournamentException();

            if (tournament.Players == null ||
                !tournament.Players.Any() ||
                (Math.Sqrt(tournament.Players.Count()) % 1) != 0)
                throw new WrongNumberOfPlayersException();
            
            IMatch[] matches = BuildMatches(tournament.Type, tournament.Players);

            while (matches.Length != 1)
            {
               matches = BuildMatches(tournament.Type, matches.Select(m => m.Play()).ToArray());
            }

            Player winner = matches[0].Play();

            return winner;
        }

        private IMatch[] BuildMatches( TournamentType type, Player[] participants) { 
            
            List<IMatch> matches = new List<IMatch>();
            for (int i = 0; i < participants.Length/2; i++)
            {
                matches.Add(matchFactory.Create(type, participants[i * 2], participants[(i * 2) + 1]));
            }

            return matches.ToArray();

        }


    }
}
