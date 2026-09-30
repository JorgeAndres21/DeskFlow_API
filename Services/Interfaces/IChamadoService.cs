using DeskFlowApi.DtO;
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Services.Interfaces
{
    public interface IChamadoServices
    {
        Task<List<Chamado>> ObterChamadosAsync();
        Task<Chamado> ObterChamadoPorIdAsync(int id);
        Task AbrirNovoChamadoAsync(Chamado cham);
        Task IniciarAtendimentoAsync(int id);
        Task FecharAtendimentoAsync(int id, ParametrosDTO parametros);
        Task AdicionarInteracaoAsync(int id, Interacao inter);
    }
}