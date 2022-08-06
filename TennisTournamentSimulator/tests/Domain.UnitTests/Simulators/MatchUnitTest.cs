using Domain.Entities;
using Domain.Enums;
using Domain.Simulators;

namespace TennisTournamentSimulator.UnitTest.Simulators
{
    public class MatchUnitTest
    {
        private MatchFactory _matchFactory;
        public MatchUnitTest()
        {
            _matchFactory = new MatchFactory();
        }

        [Fact]
        public void ParticipantWithMorePointsShouldWinOnMaleMatch() {
            var participantA = new Player()
            {
                Name = "Participant A",
                Ability = 50,
                Speed = 60,
                Strength = 30
            };

            var participantB = new Player()
            {
                Name = "Participant B",
                Ability = 30,
                Speed = 20,
                Strength = 80
            };

            var match = _matchFactory.Create(TournamentType.Male, participantA, participantB);

            var winner = match.Play();

            Assert.Equal(participantA, winner);
        }

        [Fact]
        public void ParticipantWithMorePointsShouldWinOnFemaleMatch()
        {
            var participantA = new Player()
            {
                Name = "Participant A",
                Ability = 50,
                Reaction = 30
            };

            var participantB = new Player()
            {
                Name = "Participant B",
                Ability = 30,
                Reaction = 80
            };

            var match = _matchFactory.Create(TournamentType.Female, participantA, participantB);

            var winner = match.Play();

            Assert.Equal(participantB, winner);
        }


        [Fact]
        public void PartcipantWithLuckyShouldWinOnMaleMatch() {

            var participantWithoutLuck = new Player()
            {
                Name = "Unlucky participant",
                Lucky = 0,
                Ability = 40,
                Speed = 30,
                Strength = 50,
                Reaction = 40
            };

            var participantWithLuck = new Player()
            {
                Name = "Lucky participant",
                Lucky = 100,
                Ability = 30,
                Speed = 30,
                Strength = 40,
                Reaction = 10
            };

            var match = _matchFactory.Create( TournamentType.Male, participantWithoutLuck, participantWithLuck);

            var winner = match.Play();

            Assert.Equal(participantWithLuck, winner);

        }

        [Fact]
        public void PartcipantWithLuckyShouldWinOnFemaleMatch()
        {

            var participantWithoutLuck = new Player()
            {
                Name = "Unlucky participant",
                Lucky = 0,
                Ability = 40,
                Speed = 30,
                Strength = 50,
                Reaction = 40
            };

            var participantWithLuck = new Player()
            {
                Name = "Lucky participant",
                Lucky = 100,
                Ability = 30,
                Speed = 30,
                Strength = 40,
                Reaction = 15
            };

            var match = _matchFactory.Create(TournamentType.Female, participantWithoutLuck, participantWithLuck);

            var winner = match.Play();

            Assert.Equal(participantWithLuck, winner);

        }
    }
}
