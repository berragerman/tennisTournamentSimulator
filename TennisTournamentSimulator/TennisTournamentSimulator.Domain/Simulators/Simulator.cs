using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournamentSimulator.Domain.Entities;
using TennisTournamentSimulator.Domain.Exceptions;

namespace TennisTournamentSimulator.Domain.Simulators
{
    public class Simulator 
    {
        private MatchFactory matchFactory;
        public Simulator(MatchFactory matchFactory)
        {
            this.matchFactory = matchFactory;
        }
        public Player Play(Tournament tournament) {

            if (tournament.Status != TournamentStatus.Pending)
                throw new InvalidTournamentException();

            if (tournament.Players.Any())
                throw new WrongNumberOfPlayersException();

            
            
            Match[] matches = BuildMatches(tournament.Type, tournament.Players);

            while (matches.Length != 1)
            {
               matches = BuildMatches(tournament.Type, matches.Select(m => m.Play()).ToArray());
            }

            Player winner = matches[0].Play();

            return winner;
        }

        private Match[] BuildMatches( TournamentType type, Player[] participants) { 
            
            List<Match> matches = new List<Match>();
            for (int i = 0; i < participants.Length/2; i++)
            {
                matches.Add(matchFactory.Create(type, participants[i * 2], participants[(i * 2) + 1]));
            }

            return matches.ToArray();

        }


    }
}
