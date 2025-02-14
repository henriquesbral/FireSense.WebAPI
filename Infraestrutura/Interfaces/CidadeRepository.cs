using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;

namespace FireSense.WebApi.Infraestrutura.Interfaces
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly FireSenseContext _context;

        public CidadeRepository(FireSenseContext context)
        {
            _context = context;
        }
        public Cidade GetCidade(string cidade, int uf)
        {
            return _context.Cidade.Where(x => x.NomeCidade == cidade && x.CodEstado == uf).FirstOrDefault();
        }
    }
}
