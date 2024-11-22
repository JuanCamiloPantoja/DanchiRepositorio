using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugerenciasReporteErroresController : ControllerBase
    {
        private readonly ISugerenciasReporteErroresRepository _repository;

        public SugerenciasReporteErroresController(ISugerenciasReporteErroresRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetSugerenciasReporteErrores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSugerenciasReporteErrores()
        {
            var response = await _repository.GetSugerenciasReporteErrores();
            return Ok(response);
        }

        [HttpPost("PostSugerenciasReporteErrores")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostSugerenciasReporteErrores([FromBody] SugerenciasReporteErrores sugerenciasReporteErrores)
        {
            try
            {
                var response = await _repository.PostSugerenciasReporteErrores(sugerenciasReporteErrores);
                if (response == true)
                    return Ok("Insertado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
