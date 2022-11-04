using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Geral
{
    public class InstituicaoBancariaPoco
    {        
        public int InstituicaoBancariaId { get; set; }
        public int? CodigoBanco { get; set; }
        public string Descricao { get; set; } = null!;
        public string SiteWww { get; set; } = null!;
        public DateTime? DataInsert { get; set; }
        public bool? Ativo { get; set; }
        public InstituicaoBancariaPoco()
        { }
    }
}
