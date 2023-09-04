using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Services.Contratos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(
          Summary = "Buscar registros de entrada e saída de veículos",
          Description = "Lista por período os veículos da empresa com as datas de entrada e saída com seus respectivos horários.  "
        )]
        [SwaggerResponse(200, "Registro encontrado.")]
        [SwaggerResponse(204, "Não há registros.")]
        [SwaggerResponse(400, "Erro ao tentar localizar os registros.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
