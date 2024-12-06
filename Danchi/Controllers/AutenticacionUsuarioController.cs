using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutenticacionUsuarioController : ControllerBase
    {
        private readonly IAutenticacionUsuarioRepository _repository;

        public AutenticacionUsuarioController(IAutenticacionUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAutenticacionUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAutenticacionUsuario()
        {
            var response = await _repository.GetAutenticacionUsuario();
            return Ok(response);
        }

        [HttpPost("PostAutenticacionUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAutenticacionUsuario([FromBody] AutenticacionUsuario autenticacionUsuario)
        {
            try
            {
                var response = await _repository.PostAutenticacionUsuario(autenticacionUsuario);
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

        [HttpPut("PutAutenticacionUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAutenticacionUsuario([FromBody] AutenticacionUsuario autenticacionUsuario)
        {
            try
            {
                var response = await _repository.PutAutenticacionUsuario(autenticacionUsuario);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAutenticacionUsuario/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAutenticacionUsuario(int id)
        {
            try
            {
                var response = await _repository.DeleteAutenticacionUsuario(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
