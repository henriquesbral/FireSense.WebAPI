using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly FireSenseContext _context = new FireSenseContext();
        public Estado GetUF(string uf)
        {
            return _context.Estado.Where(x => x.SiglaEstado == uf).FirstOrDefault();
        }
    }
}
