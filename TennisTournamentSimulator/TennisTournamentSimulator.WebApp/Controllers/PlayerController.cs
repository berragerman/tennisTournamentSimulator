using Microsoft.AspNetCore.Mvc;
using TennisTournamentSimulator.WebApp.Dto;

namespace TennisTournamentSimulator.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        public PlayerController()
        {

        }
        
        [HttpGet(Name = "GetPlayers")]
        public IEnumerable<PlayerDTO> GetAll()
        {
            
        }
    }
}