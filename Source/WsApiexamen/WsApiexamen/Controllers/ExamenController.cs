using BdiExamen.Dtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WsApiexamen.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly IExamenService _examenService;

        public ExamenController(IExamenService examenService)
        {
            _examenService = examenService;
        }

        [HttpPost]
        [Route("AgregarExamen")]
        public async Task<IActionResult> AgregarExamen(ExamenDto examen)
        {
            try
            {
                await _examenService.Add(examen);

                return Ok(new { Message = "Registro insertado satisfactoriamente"});
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPost]
        [Route("ActualizarExamen")]
        public async Task<IActionResult> ActualizarExamen(ExamenDto examen)
        {
            try
            {
                await _examenService.Update(examen);

                return Ok(new { Message = "Registro actualizado satisfactoriamente" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPost]
        [Route("EliminarExamen")]
        public async Task<IActionResult> EliminarExamen(int examenId)
        {
            try
            {
                await _examenService.Delete(examenId);

                return Ok(new { Message = "Registro eliminado satisfactoriamente" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        [HttpPost]
        [Route("ConsultarExamen")]
        public async Task<IActionResult> ConsultarExamen(int examenId)
        {
            try
            {
                var result = await _examenService.Get(examenId);

                return Ok(new { Examen = result });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}
