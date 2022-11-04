using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Geral
{
    public class MunicipioPoco
    {        
        public int CodigoMunicipio { get; set; }
        public string NomeMunicipio { get; set; } = null!;
        public int CodigoIbge6 { get; set; }
        public int CodigoIbge7 { get; set; }
        public int Cep { get; set; }
        public int CodigoUf { get; set; }
        public string SiglaUf { get; set; } = null!;
        public string Regiao { get; set; } = null!;
        public int? Populacao { get; set; }
        public string? Porte { get; set; }
        public DateTime? DataInclusao { get; set; }
        public MunicipioPoco()
        { }

    }
}
