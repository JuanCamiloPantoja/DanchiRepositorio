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

        [HttpPut("PutNotificacionEmergencias")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutNotificacionEmergencias(int id, [FromBody] NotificacionEmergencias notificacionEmergencias)
        {
            if (id != notificacionEmergencias.IdEmergencia)
            {
                return BadRequest("El ID de la emergencia no coincide con el proporcionado.");
            }
            try
            {
                var response = await _repository.PutNotificacionEmergencias(notificacionEmergencias);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Notificación de emergencia no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteNotificacionEmergencias/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNotificacionEmergencias(int id)
        {
            try
            {
                var response = await _repository.DeleteNotificacionEmergencias(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Notificación de emergencia no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
