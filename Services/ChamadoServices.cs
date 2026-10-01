
using System.Collections.Specialized;
using DeskFlowApi.DtO;
using DeskFlowApi.Models.Entities;
using DeskFlowApi.Repositories.Interface;
using DeskFlowApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<List<Chamado>> ObterChamadosAsync(Filtro filtro)
        {
            var chamadoDb = await _repository.ObterChamados();
            List<Chamado> chamadosLista = [];

            if (!filtro.Status.IsNullOrEmpty() && !filtro.Prioridade.IsNullOrEmpty())
            {
                chamadosLista = chamadoDb.Where(c => c.Status == filtro.Status && c.Prioridade == filtro.Prioridade).ToList();
            }
            else
                if (!filtro.Status.IsNullOrEmpty())
                {
                    chamadosLista = chamadoDb.Where(c => c.Status == filtro.Status).ToList();
                }
                else
                    if (!filtro.Prioridade.IsNullOrEmpty())
                    {
                        chamadosLista = chamadoDb.Where(c => c.Prioridade == filtro.Prioridade).ToList();
                    }
                    else chamadosLista = await _repository.ObterChamados();
            return chamadosLista;
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
        public async Task IniciarAtendimentoAsync(int id)
        {
            var chamadoDb = await _repository.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new NullReferenceException("Chamado não existente.");

            if (chamadoDb.Status == "aberto")
            {
                await _repository.IniciarAtendimento(id);
            }
            else
            {
                throw new Exception("Atendimento já está em andamento ou fechado.");
            }

        }
        public async Task FecharAtendimentoAsync(int id, ParametrosDTO parametros)
        {
            var chamadoDb = await _repository.ObterChamadosPorId(id);

            if (chamadoDb == null || parametros == null) throw new NullReferenceException("Chamado ou parámetros nulo");

            if (chamadoDb.Status == "em andamento")
            {
                await _repository.FecharAtendimento(id, parametros);
            }
            else
            {
                throw new Exception("Atendimento ainda não foi aberto ou já esta fechado");
            }

        }
        public async Task AdicionarInteracaoAsync(int id, Interacao inter)
        {
            var chamadoDb = await _repository.ObterChamadosPorId(id);

            if (chamadoDb == null) throw new KeyNotFoundException("Chamado não encontrado");

            if (chamadoDb.Status == "fechado") throw new Exception("Não é possivél adicionar uma interação em um chamado fechado.");

            await _repository.AdicionarInteracao(id, inter);
        }
    }
}