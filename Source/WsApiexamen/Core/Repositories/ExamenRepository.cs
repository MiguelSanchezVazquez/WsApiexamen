using BdiExamen;
using BdiExamen.Dtos;
using BdiExamen.Entities;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class ExamenRepository : IExamenRepository
    {
        private readonly ExamenContext _context;

        public ExamenRepository(ExamenContext context)
        {
            _context = context;
        }

        public async Task Add(ExamenDto examen)
        {
            await _context.tblExamen.AddAsync(new tblExamen
            {
                idExamen = examen.idExamen,
                Descripcion = examen.Descripcion,
                Nombre = examen.Nombre,
            });

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int examenId)
        {
            var examen = new tblExamen { idExamen = examenId };

            _context.tblExamen.Attach(examen);
            _context.tblExamen.Remove(examen);

            await _context.SaveChangesAsync();
        }

        public async Task<ExamenDto> Get(int examenId)
        {
            return await _context.tblExamen
                .Where(x => x.idExamen == examenId)
                .Select(x => new ExamenDto
            {
                idExamen = x.idExamen,
                Descripcion = x.Descripcion,
                Nombre = x.Nombre,
            }).FirstAsync();
        }

        public async Task Update(ExamenDto examen)
        {
            var existingExamen = await _context.tblExamen.FirstAsync(x => x.idExamen == examen.idExamen);

            existingExamen.Descripcion = examen.Descripcion;
            existingExamen.Nombre = examen.Nombre;

            await _context.SaveChangesAsync();
        }
    }
}
