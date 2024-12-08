using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatInternoController : ControllerBase
    {
        private readonly IChatInternoRepository _repository;

        public ChatInternoController(IChatInternoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetChatInterno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetChatInterno()
        {
            var response = await _repository.GetChatInterno();
            return Ok(response);
        }

        [HttpPost("PostChatInterno")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostChatInterno([FromBody] ChatInterno chatInterno)
        {
            try
            {
                var response = await _repository.PostChatInterno(chatInterno);
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

        [HttpPut("PutChatInterno")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutChatInterno(int id, [FromBody] ChatInterno chatInterno)
        {
            if (id != chatInterno.IdChat)
            {
                return BadRequest("El ID del chat no coincide con el proporcionado.");
            }
            try
            {
                var response = await _repository.PutChatInterno(chatInterno);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Chat no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteChatInterno/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteChatInterno(int id)
        {
            try
            {
                var response = await _repository.DeleteChatInterno(id);
                if (response)
                    return Ok("Eliminado correctamente");
                else
                    return NotFound("Chat no encontrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
