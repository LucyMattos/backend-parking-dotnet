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
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServico _veiculoServico;
        private readonly INotificationService _notificationService;

        public VeiculoController(IVeiculoServico veiculoServico, INotificationService notificationService)
        {
            _veiculoServico = veiculoServico;
            _notificationService = notificationService;
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(
          Summary = "Buscar veículo pelo Id",
          Description = "Busca o veículo ativo pelo Id."
        )]
        [SwaggerResponse(200, "Busca realizada com sucesso.")]
        [SwaggerResponse(204, "Veículo não localizado.")]
        [SwaggerResponse(400, "Erro ao tentar localizar veículo.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoDTO))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<VeiculoDTO>> Get(int id, int empresaId) 
        {
            var data = await _veiculoServico.GetAsync(id,empresaId).ConfigureAwait(false);
            
            if(data == null )
                return NoContent();

            return Ok(data);
        }

        [HttpGet()]
        [SwaggerOperation(
          Summary = "Buscar todos os veículo ativos",
          Description = "Busca todos os veículo que não foram excluidos."
        )]
        [SwaggerResponse(200, "Busca realizada com sucesso.")]
        [SwaggerResponse(204, "Não há veículos cadastrados.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        [SwaggerOperation(
          Summary = "Cadastrar veículo",
          Description = "Cadastra um novo veículo."
        )]
        [SwaggerResponse(200, "Veículo cadastrado com sucesso.")]
        [SwaggerResponse(400, "Erro ao cadastrar veículo.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VeiculoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult<VeiculoDTO>> AddAsync(AddVeiculo vm)
        {
            var data = await _veiculoServico.AddAsync(vm).ConfigureAwait(false);

            if (_notificationService.HasErrors)
                return BadRequest(_notificationService.Notification.Errors);

            return Ok(data);
        }


        [HttpPut("saida-do-veiculo")]
        [SwaggerOperation(
          Summary = "Registrar saída do veículo",
          Description = "Registra a saída do veículo do estacionamento."
        )]
        [SwaggerResponse(200, "Registro de saída realizado com sucesso.")]
        [SwaggerResponse(400, "Veículo não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> ParkingExitAsync(int empresaId, int veiculoId)
        {
             await _veiculoServico.ParkingExitAsync(empresaId, veiculoId).ConfigureAwait(false);

            if (_notificationService.HasErrors)
                return BadRequest(_notificationService.Notification.Errors);

            return Ok();
        }

        [HttpPut()]
        [SwaggerOperation(
          Summary = "Atualizar veículo",
          Description = "Atualiza os dados do veículo."
        )]
        [SwaggerResponse(200, "Atualização realizada com sucesso.")]
        [SwaggerResponse(400, "Erro ao atualizar veículo.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> UpdateAsync(UpVeiculo vm)
        {
            await _veiculoServico.UpdateAsync(vm).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete()]
        [SwaggerOperation(
          Summary = "Excluir veículo",
          Description = "Exclui um veículo."
        )]
        [SwaggerResponse(200, "Exclusão realizada com sucesso.")]
        [SwaggerResponse(400, "Erro ao tentar excluir veículo.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(void))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string[]))]
        public async Task<ActionResult> DeleteAsync(int id, int empresaId)
        {
            await _veiculoServico.DeleteAsync(id, empresaId).ConfigureAwait(false);
            return Ok();
        }
    }

}
