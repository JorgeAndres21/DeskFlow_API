
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Repositories.Interface
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ObterCategorias(); //Get
        Task<Categoria> ObterCategoriasPorId(int id);
        Task CadastrarNovaCategoria(Categoria cat); // Post
        Task ApagarCategoria(Categoria cat); // Delete
        Task AtualizarCategoria(Categoria cat); //Put
    }
}