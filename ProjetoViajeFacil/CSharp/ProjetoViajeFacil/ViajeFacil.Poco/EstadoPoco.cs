
namespace ViajeFacil.Poco.Viagem
{
    public class EstadoPoco
    {
        public long CodigoEstado { get; set; }

        public string Nome { get; set; } = null!;

        public long? CodigoUF { get; set; }

        public string SiglaUF { get; set; } = null!;

        public long CodigoRegiao { get; set; }

        public EstadoPoco()
        { }
    }
}