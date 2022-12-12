
namespace ViajeFacil.Poco
{
    public class InstituicaoPoco
    {
        public long CodigoInstituicao { get; set; }

        public string Nome { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public long CodigoEndereco { get; set; }

        public InstituicaoPoco()
        { }
    }
}