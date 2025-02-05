using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireSense.WebApi.Model.Entities
{
    public class Cidade
    {
        [Key]
        public int CodCidade { get; set; }

        public string NomeCidade { get; set; }

        [ForeignKey("Estado")]
        public int CodEstado { get; set; }
    }
}
