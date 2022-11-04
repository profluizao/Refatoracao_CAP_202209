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
            throw new NotImplementedException();
        }

        public override IQueryable<InstituicaoBancaria> Read(Expression<Func<InstituicaoBancaria, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override List<InstituicaoBancaria> Read()
        {
            throw new NotImplementedException();
        }

        public override InstituicaoBancaria Update(InstituicaoBancaria instancia)
        {
            throw new NotImplementedException();
        }
    }
}
