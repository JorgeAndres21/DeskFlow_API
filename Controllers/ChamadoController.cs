using DeskFlowApi.Models.Entities;
using DeskFlowApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowApi.Controllers
{
    [ApiController]
    [Route("chamados")]
    public class ChamadoController : ControllerBase
    {
        private IChamadoServices _services;

        public ChamadoController(IChamadoServices chamadoServices)
        {
            _services = chamadoServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObterChamados()
        {
            List<Chamado> chamadoDb = await _services.ObterChamadosAsync();
            return Ok(chamadoDb);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterChamadoPorId([FromRoute] string id)
        {
            bool idChamBool = int.TryParse(id, out int idCham);
            var chamadoDb = await _services.ObterChamadoPorIdAsync(idCham);

            return Ok(chamadoDb);
        }
        [HttpPost]
        public async Task<IActionResult> AbrirChamado([FromBody] Chamado cham)
        {
            await _services.AbrirNovoChamadoAsync(cham);

            return Ok();
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> IniciarOuFecharChamado([FromRoute] string id)
        {
            bool idChamBool = int.TryParse(id, out int idCham);
            await _services.IniciarOuFecharAtendimentoAsync(idCham);

            return Ok();
        }
        [HttpPost]
        [Route("{id}/interacoes")]
        public async Task<IActionResult> AdicionarInteracao([FromRoute] string id, [FromBody] Interacao inter)
        {
            bool idChamBool = int.TryParse(id, out int idCham);
            await _services.AdicionarInteracaoAsync(idCham, inter);

            return Ok();
        }
    }
}