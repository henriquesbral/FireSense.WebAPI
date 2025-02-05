using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;
using System.Linq;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class LogDeAcessosRepository : ILogDeAcessosRepository
    {
        private readonly FireSenseContext _context = new FireSenseContext();

        public void Add(LogDeAcessos logAcesso)
        {
            _context.LogDeAcessos.Add(logAcesso);
            _context.SaveChanges();
        }

        public void Update(LogDeAcessos log)
        {
            _context.LogDeAcessos.Update(log);
            _context.SaveChanges();
        }

        public LogDeAcessos Obter(int codUsuario)
        {
            return _context.LogDeAcessos.Where(x => x.CodUsuario == codUsuario).FirstOrDefault();
        }
    }
}
