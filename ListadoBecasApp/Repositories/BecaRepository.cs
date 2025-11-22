
namespace ListadoBecasApp.Repositories;

using ListadoBecasApp.Models;
using Microsoft.EntityFrameworkCore;

public class BecaRepository : IBecaRepository
{
    private readonly BecasAppContext _context;

    public BecaRepository(BecasAppContext context)
    {
        _context = context;
    }

    public IQueryable<Beca> Query()
    {
        return _context.Becas
            .Include(b => b.IdCarreraNavigation);
    }

    public async Task<Beca?> GetByIdAsync(int id)
    {
        return await _context.Becas
            .Include(b => b.IdCarreraNavigation)
            .FirstOrDefaultAsync(b => b.IdBeca == id);
    }

    public async Task AddAsync(Beca beca)
    {
        await _context.Becas.AddAsync(beca);
    }

    public Task UpdateAsync(Beca beca)
    {
        _context.Becas.Update(beca);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Beca beca)
    {
        _context.Becas.Remove(beca);
        return Task.CompletedTask;
    }



    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
