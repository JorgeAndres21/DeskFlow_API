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
        public async Task<List<Categoria>> ObterTodos()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task<Categoria> ObterPorId(int id)
        {
            var categoriaDb = await _context.Categorias
            .Where(c => c.CategoriaId == id).FirstOrDefaultAsync();

            return categoriaDb;
        }
        public async Task CadastrarNovo(Categoria cat)
        {
            await _context.Categorias.AddAsync(cat);
            await _context.SaveChangesAsync();
        }
        public async Task Apagar(Categoria cat)
        {
            _context.Categorias.Remove(cat);
            await _context.SaveChangesAsync();
        }
        public async Task Atualizar(Categoria cat)
        {
            _context.Categorias.Update(cat);
            await _context.SaveChangesAsync();
        }
    }
}