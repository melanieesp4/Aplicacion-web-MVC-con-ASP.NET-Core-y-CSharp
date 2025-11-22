

namespace ListadoBecasApp.Repositories;

using ListadoBecasApp.Models;
using System.Linq.Expressions;

public interface IBecaRepository
{
    IQueryable<Beca> Query();
    Task<Beca?> GetByIdAsync(int id);
    Task AddAsync(Beca beca);
    Task UpdateAsync(Beca beca);
    Task DeleteAsync(Beca beca);
    Task SaveAsync();
}
