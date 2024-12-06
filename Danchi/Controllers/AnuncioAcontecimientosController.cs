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

    public class AnuncioAcontecimientosController : ControllerBase
    {
        private readonly IAnuncioAcontecimientosRepository _repository;

        public AnuncioAcontecimientosController(IAnuncioAcontecimientosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAnuncioAcontecimientosr")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAnuncioAcontecimientos()
        {
            var response = await _repository.GetAnuncioAcontecimientos();
            return Ok(response);
        }

        [HttpPost("PostAnuncioAcontecimientos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAnuncioAcontecimientos([FromBody] AnuncioAcontecimientos anuncioAcontecimientos)
        {
            try
            {
                var response = await _repository.PostAnuncioAcontecimientos(anuncioAcontecimientos);
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

        [HttpPut("PutAnuncioAcontecimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAnuncioAcontecimientos([FromBody] AnuncioAcontecimientos anuncioAcontecimientos)
        {
            try
            {
                var response = await _repository.PutAnuncioAcontecimientos(anuncioAcontecimientos);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Anuncio o acontecimiento no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAnuncioAcontecimientos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAnuncioAcontecimientos(int id)
        {
            try
            {
                var response = await _repository.DeleteAnuncioAcontecimientos(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Anuncio o acontecimiento no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
