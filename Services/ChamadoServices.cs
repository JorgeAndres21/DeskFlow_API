
using System.Collections.Specialized;
using DeskFlowApi.Models.Entities;
using DeskFlowApi.Repositories.Interface;
using DeskFlowApi.Services.Interfaces;

namespace DeskFlowApi.Services
{
    public class ChamadoServices : IChamadoServices
    {
        private IChamadoRepository _repository;
        public ChamadoServices(IChamadoRepository chamadoRepository)
        {
            _repository = chamadoRepository;
        }

        public async Task<List<Chamado>> ObterChamadosAsync()
        {
            return await _repository.ObterChamados();
        }
        public async Task<Chamado> ObterChamadoPorIdAsync(int id)
        {
            var chamadoDb = await _repository.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new KeyNotFoundException("Chamado não encontrado");

            return chamadoDb;
        }
        public async Task AbrirNovoChamadoAsync(Chamado cham)
        {
            await _repository.AbrirNovoChamado(cham);
        }
        public async Task IniciarOuFecharAtendimentoAsync(int id)
        {
            var chamadoDb = _repository.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new KeyNotFoundException("Chamado não encontrado");

            await _repository.IniciarOuFecharAtendimento(id);
        }
        public async Task AdicionarInteracaoAsync(int id, Interacao inter)
        {
            var chamadoDb = await _repository.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new KeyNotFoundException("Chamado não encontrado");

            await _repository.AdicionarInteracao(id, inter);
        }
    }
}