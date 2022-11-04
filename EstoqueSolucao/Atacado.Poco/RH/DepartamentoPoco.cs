using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.RH
{
    public class DepartamentoPoco
    {

        public int DepartamentoId { get; set; }
        public string Descricao { get; set; } = null!;
        public DateTime? DataInsert { get; set; }
        public bool? Ativo { get; set; }
        public DepartamentoPoco()
        {
        }

    }
}
