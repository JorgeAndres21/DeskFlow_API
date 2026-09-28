using DeskFlowApi.Models.Entities;

namespace DeskFlowApi.Repositories.Interface
{
    public interface IChamadoRepository
    {
        Task<List<Chamado>> ObterChamados();
        Task<Chamado> ObterChamadosPorId(int id);
        Task AbrirNovoChamado(Chamado cham);
        Task IniciarOuFecharAtendimento(int id);
        Task AdicionarInteracao(int id, Interacao inter);
    }
}