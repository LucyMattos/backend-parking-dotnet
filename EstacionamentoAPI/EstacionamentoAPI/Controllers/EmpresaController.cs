using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.ViewModel;
using EstacionamentoAPI.Services.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServico _empresaServico;

        public EmpresaController(IEmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<EmpresaDTO>> Get(int id)
        {
            var data = await _empresaServico.GetAsync(id).ConfigureAwait(false);

            if (data == null)
                return NoContent();

            return Ok(data);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmpresaDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string[]))]
        public async Task<ActionResult<IEnumerable<EmpresaDTO>>> GetAll()
        {
            var data = await _empresaServico.GetAll();

            if (!data.Any())
                return NoContent();

            return Ok(data);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<EmpresaDTO>> AddAsync(AddEmpresa vm)
        {
            var data = await _empresaServico.AddAsync(vm).ConfigureAwait(false);

            return Ok(data);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> UpdateAsync(UpEmpresa vm)
        {
            await _empresaServico.UpdateAsync(vm).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _empresaServico.DeleteAsync(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
