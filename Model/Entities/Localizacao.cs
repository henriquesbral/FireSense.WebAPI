using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace FireSense.WebApi.Model.Entities
{
    public class Localizacao
    {
        [Key]
        public int CodLocalizacao { get; set; }

        public string NomeLocalizacao { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        [ForeignKey("Cidade")]
        public int CodCidade { get; set; }

        [ForeignKey("Estado")]
        public int CodEstado { get; set; }

        public DateTime DataLocalizacao { get; set; }

        public int CodUsuario { get; set; }

        public bool Ativo { get; set; }

    }
}
