using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.RH
{
    public class FuncionarioPoco
    {
        public long FuncionarioId { get; set; }
        public long Matricula { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } = null!;
        public string Ctps { get; set; } = null!;
        public long CtpsNum { get; set; }
        public int CtpsSerie { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public bool? Ativo { get; set; }
        public FuncionarioPoco()
        {
        }

    }
}
