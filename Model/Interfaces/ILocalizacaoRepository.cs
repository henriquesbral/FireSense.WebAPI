using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.ViewModel;

namespace FireSense.WebApi.Model.Interfaces
{
    public interface ILocalizacaoRepository
    {
        void Add(Localizacao localizacao);

        Localizacao ObterCodLocal(int codUsuario);

        List<AlertasViewModel> BuscarAlertas();

    }
}
