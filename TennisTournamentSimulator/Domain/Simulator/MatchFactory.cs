
using Domain.Entities;
using Domain.Enums;

namespace Domain.Simulators
{
    public interface IMatchFactory {
        IMatch Create(TournamentType type, Player participantA, Player participantB);
    }
    public interface IMatch
    {
        Player Play();
    }

    public class MatchFactory: IMatchFactory
    {
        public IMatch Create(TournamentType type, Player participantA, Player participantB) {
            return type == TournamentType.Male ?
                new MaleMatch(participantA, participantB) : new FemaleMatch(participantA, participantB);
        }

        private abstract class Match : IMatch
        {
            public Player ParticipantA { get; private set; }
            public Player ParticipantB { get; private set; }
            public abstract Player Play();

            public Match(Player participantA, Player participantB)
            {
                ParticipantA = participantA;
                ParticipantB = participantB;
            }
        }

        private class MaleMatch : Match
        {
            public MaleMatch(Player participantA, Player participantB) : base(participantA, participantB)
            {
            }

            public override Player Play()
            {

                Player winner = null;

                while (winner == null)
                {
                    var participantAPoints = CalculatePoints(ParticipantA);
                    var participantBPoints = CalculatePoints(ParticipantB);

                    if (participantAPoints > participantBPoints)
                    {
                        winner = ParticipantA;
                    }
                    else if (participantBPoints > participantAPoints)
                    {
                        winner = ParticipantB;
                    }
                }

                return winner;

            }

            private int CalculatePoints(Player participant)
            {

                Random random = new Random();

                bool hasLucky = random.Next(1, 20) + participant.Lucky >= 20;

                int points = participant.Abillity + participant.Strength + participant.Speed;

                if (hasLucky)
                {
                    points *= 2;
                }

                return points;

            }

        }
        private class FemaleMatch : Match
        {
            public FemaleMatch(Player participantA, Player participantB) : base(participantA, participantB)
            {
            }

            public override Player Play()
            {

                Player winner = null;

                while (winner == null)
                {
                    var participantAPoints = CalculatePoints(ParticipantA);
                    var participantBPoints = CalculatePoints(ParticipantB);

                    if (participantAPoints > participantBPoints)
                    {
                        winner = ParticipantA;
                    }
                    else if (participantBPoints > participantAPoints)
                    {
                        winner = ParticipantB;
                    }
                }

                return winner;

            }

            private int CalculatePoints(Player participant)
            {

                Random random = new Random();

                bool hasLucky = random.Next(1, 20) + participant.Lucky >= 20;

                int points = participant.Abillity + participant.Reaction;

                if (hasLucky)
                {
                    points *= 2;
                }

                return points;

            }

        }
    }

}
