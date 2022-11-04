using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Geral
{
    public class PaisPoco
    {        
        public int PaisId { get; set; }
        public string Sigla { get; set; } = null!;
        public string CodigoIdioma { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime? DataInsert { get; set; }

        public PaisPoco()
        { }

    }
}
