using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class StatusAlertaRepository : IStatusAlertaRepository
    {
        private readonly FireSenseContext _context = new FireSenseContext();
        public StatusAlerta GetStatusAlerta(string status)
        {
            return _context.StatusAlerta.Where(x => x.NomeStatus == status).FirstOrDefault();
        }
    }
}
