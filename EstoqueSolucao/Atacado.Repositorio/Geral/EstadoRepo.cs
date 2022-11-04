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
            throw new NotImplementedException();
        }

        public override Estado Delete(int chave)
        {
            throw new NotImplementedException();
        }

        public override Estado Delete(Estado instancia)
        {
            throw new NotImplementedException();
        }

        public override Estado Read(int chave)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Estado> Read(Expression<Func<Estado, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override List<Estado> Read()
        {
            throw new NotImplementedException();
        }

        public override Estado Update(Estado instancia)
        {
            throw new NotImplementedException();
        }
    }
}
