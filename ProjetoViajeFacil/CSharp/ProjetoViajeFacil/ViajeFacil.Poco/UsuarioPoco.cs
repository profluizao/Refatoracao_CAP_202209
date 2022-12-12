namespace ViajeFacil.Poco
{
    public class UsuarioPoco
    {
        public long CodigoUsuario { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string CPF { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public long CodigoEndereco { get; set; }

        public long CodigoTipoUsuario { get; set; }

        public long CodigoInstituicao { get; set; }

        public UsuarioPoco()
        { }
    }
}