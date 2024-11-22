using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionEmergenciasController : ControllerBase
    {
        private readonly INotificacionEmergenciasRepository _repository;

        public NotificacionEmergenciasController(INotificacionEmergenciasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetNotificacionEmergencias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetNotificacionEmergencias()
        {
            var response = await _repository.GetNotificacionEmergencias();
            return Ok(response);
        }

        [HttpPost("PostNotificacionEmergencias")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAdministrador([FromBody] NotificacionEmergencias notificacionEmergencias)
        {
            try
            {
                var response = await _repository.PostNotificacionEmergencias(notificacionEmergencias);
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
