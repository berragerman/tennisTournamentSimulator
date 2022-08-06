using Application.Player.Command.Create;
using Application.Player.Command.Delete;
using Application.Player.Command.Update;
using Application.Player.Queries;
using Application.Player.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ApiControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PlayerDTO[]>> GetAll(string name)
        {
            return await Mediator.Send(new GetAllPlayersQuery() { 
                Name = name
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await Mediator.Send(new DeletePlayerCommand() { Id = id });
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePlayerCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(UpdatePlayerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

    }
}