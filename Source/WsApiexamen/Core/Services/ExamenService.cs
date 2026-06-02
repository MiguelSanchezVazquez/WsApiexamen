using BdiExamen.Dtos;
using Core.Repositories;
using Interfaces.Repositories;
using Interfaces.Services;

namespace Core.Services
{
    public class ExamenService : IExamenService
    {
        private readonly IExamenRepository _examenRepository;

        public ExamenService(IExamenRepository examenRepository)
        {
            _examenRepository = examenRepository;
        }

        public async Task Add(ExamenDto examen)
        {
            await _examenRepository.Add(examen);
        }

        public async Task<ExamenDto> Get(int examenId)
        {
            return await _examenRepository.Get(examenId);
        }

        public async Task Update(ExamenDto examen)
        {
            await _examenRepository.Update(examen);
        }

        public async Task Delete(int examenId)
        {
            await _examenRepository.Delete(examenId);
        }
    }
}
