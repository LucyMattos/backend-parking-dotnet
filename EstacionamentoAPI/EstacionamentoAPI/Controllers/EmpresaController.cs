using EstacionamentoAPI.Domain.DTO;
using EstacionamentoAPI.Domain.ViewModel;
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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServico _empresaServico;
        private readonly INotificationService _notificationService;

        public EmpresaController(IEmpresaServico empresaServico, INotificationService notificationService)
        {
            _empresaServico = empresaServico;
            _notificationService = notificationService;
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(
          Summary = "Buscar empresa pelo Id",
          Description = "Busca empresa ativa pelo Id."
        )]
        [SwaggerResponse(200, "Empresa encontrada.")]
        [SwaggerResponse(204, "Empresa não encontrada.")]
        [SwaggerResponse(400, "Erro ao tentar localizar empresa.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]

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
        [SwaggerOperation(
          Summary = "Buscar todas as empresas ativas",
          Description = "Lista todas as empresas ativas e seus veículos cadastrados."
        )]
        [SwaggerResponse(200, "Empresas encontradas.")]
        [SwaggerResponse(204, "Não há empresas cadastradas.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        [SwaggerOperation(
          Summary = "Cadastrar empresa",
          Description = "Cadastra uma nova empresa."
        )]
        [SwaggerResponse(200, "Empresa cadastrada com sucesso.")]
        [SwaggerResponse(400, "Erro ao cadastrar empresa.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<EmpresaDTO>> AddAsync(AddEmpresa vm)
        {
            var data = await _empresaServico.AddAsync(vm).ConfigureAwait(false);

            return Ok(data);
        }

        [HttpPut()]
        [SwaggerOperation(
          Summary = "Atualizar empresa",
          Description = "Atualiza os dados da empresa."
        )]
        [SwaggerResponse(200, "Atualização realizada com sucesso.")]
        [SwaggerResponse(400, "Erro ao atualizar empresa.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> UpdateAsync(UpEmpresa vm)
        {
             await _empresaServico.UpdateAsync(vm).ConfigureAwait(false);

            if (_notificationService.HasErrors)
                return BadRequest(_notificationService.Notification.Errors);

            return Ok();
        }

        [HttpDelete()]
        [SwaggerOperation(
          Summary = "Excluir empresa",
          Description = "Exclui uma empresa."
        )]
        [SwaggerResponse(200, "Exclusão realizada com sucesso.")]
        [SwaggerResponse(400, "Erro ao tentar excluir empresa.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _empresaServico.DeleteAsync(id).ConfigureAwait(false);

            if (_notificationService.HasErrors)
                return BadRequest(_notificationService.Notification.Errors);

            return Ok();
           
        }
    }
}
