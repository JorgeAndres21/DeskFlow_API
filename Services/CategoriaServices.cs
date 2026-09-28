using DeskFlowApi.Models.Entities;
using DeskFlowApi.Repositories.Interface;
using DeskFlowApi.Services.Interfaces;

namespace DeskFlowApi.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private ICategoriaRepository _services;
        public CategoriaServices(ICategoriaRepository services)
        {
            _services = services;
        }
        public async Task<List<Categoria>> ObterCategoriasAsync()
        {
            return await _services.ObterCategorias();
        }
        public async Task<Categoria> ObterCategoriaPorIdAsync(int id)
        {
            var categoriaDb = await _services.ObterCategoriasPorId(id);

            if (categoriaDb == null) throw new KeyNotFoundException("Não encontrado");

            return categoriaDb;
        }
        public async Task CadastrarNovaCategoriaAsync(Categoria cat)
        {
            await _services.CadastrarNovaCategoria(cat);
        }
        public async Task ApagarCategoriaAsync(int id)
        {
            var categoriaDb = await _services.ObterCategoriasPorId(id);

            if (categoriaDb == null) return;

            await _services.ApagarCategoria(categoriaDb);
        }
        public async Task AtualizarCategoriaAsync(int id, Categoria cat)
        {
            var categoriaDb = await _services.ObterCategoriasPorId(id);

            if (categoriaDb == null) throw new KeyNotFoundException($"Categoria com id:{id} não existe");

            await _services.AtualizarCategoria(cat);
        }
    }
}