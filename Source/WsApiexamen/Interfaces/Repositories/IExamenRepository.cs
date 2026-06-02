using BdiExamen.Dtos;

namespace Interfaces.Repositories
{
    public interface IExamenRepository
    {
        Task Add(ExamenDto examen);
        Task Update(ExamenDto examen);
        Task<ExamenDto> Get(int examenId);
        Task Delete(int examenId);
    }
}
