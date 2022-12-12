
namespace ViajeFacil.Poco.Viagem
{
    public class PontoParadaPoco
    {
        public long CodigoPontoParada { get; set; }

        public string Descricao { get; set; } = null!;

        public string Latitude { get; set; } = null!;

        public string Longitude { get; set; } = null!;

        public long CodigoRota { get; set; }

        public PontoParadaPoco()
        { }
    }
}