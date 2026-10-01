using DeskFlowApi.DTO;
using DeskFlowApi.Models.Entities;
using DeskFlowApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlowApi.Controllers
{
    [ApiController]
    [Route("categoria")]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaServices _services;
        public CategoriaController(ICategoriaServices categoriaServices)
        {
            _services = categoriaServices;
        }
        [HttpGet]
        public async Task<IActionResult> ObterCategorias()
        {
            var categoriaDb = await _services.ObterCategoriasAsync();
            return Ok(categoriaDb);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterCategoriaPorId([FromRoute] string id)
        {
            bool idCatBool = int.TryParse(id, out int idCat);
            var categoriaDb = await _services.ObterCategoriaPorIdAsync(idCat);
            return Ok(categoriaDb);
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarCategoria([FromBody] Categoria cat)
        {
            await _services.CadastrarNovaCategoriaAsync(cat);
            return Ok("Criado com sucesso");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> ApagarCategoria([FromRoute] string id)
        {
            bool idCatBool = int.TryParse(id, out int idCat);
            await _services.ApagarCategoriaAsync(idCat);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> AtualizarCategoria([FromRoute] string id, [FromBody] Categoria cat)
        {
            bool idCatBool = int.TryParse(id, out int idCat);
            await _services.AtualizarCategoriaAsync(idCat, cat);
            return Ok();
        }
    }
}