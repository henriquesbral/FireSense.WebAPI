using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FireSense.WebApi.Model.Entities
{
    public class Usuario
    {
        #region Propries
        [Key]
        public int CodUsuario { get; set; }

        public string Login { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        [ForeignKey("PerfilUsuario")]
        public int CodPerfil { get; set; }
        #endregion

    }
}
