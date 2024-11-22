using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
