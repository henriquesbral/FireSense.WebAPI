using System.Numerics;

namespace FireSense.WebApi.ViewModel
{
    public class AlertasViewModel
    {
        public int CodAlerta { get; set; }
        public string StatusAlerta { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? Ativo { get; set; }
    }
}
