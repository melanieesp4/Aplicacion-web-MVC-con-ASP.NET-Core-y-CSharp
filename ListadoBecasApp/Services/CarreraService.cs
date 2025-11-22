
using AutoMapper;
using ListadoBecasApp.DTOs;
using ListadoBecasApp.Models;
using ListadoBecasApp.Repositories;

namespace ListadoBecasApp.Services
{
    public class CarreraService : ICarreraService
    {
        private readonly ICarreraRepository _repo;
        private readonly IMapper _mapper;

        public CarreraService(ICarreraRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CarreraDto>> GetAllAsync()
        {
            var carreras = await _repo.GetAllAsync();
            return _mapper.Map<List<CarreraDto>>(carreras);
        }

        public async Task<CarreraDto?> GetByIdAsync(int id)
        {
            var carrera = await _repo.GetByIdAsync(id);
            return _mapper.Map<CarreraDto?>(carrera);
        }
    }
}
