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
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoServico veiculoServico;

        public VeiculoController(IVeiculoServico veiculoServico)
        {
            this.veiculoServico = veiculoServico;
        }

        [HttpGet()]
        public async Task<ActionResult<VeiculoDTO>> BuscarVeiculo(int id) 
        {
            var data = await veiculoServico.GetAsync(id);
            
            if(data == null )
                return NoContent();

            return Ok(data);
        }
    }

}
