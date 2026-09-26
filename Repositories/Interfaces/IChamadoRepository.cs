using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Repositories.Interface
{
    public interface IChamadoRepository
    {
        Task<List<Chamado>> ObterTodos();
        Task<Chamado> ObterPorId(int id);
        Task<Chamado> CadastrarNovo(Chamado cham);
        Task IniciarOuFecharAtendimento(int id);
        Task<Chamado> AdicionarInteracao(int id, Interacao inter);
    }
}