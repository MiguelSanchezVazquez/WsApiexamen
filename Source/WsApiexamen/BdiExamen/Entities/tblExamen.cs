using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BdiExamen.Entities
{
    [Table("tblExamen")]
    public class tblExamen
    {
        [Key]
        public int idExamen { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
