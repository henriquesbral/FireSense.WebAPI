using FireSense.WebApi.Model.Interfaces;
using FireSense.WebApi.Services;
using FireSense.WebApi.ViewModel;
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
        public async Task<IActionResult> Auth(AuthViewModel auth)
        {
            if (!string.IsNullOrEmpty(auth.Usuario) && !string.IsNullOrEmpty(auth.Senha))
            {
                var user = _usuarioRepository.ObterAutenticar(auth.Usuario, auth.Senha);
                var token = TokenService.GenerateToken(user);

                return Ok(token);
            }

            return BadRequest("Usuario ou senha inválidos");
        }
    }
}
