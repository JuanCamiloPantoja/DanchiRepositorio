using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorRepository _repository;

        public AdministradorController(IAdministradorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAdministrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAdministrador()
        {
            var response = await _repository.GetAdministrador();
            return Ok(response);
        }

        [HttpPost("PostAdministrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAdministrador([FromBody] Administrador administrador)
        {
            try
            {
                var response = await _repository.PostAdministrador(administrador);
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
        [HttpPut("PutAdministrador/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAdministrador(int id, [FromBody] Administrador administrador)
        {
            if (id != administrador.IdAdministrador)
            {
                return BadRequest("El ID del administrador no coincide con el proporcionado.");
            }

            try
            {
                var response = await _repository.PutAdministrador(administrador);
                if (response)
                    return Ok("Administrador actualizado correctamente.");
                else
                    return NotFound("Administrador no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAdministrador/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAdministrador(int Id)
        {
            try
            {
                // Asegúrate de que 'id' corresponde a 'IdAdministrador'
                var response = await _repository.DeleteAdministrador(Id);
                if (response)
                    return Ok("Administrador eliminado correctamente.");
                else
                    return NotFound("Administrador no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

