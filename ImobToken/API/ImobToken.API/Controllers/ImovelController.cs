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
    public class ImovelController : ControllerBase
    {
        private readonly IImovelRepository _imovelRepository;

        public ImovelController(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Cadastra um novo imóvel.",
            Description = "Endpoint para cadastrar um imovel",
            OperationId = "Post"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ImovelDTO imovelDTO)
        {
            Imovel imovel = new Imovel(
                imovelDTO.Nome,
                imovelDTO.Valor,
                imovelDTO.MetrosQuadrados,
                imovelDTO.FaixaRenda,
                imovelDTO.TipoImovelId
            );

            try
            {
                await _imovelRepository.Insert(imovel);
                return StatusCode(201, imovel);
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Retorna todos os imóveis cadastrados e seus respectivos tipos.",
            Description = "Endpoint para retornar todos os imóveis.",
            OperationId = "Get"
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Imovel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult Get()
        {
            try
            {
                return Ok(_imovelRepository.GetAll());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retorna um imóvel com seu respectivo tipo por Id.",
            Description = "Endpoint para retornar um imóvel por Id",
            OperationId = "GetById"
        )]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Imovel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_imovelRepository.GetById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remove um imóvel por Id.",
            Description = "Endpoint para remover um imóvel por Id",
            OperationId = "Delete"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_imovelRepository.DeleteById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualiza um imóvel por Id.",
            Description = "Endpoint para atualizar um imóvel por Id",
            OperationId = "Put"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] ImovelDTO imovelDTO)
        {
            try
            {
                return Ok(_imovelRepository.UpdateById(id, imovelDTO));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
