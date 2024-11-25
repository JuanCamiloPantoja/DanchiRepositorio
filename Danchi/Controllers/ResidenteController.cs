using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidenteController : ControllerBase
    {
        private readonly IResidenteRepository _repository;

        public ResidenteController(IResidenteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetResidente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetResidente()
        {
            var response = await _repository.GetResidente();
            return Ok(response);
        }

        [HttpPost("PostAResidente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostResidente([FromBody] Residente residente)
        {
            try
            {
                var response = await _repository.PostResidente(residente);
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

        [HttpPut("PutResidente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutResidente([FromBody] Residente residente)
        {
            try
            {
                var response = await _repository.PutResidente(residente);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Residente no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteResidente/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteResidente(int id)
        {
            try
            {
                var response = await _repository.DeleteResidente(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Residente no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
