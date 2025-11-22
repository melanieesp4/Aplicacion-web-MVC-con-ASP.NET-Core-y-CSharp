
using ListadoBecasApp.DTOs;

namespace ListadoBecasApp.Services
{
    public interface ICarreraService
    {
        Task<List<CarreraDto>> GetAllAsync();
        Task<CarreraDto?> GetByIdAsync(int id);
    }
}
