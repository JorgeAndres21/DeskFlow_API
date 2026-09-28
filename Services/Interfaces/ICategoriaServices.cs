
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Services.Interfaces
{
    public interface ICategoriaServices
    {
        Task<List<Categoria>> ObterCategoriasAsync();
        Task<Categoria> ObterCategoriaPorIdAsync(int id);
        Task CadastrarNovaCategoriaAsync(Categoria cat);
        Task ApagarCategoriaAsync(int id);
        Task AtualizarCategoriaAsync(int id, Categoria cat);
    }
}