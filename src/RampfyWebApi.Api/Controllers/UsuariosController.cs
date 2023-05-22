using Microsoft.AspNetCore.Mvc;
using RampfyWebApi.Application.Authorize;
using RampfyWebApi.Application.HttpModels;
using RampfyWebApi.Application.Interfaces;
using RampfyWebApi.Application.ViewModels;

namespace RampfyWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationRequest request)
        {
            AuthenticationResponse response = null;
            try
            {
                response = await _usuarioAppService.AuthenticationAsync(request);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }

            if (response == null || string.IsNullOrEmpty(response.Token))
                return BadRequest(new { message = "Usuário ou senha inválido." });

            return Ok(response);
        }

        #region uso futuro
        // GET: api/<UsuariosController>
        [HttpGet]
        private async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<UsuarioViewModel> usuarios = await _usuarioAppService.GetTodosAsync();

                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }

        // POST api/<UsuariosController>
        [HttpPost]
        private async Task<IActionResult> Post([FromBody] UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _usuarioAppService.AdicionarAsync(usuario);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }
        #endregion
    }
}
