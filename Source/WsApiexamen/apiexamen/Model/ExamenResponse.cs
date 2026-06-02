
using BdiExamen.Dtos;

namespace ApiExamen.Model
{
    public class ExamenResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public ExamenDto? Examen { get; set; } = null; 
    }
}
