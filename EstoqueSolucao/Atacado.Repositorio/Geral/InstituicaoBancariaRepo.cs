using Atacado.DB.EF.Database;
using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repositorio.Geral
{
    public class InstituicaoBancariaRepo : BaseRepositorio<InstituicaoBancaria>
    {
        private ProjetoAcademiaContext contexto;

        public InstituicaoBancariaRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override InstituicaoBancaria Create(InstituicaoBancaria instancia)
        {
            this.contexto.InstituicaoBancarias.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override InstituicaoBancaria Delete(int chave)
        {
            InstituicaoBancaria del = this.Read(chave);
            if(del == null)
            {
                return null;
            }
            else
            {
                this.contexto.InstituicaoBancarias.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }

        }

        public override InstituicaoBancaria Delete(InstituicaoBancaria instancia)
        {
            return this.Delete(instancia.InstituicaoBancariaId);
        }

        public override InstituicaoBancaria Read(int chave)
        {
            return this.contexto.InstituicaoBancarias.SingleOrDefault(ins => ins.InstituicaoBancariaId == chave);
        }

        public override IQueryable<InstituicaoBancaria> Read(Expression<Func<InstituicaoBancaria, bool>> predicate = null)
        {
            if(predicate == null)
            {
                return this.contexto.InstituicaoBancarias.AsQueryable();
            }
            else
            {
                return this.contexto.InstituicaoBancarias.Where(predicate).AsQueryable();
            }
        }

        public override List<InstituicaoBancaria> Read()
        {
            return this.contexto.InstituicaoBancarias.ToList();
        }

        public override InstituicaoBancaria Update(InstituicaoBancaria instancia)
        {
            InstituicaoBancaria atu = this.Read(instancia.InstituicaoBancariaId);
            if(atu == null)
            {
                return null;
            }
            else
            {
                atu.Descricao = instancia.Descricao;
                atu.SiteWww = instancia.SiteWww;
                atu.DataInsert = instancia.DataInsert;
                atu.Ativo = instancia.Ativo;
                this.contexto.SaveChanges();
                return atu;
            }
        }
    }
}
