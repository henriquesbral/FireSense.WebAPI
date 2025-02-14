using FireSense.WebApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FireSenseInfra.Context
{
    public class FireSenseContext : DbContext
    {
        public FireSenseContext(DbContextOptions<FireSenseContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<LogDeAcessos> LogDeAcessos { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Localizacao> Localizacao { get; set; }
        public DbSet<StatusAlerta> StatusAlerta { get; set; }
        public DbSet<AlertaLocalizacao> AlertaLocalizacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("O DbContext não foi configurado corretamente.");
            }
        }
    }
}
