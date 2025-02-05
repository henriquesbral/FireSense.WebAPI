using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireSense.WebApi.Model.Entities
{
    public class LogDeAcessos
    {
        [Key]
        public int CodLogAcesso { get; set; }

        public DateTime DataUltimoAcesso { get; set; }

        [ForeignKey("Usuario")]
        public int CodUsuario { get; set; }
    }
}
