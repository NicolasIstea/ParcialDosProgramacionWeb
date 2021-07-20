using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase, ILoginController
    {

        private readonly ILoginService _loginService;
        public LoginController(ILoginService usuarioService)
        {
            _loginService = usuarioService;
        }

        [HttpPost]
        [Route("loginUser")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login([FromBody] Usuario usuario)
        {
            Usuario usuarioEnDb;

            if(usuario == null)
            {
                return BadRequest();
            }

            if(string.IsNullOrEmpty(usuario.UsuarioNombre) || string.IsNullOrEmpty(usuario.Contraseña))
            {
                return BadRequest();
            }

            try
            {
                usuarioEnDb = await _loginService.Autenticar(usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            

            if(usuarioEnDb != null)
            {
                var tokenString = _loginService.GenerarToken(usuarioEnDb);
                return Ok(new
                {
                    usuario = usuarioEnDb,
                    token = tokenString
                });
            }

            return Unauthorized();
        }

    }
}
