
using DeskFlowApi.Models.Entities;
using DeskFlowApi.Repositories.Interface;
using DeskFlowApi.Services.Interfaces;

namespace DeskFlowApi.Services
{
    public class ChamadoServices : IChamadoServices
    {
        private IChamadoRepository _services;
        public ChamadoServices(IChamadoRepository chamadoRepository)
        {
            _services = chamadoRepository;
        }

        public async Task<List<Chamado>> ObterChamadosAsync()
        {
            return await _services.ObterChamados();
        }
        public async Task<Chamado> ObterChamadoPorIdAsync(int id)
        {
            var chamadoDb = await _services.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new KeyNotFoundException("Chamado não encontrado");

            return chamadoDb;
        }
        public async Task AbrirNovoChamadoAsync(Chamado cham)
        {
            await _services.AbrirNovoChamado(cham);
        }
        public async Task IniciarOuFecharAtendimentoAsync(int id)
        {
            var chamadoDb = _services.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new KeyNotFoundException("Chamado não encontrado");

            await _services.IniciarOuFecharAtendimento(id);
        }
        public async Task AdicionarInteracaoAsync(int id, Interacao inter)
        {
            var chamadoDb = await _services.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new KeyNotFoundException("Chamado não encontrado");

            await _services.AdicionarInteracao(id, inter);
        }
    }
}