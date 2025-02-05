using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireSense.WebApi.Model.Entities
{
    public class AlertaLocalizacao
    {
        [Key]
        public int CodAlertaLocalizacao { get; set; }

        [ForeignKey("Usuario")]
        public int CodUsuario { get; set; }

        [ForeignKey("Localizacao")]
        public int CodLocalizacao { get; set; }

        [ForeignKey("StatusAlerta")]
        public int CodStatusAlerta { get; set; }

        public DateTime DataAlerta { get; set; }
    }
}
