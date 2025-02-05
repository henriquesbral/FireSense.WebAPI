using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly FireSenseContext _context = new FireSenseContext();

        public void Add(Localizacao localizacao)
        {
            _context.Add(localizacao);
            _context.SaveChanges();
        }

        public Localizacao ObterCodLocal(int codUsuario)
        {
            return _context.Localizacao.Where(x => x.CodUsuario == codUsuario).FirstOrDefault();
        }
    }
}
