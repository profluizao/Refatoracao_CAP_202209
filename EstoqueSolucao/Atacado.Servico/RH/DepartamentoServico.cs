using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.RH;
using Atacado.Repositorio.Base;
using System.Linq.Expressions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.RH
{
    public class DepartamentoServico : BaseServico<DepartamentoPoco, Departamento>
    {
        private GenericRepository<Departamento> genrepo;

        public DepartamentoServico() : base()
        {
            this.genrepo = new GenericRepository<Departamento>();
        }
        public override DepartamentoPoco Add(DepartamentoPoco poco)
        {
            Departamento nova = this.ConvertTo(poco);
            Departamento criada = this.genrepo.Insert(nova);
            return this.ConvertTo(criada);
        }

        public override List<DepartamentoPoco> Browse()
        {
            return this.Browse(null);
        }
        public override List<DepartamentoPoco> Browse(Expression<Func<Departamento, bool>> predicate = null)
        {
            List<DepartamentoPoco> listaPoco;
            IQueryable<Departamento> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }

            listaPoco = query.Select(dep =>
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
        public override DepartamentoPoco ConvertTo(Departamento dominio)
        {
            return new DepartamentoPoco()
            {
                DepartamentoId = dominio.DepartamentoId,
                Descricao = dominio.Descricao,
                DataInsert = dominio.DataInsert,
                Ativo = dominio.Ativo,
            };
        }

        public override Departamento ConvertTo(DepartamentoPoco poco)
        {
            return new Departamento()
            {
                DepartamentoId = poco.DepartamentoId,
                Descricao = poco.Descricao,
                DataInsert = poco.DataInsert,
                Ativo = poco.Ativo,
            };
        }

        public override DepartamentoPoco Delete(int chave)
        {
            Departamento del = this.genrepo.Delete(chave);
            DepartamentoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override DepartamentoPoco Delete(DepartamentoPoco poco)
        {
            Departamento del = this.genrepo.Delete(poco.DepartamentoId);
            DepartamentoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override DepartamentoPoco Edit(DepartamentoPoco poco)
        {
            Departamento editada = this.ConvertTo(poco);
            Departamento alterada = this.genrepo.Update(editada);
            DepartamentoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override DepartamentoPoco Read(int chave)
        {
            Departamento lida = this.genrepo.GetById(chave);
            DepartamentoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
