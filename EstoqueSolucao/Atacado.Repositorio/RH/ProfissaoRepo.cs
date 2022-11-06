using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Repositorio.Base;
using Atacado.DB.EF.Database;
using System.Linq.Expressions;

namespace Atacado.Repositorio.RH
{
    public class ProfissaoRepo : BaseRepositorio<Profissao>
    {
        private ProjetoAcademiaContext contexto;
        public ProfissaoRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Profissao Create(Profissao instancia)
        {
            this.contexto.Profissoes.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override Profissao Delete(int chave)
        {
            Profissao del = this.Read(chave);
            if (chave == null)
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

        public override Profissao Delete(Profissao instancia)
        {
            return this.Delete(instancia.ProfissaoId);
        }

        public override Profissao Read(int chave)
        {
            return this.contexto.Profissoes.SingleOrDefault(pro => pro.ProfissaoId == chave);
        }

        public override IQueryable<Profissao> Read(Expression<Func<Profissao, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.contexto.Profissoes.AsQueryable();
            }
            else
            {
                return this.contexto.Profissoes.Where(predicate).AsQueryable();
            }
        }

        public override List<Profissao> Read()
        {
            return this.contexto.Profissoes.ToList();
        }

        public override Profissao Update(Profissao instancia)
        {
            Profissao atu = this.Read(instancia.ProfissaoId);
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
