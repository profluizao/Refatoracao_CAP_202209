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
    public class PaisRepo : BaseRepositorio<Pais>
    {
        private ProjetoAcademiaContext contexto;

        public PaisRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Pais Create(Pais instancia)
        {
            this.contexto.Paises.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override Pais Delete(int chave)
        {
            Pais del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Paises.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }
        }

        public override Pais Delete(Pais instancia)
        {
            return this.Delete(instancia.PaisId);
        }

        public override Pais Read(int chave)
        {
            return this.contexto.Paises.SingleOrDefault(pai => pai.PaisId == chave);
        }

        public override IQueryable<Pais> Read(Expression<Func<Pais, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.contexto.Paises.AsQueryable();
            }
            else
            {
                return this.contexto.Paises.Where(predicate).AsQueryable();
            }
        }

        public override List<Pais> Read()
        {
            return this.contexto.Paises.ToList();
        }

        public override Pais Update(Pais instancia)
        {
            Pais atu = this.Read(instancia.PaisId);
            if(atu == null)
            {
                return null;
            }
            else
            {
                atu.Sigla = instancia.Sigla;
                atu.CodigoIdioma = instancia.CodigoIdioma;
                atu.Descricao = instancia.Descricao;
                this.contexto.SaveChanges();
                return atu;
            }
        }
    }
}
