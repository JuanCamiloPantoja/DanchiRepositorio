using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoporteTecnicoController : ControllerBase
    {
        private readonly ISoporteTecnicoRepository _repository;

        public SoporteTecnicoController(ISoporteTecnicoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetSoporteTecnico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSoporteTecnico()
        {
            var response = await _repository.GetSoporteTecnico();
            return Ok(response);
        }

        [HttpPost("PostSoporteTecnico")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostSoporteTecnico([FromBody] SoporteTecnico soporteTecnico)
        {
            try
            {
                var response = await _repository.PostSoporteTecnico(soporteTecnico);
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

        [HttpPut("PutSoporteTecnico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutSoporteTecnico(int id, [FromBody] SoporteTecnico soporteTecnico)
        {
            if (id != soporteTecnico.IdSoporte)
            {
                return BadRequest("El ID del soporte no coincide con el proporcionado.");
            }
            try
            {
                var response = await _repository.PutSoporteTecnico(soporteTecnico);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Soporte técnico no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteSoporteTecnico/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSoporteTecnico(int id)
        {
            try
            {
                var response = await _repository.DeleteSoporteTecnico(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Soporte técnico no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
