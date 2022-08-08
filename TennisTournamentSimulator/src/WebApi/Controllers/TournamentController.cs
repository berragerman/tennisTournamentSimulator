using Application.Player.Command.Create;
using Application.Player.Command.Delete;
using Application.Player.Command.Update;
using Application.Player.Queries;
using Application.Tournament.Command.Create;
using Application.Tournament.Command.Delete;
using Application.Tournament.Command.Play;
using Application.Tournament.Command.Update;
using Application.Tournament.Queries;
using Application.Tournament.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ApiControllerBase
    {
        private readonly ILogger<TournamentController> _logger;

        public TournamentController(ILogger<TournamentController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<TournamentDTO[]>> GetAll(string? name, string? type , int? winnerId, 
                                                                DateTime? from, DateTime? to )
        {
            return await Mediator.Send(new GetAllTournamentsQuery() { 
                Name = name,
                From = from,
                To = to,
                Type = type,
                Winner = winnerId
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await Mediator.Send(new DeleteTournamentCommand() { Id = id });
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTournamentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]/{tournamentId}")]
        public async Task<ActionResult<PlayerDTO>> Play(int tournamentId)
        {
            return await Mediator.Send(new PlayTournamentCommand() { TournamentId = tournamentId });
        }
        [HttpPut("[action]")]
        public async Task<ActionResult> Update(UpdateTournamentCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

    }
}