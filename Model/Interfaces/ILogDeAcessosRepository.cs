using FireSense.WebApi.Model.Entities;

namespace FireSense.WebApi.Model.Interfaces
{
    public interface ILogDeAcessosRepository
    {
        void Add(LogDeAcessos logDeAcessos);

        void Update(LogDeAcessos newLog);

        LogDeAcessos Obter(int codUsuario);
    }
}
