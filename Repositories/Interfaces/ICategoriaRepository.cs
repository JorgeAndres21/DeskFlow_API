
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Repositories.Interface
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ObterTodos(); //Get
        Task<Categoria> ObterPorId(int id);
        Task CadastrarNovo(Categoria cat); // Post
        Task Apagar(Categoria cat); // Delete
        Task Atualizar(Categoria cat); //Put
    }
}