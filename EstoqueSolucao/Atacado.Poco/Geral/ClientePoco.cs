using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Geral
{
    public class ClientePoco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = null!;
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string Documento { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string TipoPessoa { get; set; } = null!;
        public string? Endereco { get; set; }
        public bool? Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public ClientePoco()
        { }
    }
}
