
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
        public async Task IniciarOuFecharAtendimento(int id)
        {
            var chamadoDb = await _context.Chamados.FindAsync(id);

            if (chamadoDb.Status == "aberto") chamadoDb.Status = "em andamento";
            else if (chamadoDb.Status == "em andamento") chamadoDb.Status = "fechado";
            else chamadoDb.Status = "em andamento";

            await _context.SaveChangesAsync();
        }
        public async Task AdicionarInteracao(int id, Interacao inter)
        {
            var chamadoDb = await _context.Chamados
            .Include(c => c.InteracoesList).FirstOrDefaultAsync(c => c.ChamadoId == id);

            chamadoDb.InteracoesList.Add(inter);
            await _context.SaveChangesAsync();
        }
    }
}