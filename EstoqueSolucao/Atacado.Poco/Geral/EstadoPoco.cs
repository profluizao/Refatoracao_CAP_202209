using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Geral
{
    public class EstadoPoco
    {        
        public int CodigoUf { get; set; }
        public string SiglaUf { get; set; } = null!;
        public string? DescricaoUf { get; set; }

        public EstadoPoco()
        { }
    }
}
