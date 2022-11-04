using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.DB.EF.Database;
using Atacado.Repositorio.Base;
using System.Linq.Expressions;

namespace Atacado.Repositorio.RH
{
    public class DepartamentoRepo : BaseRepositorio<Departamento>
    {
        private ProjetoAcademiaContext contexto;
        public DepartamentoRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Departamento Create(Departamento instancia)
        {
            this.contexto.Departamentos.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override Departamento Delete(int chave)
        {
            Departamento del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }
        }

        public override Departamento Delete(Departamento instancia)
        {
            return this.Delete(instancia.DepartamentoId);
        }

        public override Departamento Read(int chave)
        {
            return this.contexto.Departamentos.SingleOrDefault(dep => dep.DepartamentoId == chave);
        }

        public override IQueryable<Departamento> Read(Expression<Func<Departamento, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.contexto.Departamentos.AsQueryable();
            }
            else
            {
                return this.contexto.Departamentos.Where(predicate).AsQueryable();
            }
        }

        public override List<Departamento> Read()
        {
            return this.contexto.Departamentos.ToList();
        }

        public override Departamento Update(Departamento instancia)
        {
            Departamento atu = this.Read(instancia.DepartamentoId);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Descricao = instancia.Descricao;
                atu.Ativo = instancia.Ativo;
                this.contexto.SaveChanges();
                return atu;
            }
        }
    }
}
