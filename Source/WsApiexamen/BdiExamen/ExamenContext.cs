using BdiExamen.Entities;
using Microsoft.EntityFrameworkCore;

namespace BdiExamen
{
    public class ExamenContext : DbContext
    {
        public ExamenContext()
        {
        }

        public ExamenContext(DbContextOptions<ExamenContext> options)
            : base(options)
        {
        }

        public DbSet<tblExamen> tblExamen { get; set; }
    }
}
