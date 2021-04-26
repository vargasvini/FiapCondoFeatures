using CondoFeatures.Data.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace CondoFeatures.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IPingRepository _pingRepository;

        public PingController(IPingRepository pingRepository)
        {
            _pingRepository = pingRepository;
        }

        [HttpGet]
        [SwaggerOperation(
          Summary = "Retorna PONG",
          Description = "Endpoint para teste, retorna PONG",
          OperationId = "Get"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Get()
        {
            return Ok(await _pingRepository.Pong());
        }
    }
}
