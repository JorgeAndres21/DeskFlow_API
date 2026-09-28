using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Services.Interfaces
{
    public interface IChamadoServices
    {
        Task<List<Chamado>> ObterChamadosAsync();
        Task<Chamado> ObterChamadoPorIdAsync(int id);
        Task AbrirNovoChamadoAsync(Chamado cham);
        Task IniciarOuFecharAtendimentoAsync(int id);
        Task AdicionarInteracaoAsync(int id, Interacao inter);
    }
}