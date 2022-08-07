using Moq;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Simulators;

namespace TennisTournamentSimulator.UnitTest.Simulators
{
    public class SimulatorUnitTest
    {
        private Mock<IMatchFactory> mockMatchFactory;
        public SimulatorUnitTest()
        {
            mockMatchFactory = new Mock<IMatchFactory>();
        }

        [Fact]
        public void InvalidTournamentShouldThrowInvalidTournamentException() {

            /// Arrange
            var tournament = new Tournament() {
                Status = TournamentStatus.Finished
            };
            var simulator = new Simulator(mockMatchFactory.Object);

            /// Act
            var act = () => simulator.Play(tournament);
            /// Assert
            Assert.Throws<InvalidTournamentException>(act);

        }

        [Fact]
        public void NoParticipantsShouldThrowWrongNumberOfPlayersException()
        {

            /// Arrange
            var tournament = new Tournament()
            {
                Status = TournamentStatus.Pending,
                Players = new List<Player>()
            };
            var simulator = new Simulator(mockMatchFactory.Object);

            /// Act
            var act = () => simulator.Play(tournament);
            /// Assert
            Assert.Throws<WrongNumberOfPlayersException>(act);

        }

        [Fact]
        public void WrongNumberOfParticipantsShouldThrowWrongNumberOfPlayersException()
        {

            /// Arrange
            var tournament = new Tournament()
            {
                Status = TournamentStatus.Pending,
                Players = new List<Player>() { 
                    new Player(),
                    new Player(),
                    new Player()
                }
            };
            var simulator = new Simulator(mockMatchFactory.Object);

            /// Act
            var act = () => simulator.Play(tournament);
            /// Assert
            Assert.Throws<WrongNumberOfPlayersException>(act);

        }

        [Fact]
        public void CorrectNumberOfParticipantsShouldReturnAWinner() {

            /// Arrange
            var player1 = new Player()
            {
                Name = "Player 1"
            };
            var player2 = new Player()
            {
                Name = "Player 2",
            };
            var player3 = new Player()
            {
                Name = "Player 3"
            };
            var player4 = new Player()
            {
                Name = "Player 4"
            };


            var tournament = new Tournament()
            {
                Status = TournamentStatus.Pending,
                Type = TournamentType.Male,
                Players = new List<Player>() {
                    player1,
                    player2,
                    player3,
                    player4
                }
            };

            Func<TournamentType, Player, Player, IMatch> f = (t, p1, p2) =>
            {
                var mock = new Mock<IMatch>();
                mock
                .Setup((m) => m.Play())
                .Returns(() => p2);

                return mock.Object;
            };
                    
            mockMatchFactory
                .Setup((mf) => mf.Create(It.IsAny<TournamentType>(), It.IsAny<Player>(), It.IsAny<Player>()))
                .Returns(f);

            var simulator = new Simulator(mockMatchFactory.Object);

            /// Act

            var winner = simulator.Play(tournament);

            /// Assert
            Assert.NotNull(winner);
            Assert.Equal(expected: "Player 4", winner.Name);
        }

    }
}
