using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using Atacado.Repositorio.Base;
using Atacado.Servico.Base;

namespace Atacado.Servico.Geral
{
    public class InstituicaoBancariaServico : GenericService<InstituicaoBancaria, InstituicaoBancariaPoco>
    {
        public InstituicaoBancariaServico(ProjetoAcademiaContext context) : base(context)
        {
        }

        public override List<InstituicaoBancariaPoco> Consultar(Expression<Func<InstituicaoBancaria, bool>>? predicate = null)
        {
            IQueryable<InstituicaoBancaria> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<InstituicaoBancariaPoco> listaPoco = query.Select(ins =>
                new InstituicaoBancariaPoco()
                {
                    InstituicaoBancariaId = ins.InstituicaoBancariaId,
                    CodigoBanco = ins.CodigoBanco,
                    Descricao = ins.Descricao,
                    SiteWww = ins.SiteWww,
                    DataInsert = ins.DataInsert,
                    Ativo = ins.Ativo
                }
            )
            .ToList();
            return listaPoco;
        }
    }
}
