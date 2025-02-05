using FireSense.WebApi.Model.Interfaces;
using FireSense.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FireSense.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogDeAcessosRepository _logDeAcessosRepository;

        public AuthController(IUsuarioRepository usuarioRepository, ILogDeAcessosRepository logDeAcessosRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _logDeAcessosRepository = logDeAcessosRepository ?? throw new ArgumentNullException(nameof(logDeAcessosRepository));
        }

        [HttpPost]
        public async Task<IActionResult> Auth(string usuario, string senha)
        {
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha))
            {
                var user = _usuarioRepository.ObterAutenticar(usuario, senha);
                var token = TokenService.GenerateToken(user);

                return Ok(token);
            }

            return BadRequest("Usuario ou senha inválidos");
        }
    }
}
