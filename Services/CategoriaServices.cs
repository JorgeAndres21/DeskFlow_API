using DeskFlowApi.Models.Entities;
using DeskFlowApi.Repositories.Interface;
using DeskFlowApi.Services.Interfaces;

namespace DeskFlowApi.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private ICategoriaRepository _repository;
        public CategoriaServices(ICategoriaRepository services)
        {
            _repository = services;
        }
        public async Task<List<Categoria>> ObterCategoriasAsync()
        {
            return await _repository.ObterCategorias();
        }
        public async Task<Categoria> ObterCategoriaPorIdAsync(int id)
        {
            var categoriaDb = await _repository.ObterCategoriasPorId(id);

            if (categoriaDb == null) throw new KeyNotFoundException("Não encontrado");

            return categoriaDb;
        }
        public async Task CadastrarNovaCategoriaAsync(Categoria cat)
        {
            await _repository.CadastrarNovaCategoria(cat);
        }
        public async Task ApagarCategoriaAsync(int id)
        {
            var categoriaDb = await _repository.ObterCategoriasPorId(id);

            if (categoriaDb == null) return;

            await _repository.ApagarCategoria(categoriaDb);
        }
        public async Task AtualizarCategoriaAsync(int id, Categoria cat)
        {
            var categoriaDb = await _repository.ObterCategoriasPorId(id);

            if (categoriaDb == null) throw new KeyNotFoundException($"Categoria com id:{id} não existe");

            await _repository.AtualizarCategoria(cat);
        }
    }
}