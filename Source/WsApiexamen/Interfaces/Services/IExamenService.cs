using BdiExamen.Dtos;

namespace Interfaces.Services
{
    public interface IExamenService
    {
        Task Add(ExamenDto examen);
        Task Update(ExamenDto examen);
        Task<ExamenDto> Get(int examenId);
        Task Delete(int examenId);
    }
}
