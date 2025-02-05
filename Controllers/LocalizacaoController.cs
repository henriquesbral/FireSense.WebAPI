using Azure.Core;
using FireSense.WebApi.Infraestrutura.Interfaces;
using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FireSense.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : Controller
    {
        private readonly ILogDeAcessosRepository _logDeAcessosRepository;
        private readonly IStatusAlertaRepository _statusAlerta;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IAlertaLocalizacaoRepository _alertaLocalizacaoRepository;

        public LocalizacaoController
        (
            IUsuarioRepository usuarioRepository,
            ILogDeAcessosRepository logDeAcessosRepository,
            IStatusAlertaRepository statusAlertaRepository,
            ICidadeRepository cidadeRepository,
            IEstadoRepository estadoRepository,
            ILocalizacaoRepository localizacaoRepository,
            IAlertaLocalizacaoRepository alertaLocalizacaoRepository
        )
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _logDeAcessosRepository = logDeAcessosRepository ?? throw new ArgumentNullException(nameof(logDeAcessosRepository));
            _statusAlerta = statusAlertaRepository ?? throw new ArgumentNullException(nameof(statusAlertaRepository));
            _cidadeRepository = cidadeRepository ?? throw new ArgumentNullException(nameof(cidadeRepository));
            _estadoRepository = estadoRepository ?? throw new ArgumentNullException(nameof(estadoRepository));
            _localizacaoRepository = localizacaoRepository ?? throw new ArgumentNullException(nameof(localizacaoRepository));
            _alertaLocalizacaoRepository = alertaLocalizacaoRepository ?? throw new ArgumentNullException(nameof(alertaLocalizacaoRepository));
        }

        [Authorize]
        [HttpPost]
        [Route("/api/EnviarAlerta")]
        public async Task<IActionResult> EnviarAlerta(DadosLocalizacao dadosRequest)
        {
            try
            {
                var validacoes = ValidarDados(dadosRequest);

                if (validacoes)
                {
                    var estado = _estadoRepository.GetUF(dadosRequest.Estado.ToUpper());
                    var cidade = _cidadeRepository.GetCidade(dadosRequest.Cidade, estado.CodEstado);
                    var status = _statusAlerta.GetStatusAlerta(dadosRequest.StatusAlerta);
                    var usuario = _usuarioRepository.ObterUser(dadosRequest.CodUsuario);

                    Localizacao localizacao = new Localizacao();
                    AlertaLocalizacao alLocalizacao = new AlertaLocalizacao();

                    localizacao.NomeLocalizacao = dadosRequest.NomeLocalizacao;
                    localizacao.Latitude = dadosRequest.Latitude;
                    localizacao.Longitude = dadosRequest.Longitude;
                    localizacao.Endereco = dadosRequest.Endereco;
                    localizacao.Bairro = dadosRequest.Bairro;

                    if (estado != null)
                        localizacao.CodEstado = estado.CodEstado;

                    if (cidade != null)
                        localizacao.CodCidade = cidade.CodCidade;

                    if (usuario != null)
                        localizacao.CodUsuario = usuario.CodUsuario;

                    localizacao.DataLocalizacao = DateTime.Now;
                    localizacao.Ativo = true;

                    _localizacaoRepository.Add(localizacao);

                    alLocalizacao.CodUsuario = usuario.CodUsuario;
                    alLocalizacao.CodLocalizacao = localizacao.CodLocalizacao;
                    alLocalizacao.CodStatusAlerta = status.CodStatusAlerta;
                    alLocalizacao.DataAlerta = DateTime.Now;

                    _alertaLocalizacaoRepository.Add(alLocalizacao);

                    return Ok("Dados salvos com sucesso !");
                }
                else
                {
                    return BadRequest("Por gentileza valide os dados informados");
                }
            }
            catch (Exception ex)
            {
                string msg = $"Ocorreu um erro inesperado: {ex.Message}";
                return BadRequest(msg);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("/api/BuscarAlertas")]
        public async Task<IActionResult> BuscarAlertas()
        {
            try
            {
                return Ok("ok");
            }
            catch (Exception ex)
            {
                string msg = $"Ocorreu um erro inesperado: {ex.Message}";
                return BadRequest(msg);
            }
        }

        private bool ValidarDados(DadosLocalizacao dadosRequest)
        {

            if (dadosRequest.CodUsuario <= 0) return false;
            if (string.IsNullOrEmpty(dadosRequest.StatusAlerta)) return false;
            if (string.IsNullOrEmpty(dadosRequest.Latitude)) return false;
            if (string.IsNullOrEmpty(dadosRequest.Longitude)) return false;
            if (string.IsNullOrEmpty(dadosRequest.Cidade)) return false;
            if (string.IsNullOrEmpty(dadosRequest.Estado)) return false;
            if (string.IsNullOrEmpty(dadosRequest.Endereco)) return false;
            if (string.IsNullOrEmpty(dadosRequest.Bairro)) return false;
            if (string.IsNullOrEmpty(dadosRequest.NomeLocalizacao)) return false;

            return true;
        }

    }
}
