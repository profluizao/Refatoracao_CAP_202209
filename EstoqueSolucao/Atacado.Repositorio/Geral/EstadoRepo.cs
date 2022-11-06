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
    public class EstadoRepo : BaseRepositorio<Estado>
    {
        private ProjetoAcademiaContext contexto;

        public EstadoRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Estado Create(Estado instancia)
        {
            this.contexto.Estados.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override Estado Delete(int chave)
        {
            Estado del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Estados.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }
        }

        public override Estado Delete(Estado instancia)
        {
            return this.Delete(instancia.CodigoUf);
        }

        public override Estado Read(int chave)
        {
            return this.contexto.Estados.SingleOrDefault(est => est.CodigoUf == chave);
        }

        public override IQueryable<Estado> Read(Expression<Func<Estado, bool>> predicate = null)
        {
            if(predicate == null)
            {
                return this.contexto.Estados.AsQueryable();
            }
            else
            {
                return this.contexto.Estados.Where(predicate).AsQueryable();
            }
        }

        public override List<Estado> Read()
        {
            return this.contexto.Estados.ToList();
        }

        public override Estado Update(Estado instancia)
        {
            Estado atu = this.Read(instancia.CodigoUf);
            if(atu == null)
            {
                return null;
            }
            else
            {
                atu.SiglaUf = instancia.SiglaUf;
                atu.DescricaoUf = instancia.DescricaoUf;
                this.contexto.SaveChanges();
                return atu;
            }
        }
    }
}
