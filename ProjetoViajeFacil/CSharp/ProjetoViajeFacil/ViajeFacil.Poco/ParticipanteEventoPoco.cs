
namespace ViajeFacil.Poco
{
    public class ParticipanteEventoPoco
    {
        public long CodigoParticipante { get; set; }

        public int Pagamento { get; set; }

        public string Sugestao { get; set; } = null!;

        public int? Avaliacao { get; set; }

        public long CodigoEvento { get; set; }

        public long CodigoUsuario { get; set; }

        public ParticipanteEventoPoco()
        { }
    }
}