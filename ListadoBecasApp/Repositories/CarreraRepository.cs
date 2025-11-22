
using ListadoBecasApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ListadoBecasApp.Repositories
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly BecasAppContext _context;

        public CarreraRepository(BecasAppContext context)
        {
            _context = context;
        }

        public async Task<List<Carrera>> GetAllAsync()
        {
            return await _context.Carreras.ToListAsync();
        }

        public async Task<Carrera?> GetByIdAsync(int id)
        {
            return await _context.Carreras.FirstOrDefaultAsync(c => c.IdCarrera == id);
        }
    }
}
