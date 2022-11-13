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

        public override EstadoPoco ConverterPara(Estado obj)
        {
            return new EstadoPoco()
            {
                CodigoUf = obj.CodigoUf,
                SiglaUf = obj.SiglaUf,
                DescricaoUf = obj.DescricaoUf
            };
        }

        public override Estado ConverterPara(EstadoPoco obj)
        {
            return new Estado()
            {
                CodigoUf = obj.CodigoUf,
                SiglaUf = obj.SiglaUf,
                DescricaoUf = obj.DescricaoUf
            };
        }
    }
}
