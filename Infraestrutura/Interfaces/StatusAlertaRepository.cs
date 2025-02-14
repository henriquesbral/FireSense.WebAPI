using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class StatusAlertaRepository : IStatusAlertaRepository
    {
        private readonly FireSenseContext _context;

        public StatusAlertaRepository(FireSenseContext context)
        {
            _context = context;
        }
        public StatusAlerta GetStatusAlerta(string status)
        {
            return _context.StatusAlerta.Where(x => x.NomeStatus == status).FirstOrDefault();
        }
    }
}
