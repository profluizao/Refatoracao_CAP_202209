
namespace ViajeFacil.Poco.Viagem
{
    public class RotaPoco
    {
        public long CodigoRota { get; set; }

        public string PontoInicial { get; set; } = null!;

        public string PontoFinal { get; set; } = null!;

        public RotaPoco()
        { }
    }
}