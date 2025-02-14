using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class AlertaLocalizacaoRepository : IAlertaLocalizacaoRepository
    {
        private readonly FireSenseContext _context;
        public AlertaLocalizacaoRepository(FireSenseContext context)
        {
            _context = context;
        }

        public void Add(AlertaLocalizacao alertaLocalizacao)
        {
            _context.Add(alertaLocalizacao);
            _context.SaveChanges();
        }
    }
}
