using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Atacado.Repositorio.Base;

namespace Atacado.Servico.RH
{
    public class ProfissaoServico : GenericService<Profissao, ProfissaoPoco>
    {

        public ProfissaoServico(ProjetoAcademiaContext context) : base(context)
        { }

        public override List<ProfissaoPoco> Consultar(Expression<Func<Profissao, bool>>? predicate = null)
        {
            IQueryable<Profissao> query;
            if(predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<ProfissaoPoco> listaPoco = query.Select(pro =>
                    new ProfissaoPoco()
                    {
                        ProfissaoId = pro.ProfissaoId,
                        Descricao = pro.Descricao,
                        DataInsert = pro.DataInsert,
                        Ativo = pro.Ativo,
                    }
                )
                .ToList();
            return listaPoco;
        }
    }
}
