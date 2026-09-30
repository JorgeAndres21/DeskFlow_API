using DeskFlowApi.DtO;
using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Repositories.Interface
{
    public interface IChamadoRepository
    {
        Task<List<Chamado>> ObterChamados();
        Task<Chamado> ObterChamadosPorId(int id);
        Task AbrirNovoChamado(Chamado cham);
        Task IniciarAtendimento(int id);
        Task FecharAtendimento(int id, ParametrosDTO parametros);
        Task AdicionarInteracao(int id, Interacao inter);
    }
}