using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSense.WebApi.ViewModel;
using FireSenseInfra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly FireSenseContext _context;

        public LocalizacaoRepository(FireSenseContext context)
        {
            _context = context;
        }

        public void Add(Localizacao localizacao)
        {
            _context.Add(localizacao);
            _context.SaveChanges();
        }

        public List<AlertasViewModel> BuscarAlertas()
        {
            return _context.Database.SqlQuery<AlertasViewModel>($"EXEC SP_BuscarAlertas").ToList();
        }

        public Localizacao ObterCodLocal(int codUsuario)
        {
            return _context.Localizacao.Where(x => x.CodUsuario == codUsuario).FirstOrDefault();
        }
    }
}
