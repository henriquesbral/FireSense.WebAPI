using FireSense.WebApi.Infraestrutura.Interfaces;
using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSense.WebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FireSense.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogDeAcessosRepository _logDeAcessosRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogDeAcessosRepository logDeAcessosRepository) 
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _logDeAcessosRepository = logDeAcessosRepository ?? throw new ArgumentNullException(nameof(logDeAcessosRepository));
        }

        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/Adicionar")]
        public async Task<IActionResult> Adicionar(UsuarioViewModel usuarioView)
        {
            try
            {
                if (!string.IsNullOrEmpty(usuarioView.Nome) && !string.IsNullOrEmpty(usuarioView.Sobrenome) && !string.IsNullOrEmpty(usuarioView.Senha))
                {
                    var usuario = new Usuario();

                    usuario.Login = GerarLogin(usuarioView.Nome, usuarioView.Sobrenome).ToUpper();
                    usuario.Nome = $"{usuarioView.Nome}  {usuarioView.Sobrenome}";
                    usuario.Senha = usuarioView.Senha;
                    usuario.DataCadastro = DateTime.Now;
                    usuario.CodPerfil = 2;
                    _usuarioRepository.Add(usuario);

                    return Ok($"Usuario cadastrado, seu login é {usuario.Login}");
                }
                else
                {
                    return BadRequest("Por gentileza preencher os dados !");
                }
            }
            catch (Exception ex) 
            { 
                string msg = $"Ocorreu um erro inesperado: { ex.Message}";
                return BadRequest(msg);
            }
            
        }

        [Authorize]
        [HttpPut]
        [Route("/api/[controller]/AlterarSenha")]
        public async Task<IActionResult> AlterarSenha(AlterarSenhaViewModel novaSenha)
        {
            try
            {
                var usuario = _usuarioRepository.Obter(novaSenha.Login);

                if(usuario != null)
                {

                    if (novaSenha.NovaSenha != novaSenha.ConfirmaSenha)
                        return BadRequest("As senhas não são iguais, por gentileza verificar novamente !");

                    if (usuario.Login == novaSenha.Login && novaSenha.NovaSenha == novaSenha.ConfirmaSenha)
                    {
                        usuario.Senha = novaSenha.NovaSenha;
                        _usuarioRepository.Update(usuario);
                        return Ok("Senha atualizada");
                    }
                    else
                    {
                        return BadRequest("Usuario não encontrado, por favor acione a equipe de desenvolvimento.");
                    }
                }
                else
                {
                    return BadRequest($"Usuario não encontrado, por favor acione a equipe de desenvolvimento.");
                }
            }
            catch (Exception ex)
            {
                string msg = $"Ocorreu um erro inesperado: {ex.Message}";
                return BadRequest(msg);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/Autenticar")]
        public async Task<IActionResult> Autenticar(AutenticarViewModel user)
        {
            try
            {
                var usuario = _usuarioRepository.ObterAutenticar(user.Usuario, user.Senha);
                
                if (usuario == null)
                    return BadRequest("Usuario não encontrado, por favor acione a equipe de desenvolvimento.");

                if (usuario.Login != user.Usuario && usuario.Senha != user.Senha)
                {
                    return BadRequest("Usuario e ou senha incorretos, por gentileza validar novamente!");
                }
                else
                {
                    var log = _logDeAcessosRepository.Obter(usuario.CodUsuario);
                    
                    if (log != null && log.CodUsuario == usuario.CodUsuario)
                    {
                        log.DataUltimoAcesso = DateTime.Now;
                        _logDeAcessosRepository.Update(log);
                    }
                    else
                    {
                        var newLog = new LogDeAcessos();

                        newLog.CodUsuario = usuario.CodUsuario;
                        newLog.DataUltimoAcesso = DateTime.Now;
                        _logDeAcessosRepository.Add(newLog);
                    }

                    return Ok(usuario);
                }
            }
            catch (Exception ex)
            {
                string msg = $"Ocorreu um erro inesperado: {ex.Message}";
                return BadRequest(msg);
            }
        }

        private string GerarLogin(string nome, string sobrenome)
        {
            string tratarNome = nome.Replace(" ",",");
            string[] tratarN = tratarNome.Split(',');

            string tratarSobrenome = sobrenome.Replace(" ", ",");
            string[] tratarS = tratarSobrenome.Split(',');


            string login = $"{tratarN[0]}.{tratarS[0]}";

            return login;
        }
    }
}
