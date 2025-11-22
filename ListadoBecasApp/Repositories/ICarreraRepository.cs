
using ListadoBecasApp.Models;

namespace ListadoBecasApp.Repositories
{
    public interface ICarreraRepository
    {
        Task<List<Carrera>> GetAllAsync();
        Task<Carrera?> GetByIdAsync(int id);
    }
}
