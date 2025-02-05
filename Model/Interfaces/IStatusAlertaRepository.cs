using FireSense.WebApi.Model.Entities;

namespace FireSense.WebApi.Model.Interfaces
{
    public interface IStatusAlertaRepository
    {
        StatusAlerta GetStatusAlerta(string status);
    }
}
