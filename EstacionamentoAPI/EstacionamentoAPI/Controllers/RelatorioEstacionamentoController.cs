using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Services.Contratos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    public class RelatorioEstacionamentoController : ControllerBase
    {
        private readonly IEmpresaServico _empresaServico;

        public RelatorioEstacionamentoController(IEmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<EmpresaDTO>> GetRegister(int empresaId, DateTime dataEntrada, DateTime dataSaida)
        {
            var data = await _empresaServico.GetRegister(empresaId, dataEntrada, dataSaida).ConfigureAwait(false);

            if (data == null)
                return NoContent();

            return Ok(data);
        }
    }
}
