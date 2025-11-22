
namespace ListadoBecasApp.Services;

using ListadoBecasApp.DTOs;

public interface IBecaService
{
    Task<List<BecaDto>> GetAllAsync(int? carreraId);
    Task<BecaDto> GetByIdAsync(int id);
    Task AddAsync(BecaDto dto);
    Task UpdateAsync(BecaDto dto);
    Task DeleteAsync(int id);
}
