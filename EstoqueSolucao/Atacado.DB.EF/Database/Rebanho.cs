using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.EF.Database
{
    [Table("Rebanho", Schema = "dbo")]
    public partial class Rebanho
    {
        [Key]
        [Column("ID_Rebanho")]
        public int CodigoRebanho { get; set; }

        [Column(name: "Ano_Ref")]
        public int AnoReferencia { get; set; }

        [Column(name: "ID_Municipio")]
        public int CodigoMunicipio { get; set; }

        [Column(name: "ID_Tipo_Rebanho")]
        public int CodigoTipoRebanho { get; set; }

        [Column(name: "Tipo_Rebanho")]
        [Unicode(false)]
        public string TipoRebanho { get; set; } = null!;

        [Column(name: "Quantidade")]
        public int? Quantidade { get; set; }

        [Column(name: "Situacao")]
        public bool? Situacao { get; set; }

        [Column(name: "DataInclusao",TypeName = "dateTime")]
        public DateTime? DataInclusao { get; set; }

        [Column(name: "DataAlteracao",TypeName = "dateTime")]
        public DateTime? DataAlteracao { get; set; }

        [Column(name: "DataExclusao",TypeName = "dateTime")]
        public DateTime? DataExclusao { get; set; }
    }
}
