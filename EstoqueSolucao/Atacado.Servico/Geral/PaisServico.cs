using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using Atacado.Repositorio.Base;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Geral
{
    public class PaisServico : GenericService<Pais, PaisPoco>
    {
        public PaisServico(ProjetoAcademiaContext context) : base(context)
        { }

        public override List<PaisPoco> Consultar(Expression<Func<Pais, bool>>? predicate = null)
        {
            IQueryable<Pais> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<PaisPoco> listaPoco = query.Select(pai =>
                    new PaisPoco()
                    {
                        PaisId = pai.PaisId,
                        Sigla = pai.Sigla,
                        CodigoIdioma = pai.CodigoIdioma,
                        Descricao = pai.Descricao,
                        DataInsert = pai.DataInsert
                    }
                )
                .ToList();
            return listaPoco;
        }
    }
}
