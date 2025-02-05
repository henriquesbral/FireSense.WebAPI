using FireSense.WebApi.Model.Entities;

namespace FireSense.WebApi.Model.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(Usuario usuario);

        List<Usuario> Get();

        Usuario ObterAutenticar(string usuario, string senha);

        Usuario Obter(string login);

        Usuario ObterUser(int codUsuario);
    }
}
