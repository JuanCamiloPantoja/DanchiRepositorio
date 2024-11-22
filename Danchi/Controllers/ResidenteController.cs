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
    }
}
