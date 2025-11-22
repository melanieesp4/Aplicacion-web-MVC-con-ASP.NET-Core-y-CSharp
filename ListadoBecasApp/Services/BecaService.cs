namespace ListadoBecasApp.Services;

using AutoMapper;
using ListadoBecasApp.DTOs;
using ListadoBecasApp.Models;
using ListadoBecasApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BecaService : IBecaService
{
    private readonly IBecaRepository _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<BecaService> _logger;

    public BecaService(IBecaRepository repo, IMapper mapper, ILogger<BecaService> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<BecaDto>> GetAllAsync(int? carreraId)
    {
        var query = _repo.Query();

        // Si viene la carrera, filtramos
        if (carreraId.HasValue)
        {
            query = query.Where(b => b.IdCarrera == carreraId.Value);
        }

        var becas = await query.ToListAsync();
        return _mapper.Map<List<BecaDto>>(becas);
    }


    public async Task<BecaDto> GetByIdAsync(int id)
    {
        var beca = await _repo.GetByIdAsync(id);
        return _mapper.Map<BecaDto>(beca);
    }

    public async Task AddAsync(BecaDto dto)
    {
        var beca = _mapper.Map<Beca>(dto);
        await _repo.AddAsync(beca);
        await _repo.SaveAsync();
    }

    public async Task UpdateAsync(BecaDto dto)
    {
        var beca = _mapper.Map<Beca>(dto);
        await _repo.UpdateAsync(beca);
        await _repo.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var beca = await _repo.GetByIdAsync(id);
        if (beca != null)
        {
            await _repo.DeleteAsync(beca);
            await _repo.SaveAsync();
        }
    }
}
