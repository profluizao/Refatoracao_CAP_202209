using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using Atacado.Repositorio.Geral;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Geral
{
    public class EstadoServico : BaseServico<EstadoPoco, Estado>
    {
        private EstadoRepo repo;

        public EstadoServico() : base()
        {
            this.repo = new EstadoRepo();
        }

        public override EstadoPoco Add(EstadoPoco poco)
        {
            Estado nova = this.ConvertTo(poco);
            Estado criada = this.repo.Create(nova);
            return this.ConvertTo(criada);
        }

        public override List<EstadoPoco> Browse()
        {
            return this.Browse(null);
        }
        public override List<EstadoPoco> Browse(Expression<Func<Estado, bool>> predicate = null)
        {
            List<EstadoPoco> listaPoco;
            IQueryable<Estado> query;
            if (predicate == null)
            {
                query = this.repo.Read(null);
            }
            else
            {
                query = this.repo.Read(predicate);
            }

            listaPoco = query.Select(est =>
                    new EstadoPoco()
                    {
                        CodigoUf = est.CodigoUf,
                        SiglaUf = est.SiglaUf,
                        DescricaoUf = est.DescricaoUf
                    }
                )
                .ToList();
            return listaPoco;
        }
        public override EstadoPoco ConvertTo(Estado dominio)
        {
            return new EstadoPoco()
            {
                CodigoUf = dominio.CodigoUf,
                SiglaUf = dominio.SiglaUf,
                DescricaoUf = dominio.DescricaoUf
            };
        }

        public override Estado ConvertTo(EstadoPoco poco)
        {
            return new Estado()
            {
                CodigoUf = poco.CodigoUf,
                SiglaUf = poco.SiglaUf,
                DescricaoUf = poco.DescricaoUf
            };
        }

        public override EstadoPoco Delete(int chave)
        {
            Estado del = this.repo.Delete(chave);
            EstadoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override EstadoPoco Delete(EstadoPoco poco)
        {
            Estado del = this.repo.Delete(poco.CodigoUf);
            EstadoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override EstadoPoco Edit(EstadoPoco poco)
        {
            Estado editada = this.ConvertTo(poco);
            Estado alterada = this.repo.Update(editada);
            EstadoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override EstadoPoco Read(int chave)
        {
            Estado lida = this.repo.Read(chave);
            EstadoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
