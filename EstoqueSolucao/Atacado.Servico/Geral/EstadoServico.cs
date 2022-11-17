using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using Atacado.Repositorio.Base;
using Atacado.Servico.Base;

namespace Atacado.Servico.Geral
{
    public class EstadoServico : GenericService<Estado, EstadoPoco>
    {
        public override List<EstadoPoco> Consultar(Expression<Func<Estado, bool>>? predicate = null)
        {
            IQueryable<Estado> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<EstadoPoco> listaPoco = query.Select(est =>
                new EstadoPoco()
                {
                    CodigoUf = est.CodigoUf,
                    SiglaUf = est.SiglaUf,
                    DescricaoUf = est.DescricaoUf
                }
            )
            .ToList();
            return listaPoco;
        }
    }
}
