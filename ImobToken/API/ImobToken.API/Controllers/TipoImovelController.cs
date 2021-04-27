using ImobToken.Data.Repository.Interface;
using ImobToken.Domain;
using ImobToken.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace ImobToken.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoImovelController : ControllerBase
    {
        private readonly ITipoImovelRepository _tipoImovelRepository;

        public TipoImovelController(ITipoImovelRepository tipoImovelRepository)
        {
            _tipoImovelRepository = tipoImovelRepository;
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Cadastra um novo tipo de imóvel.",
            Description = "Endpoint para cadastrar um tipo de imovel",
            OperationId = "Post"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] TipoImovelDTO tipoImovelDTO)
        {
            TipoImovel tipoImovel = new TipoImovel(
                tipoImovelDTO.Nome
            );

            try
            {
                await _tipoImovelRepository.Insert(tipoImovel);
                return StatusCode(201, tipoImovel);
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Retorna todos os tipos de imóveis cadastrados.",
            Description = "Endpoint para retornar todos os tipos de imóveis.",
            OperationId = "Get"
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoImovel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoImovelRepository.GetAll());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{idTipoImovel}")]
        [SwaggerOperation(
            Summary = "Retorna um tipo de imóvel por Id.",
            Description = "Endpoint para retornar um tipo de imóvel por Id",
            OperationId = "GetById"
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoImovel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetById(int idTipoImovel)
        {
            try
            {
                return Ok(_tipoImovelRepository.GetById(idTipoImovel));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{idTipoImovel}")]
        [SwaggerOperation(
            Summary = "Remove um tipo de imóvel por Id.",
            Description = "Endpoint para remover um tipo de imóvel por Id",
            OperationId = "Delete"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int idTipoImovel)
        {
            try
            {
                return Ok(_tipoImovelRepository.DeleteById(idTipoImovel));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{idTipoImovel}")]
        [SwaggerOperation(
            Summary = "Atualiza um tipo de imóvel por Id.",
            Description = "Endpoint para atualizar um tipo de imóvel por Id",
            OperationId = "Put"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int idTipoImovel, [FromBody] TipoImovelDTO tipoImovelDTO)
        {
            try
            {
                return Ok(_tipoImovelRepository.UpdateById(idTipoImovel, tipoImovelDTO));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
