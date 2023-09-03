using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.ViewModel;
using EstacionamentoAPI.Services;
using EstacionamentoAPI.Services.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServico _veiculoServico;

        public VeiculoController(IVeiculoServico veiculoServico)
        {
            _veiculoServico = veiculoServico;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<VeiculoDTO>> Get(int id) 
        {
            var data = await _veiculoServico.GetAsync(id).ConfigureAwait(false);
            
            if(data == null )
                return NoContent();

            return Ok(data);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VeiculoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> GetAll()
        {
            var data = await _veiculoServico.GetAll();

            if (!data.Any())
                return NoContent();

            return Ok(data);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<VeiculoDTO>> AddAsync(AddVeiculo vm)
        {
            var data = await _veiculoServico.AddAsync(vm).ConfigureAwait(false);

            return Ok(data);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> UpdateAsync(UpVeiculo vm)
        {
            await _veiculoServico.UpdateAsync(vm).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _veiculoServico.DeleteAsync(id).ConfigureAwait(false);
            return Ok();
        }
    }

}
