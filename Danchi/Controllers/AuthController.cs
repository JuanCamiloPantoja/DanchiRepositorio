using Danchi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Danchi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AutenticacionUsuario autenticacionUsuario)
        {
            if (autenticacionUsuario == null || string.IsNullOrEmpty(autenticacionUsuario.Usuario) || string.IsNullOrEmpty(autenticacionUsuario.Contraseña))
            {
                return BadRequest("Invalid client request");
            }

            // Obtener las credenciales desde la configuración
            var configuredUsername = _configuration["Auth:Username"];
            var configuredPassword = _configuration["Auth:Password"];

            // Verificar las credenciales
            if (autenticacionUsuario.Usuario == configuredUsername && autenticacionUsuario.Contraseña == configuredPassword)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, autenticacionUsuario.Usuario), // Usamos el email como nombre de usuario
                    new Claim(ClaimTypes.Role, "Admin") // Puedes ajustar el rol según sea necesario
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
