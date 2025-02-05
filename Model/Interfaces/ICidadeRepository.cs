using FireSense.WebApi.Model.Entities;

namespace FireSense.WebApi.Model.Interfaces
{
    public interface ICidadeRepository
    {
        Cidade GetCidade(string cidade, int uf);
    }
}
