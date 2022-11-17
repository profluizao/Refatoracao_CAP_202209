using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.RH;
using Atacado.Repositorio.Base;
using System.Linq.Expressions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.RH
{
    public class DepartamentoServico : GenericService<Departamento, DepartamentoPoco>
    {
        public override List<DepartamentoPoco> Consultar(Expression<Func<Departamento, bool>>? predicate = null)
        {
            IQueryable<Departamento> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<DepartamentoPoco> listaPoco = query.Select(dep =>
                    new DepartamentoPoco()
                    {
                        DepartamentoId = dep.DepartamentoId,
                        Descricao = dep.Descricao,
                        DataInsert = dep.DataInsert,
                        Ativo = dep.Ativo,
                    }
                )
                .ToList();
            return listaPoco;
        }
    }
}
