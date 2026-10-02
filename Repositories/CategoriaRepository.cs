using DeskFlowApi.Models.Entities;
using DeskFlowApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeskFlowApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> ObterCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task<Categoria> ObterCategoriasPorId(int id)
        {
            var categoriaDb = await _context.Categorias
            .Where(c => c.CategoriaId == id).Include(c => c.ChamadosList).FirstOrDefaultAsync();

            return categoriaDb;
        }
        public async Task CadastrarNovaCategoria(Categoria cat)
        {
            await _context.Categorias.AddAsync(cat);
            await _context.SaveChangesAsync();
        }
        public async Task ApagarCategoria(Categoria cat)
        {
            _context.Categorias.Remove(cat);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarCategoria(Categoria cat)
        {
            _context.Categorias.Update(cat);
            await _context.SaveChangesAsync();
        }
    }
}