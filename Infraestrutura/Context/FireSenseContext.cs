using FireSense.WebApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FireSenseInfra.Context
{
    public class FireSenseContext : DbContext
    {
        #region Propries
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<LogDeAcessos> LogDeAcessos { get; set; }

        public DbSet<PerfilUsuario> PerfilUsuario { get; set; }

        public DbSet<Cidade> Cidade { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<Localizacao> Localizacao { get; set; }

        public DbSet<StatusAlerta> StatusAlerta { get; set; }

        public DbSet<AlertaLocalizacao> AlertaLocalizacao { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer("Server=LENOVOHENRIQUE\\SQLEXPRESS; Database=FireSenseDB; User=APS2024; Password=140612; Trusted_Connection=False; TrustServerCertificate=true");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
