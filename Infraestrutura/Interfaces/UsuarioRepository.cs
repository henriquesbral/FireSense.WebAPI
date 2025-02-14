using FireSense.WebApi.Model.Entities;
using FireSense.WebApi.Model.Interfaces;
using FireSenseInfra.Context;
using Serilog;
using System.Linq;

namespace FireSenseInfra.Interfaces
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FireSenseContext _context;

        public UsuarioRepository(FireSenseContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Get()
        {
            return _context.Usuario.ToList();
        }

        public Usuario ObterAutenticar(string login, string senha)
        {
            return _context.Usuario.Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        }

        public Usuario Obter(string login)
        {
            return _context.Usuario.Where(x => x.Login == login).FirstOrDefault();
        }

        public Usuario ObterUser(int codUsuario)
        {
            return _context.Usuario.Where(x => x.CodUsuario == codUsuario).FirstOrDefault();
        }
    }
}
