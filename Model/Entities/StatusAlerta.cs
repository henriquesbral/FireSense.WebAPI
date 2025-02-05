using System.ComponentModel.DataAnnotations;

namespace FireSense.WebApi.Model.Entities
{
    public class StatusAlerta
    {
        [Key]
        public int CodStatusAlerta { get; set; }

        public string NomeStatus { get; set; }
    }
}
