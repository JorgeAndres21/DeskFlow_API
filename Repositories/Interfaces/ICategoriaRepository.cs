
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Repositories.Interface
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ObterCategorias();
        Task<Categoria> ObterCategoriasPorId(int id);
        Task CadastrarNovaCategoria(Categoria cat);
        Task ApagarCategoria(Categoria cat);
        Task AtualizarCategoria(Categoria cat);
    }
}