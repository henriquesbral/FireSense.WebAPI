using FireSense.WebApi.Model.Entities;

namespace FireSense.WebApi.Model.Interfaces
{
    public interface IEstadoRepository
    {
        Estado GetUF(string uf);
    }
}
