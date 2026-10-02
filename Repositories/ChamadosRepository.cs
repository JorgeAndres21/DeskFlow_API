
using DeskFlowApi.DTO;
using DeskFlowApi.Models.Entities;
using DeskFlowApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowApi.Repositories
{
    public class ChamadosRepository : IChamadoRepository
    {
        private AppDbContext _context;

        public ChamadosRepository(AppDbContext chamadoRepository)
        {
            _context = chamadoRepository;
        }
        public async Task<List<Chamado>> ObterChamados()
        {
            return await _context.Chamados.Include(c => c.InteracoesList).ToListAsync();
        }
        public async Task<Chamado> ObterChamadosPorId(int id)
        {
            var chamadoDb = await _context.Chamados
            .Where(c => c.ChamadoId == id).Include(c => c.InteracoesList).FirstOrDefaultAsync();

            return chamadoDb;
        }
        public async Task AbrirNovoChamado(Chamado cham)
        {
            await _context.Chamados.AddAsync(cham);
            await _context.SaveChangesAsync();
        }
        public async Task IniciarAtendimento(int id)
        {
            var chamadoDb = await _context.Chamados.FindAsync(id);

            chamadoDb.Status = "em andamento";
        }
        public async Task FecharAtendimento(int id, ParametrosDTO parametros)
        {
            var chamadoDb = await _context.Chamados.FindAsync(id);

            chamadoDb.Status = "fechado";
            chamadoDb.Solucao = parametros.Solucao;
            chamadoDb.DataFechamento = DateTime.Now;

            await _context.SaveChangesAsync();
        }
        public async Task AdicionarInteracao(int id, Interacao inter)
        {
            var chamadoDb = await _context.Chamados
            .Include(c => c.InteracoesList).FirstOrDefaultAsync(c => c.ChamadoId == id);
            Interacao interDb;

            interDb = inter;

            interDb.DataRegistro = DateTime.Now;
            chamadoDb.InteracoesList.Add(interDb);

            await _context.SaveChangesAsync();
        }
    }
}