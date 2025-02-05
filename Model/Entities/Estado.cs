using System.ComponentModel.DataAnnotations;

namespace FireSense.WebApi.Model.Entities
{
    public class Estado
    {
        [Key]
        public int CodEstado { get; set; }

        public string NomeEstado { get; set; }

        public string SiglaEstado { get; set; }
    }
}
