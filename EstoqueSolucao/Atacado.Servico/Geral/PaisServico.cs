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
    public class PaisServico : BaseServico<PaisPoco, Pais>
    {
        private PaisRepo repo;

        public PaisServico() : base()
        {
            this.repo = new PaisRepo();
        }

        public override PaisPoco Add(PaisPoco poco)
        {
            Pais nova = this.ConvertTo(poco);
            Pais criada = this.repo.Create(nova);
            return this.ConvertTo(criada);
        }

        public override List<PaisPoco> Browse()
        {
            return this.Browse(null);
        }
        public override List<PaisPoco> Browse(Expression<Func<Pais, bool>> predicate = null)
        {
            List<PaisPoco> listaPoco;
            IQueryable<Pais> query;
            if (predicate == null)
            {
                query = this.repo.Read(null);
            }
            else
            {
                query = this.repo.Read(predicate);
            }

            listaPoco = query.Select(pai =>
                    new PaisPoco()
                    {
                        PaisId = pai.PaisId,
                        Sigla = pai.Sigla,
                        CodigoIdioma = pai.CodigoIdioma,
                        Descricao = pai.Descricao,
                        DataInsert = pai.DataInsert
                    }
                )
                .ToList();
            return listaPoco;
        }
        public override PaisPoco ConvertTo(Pais dominio)
        {
            return new PaisPoco()
            {
                PaisId = dominio.PaisId,
                Sigla = dominio.Sigla,
                CodigoIdioma = dominio.CodigoIdioma,
                Descricao = dominio.Descricao,
                DataInsert = dominio.DataInsert
            };
        }

        public override Pais ConvertTo(PaisPoco poco)
        {
            return new Pais()
            {
                PaisId = poco.PaisId,
                Sigla = poco.Sigla,
                CodigoIdioma = poco.CodigoIdioma,
                Descricao = poco.Descricao,
                DataInsert = poco.DataInsert
            };
        }

        public override PaisPoco Delete(int chave)
        {
            Pais del = this.repo.Delete(chave);
            PaisPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override PaisPoco Delete(PaisPoco poco)
        {
            Pais del = this.repo.Delete(poco.PaisId);
            PaisPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override PaisPoco Edit(PaisPoco poco)
        {
            Pais editada = this.ConvertTo(poco);
            Pais alterada = this.repo.Update(editada);
            PaisPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override PaisPoco Read(int chave)
        {
            Pais lida = this.repo.Read(chave);
            PaisPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
