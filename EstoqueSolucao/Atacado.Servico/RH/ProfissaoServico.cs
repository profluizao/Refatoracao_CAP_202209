using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.RH;
using Atacado.Repositorio.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Atacado.Repositorio.Base;

namespace Atacado.Servico.RH
{
    public class ProfissaoServico : BaseServico<ProfissaoPoco, Profissao>
    {
        private GenericRepository<Profissao> genrepo;

        public ProfissaoServico() : base()
        {
            this.genrepo = new GenericRepository<Profissao>();
        }
        public override ProfissaoPoco Add(ProfissaoPoco poco)
        {
            Profissao nova = this.ConvertTo(poco);
            Profissao criada = this.genrepo.Insert(nova);
            return this.ConvertTo(criada);
        }

        public override List<ProfissaoPoco> Browse()
        {
            return this.Browse(null);
        }
        public override List<ProfissaoPoco> Browse(Expression<Func<Profissao, bool>> predicate = null)
        {
            List<ProfissaoPoco> listaPoco;
            IQueryable<Profissao> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }

            listaPoco = query.Select(pro =>
                    new ProfissaoPoco()
                    {
                        ProfissaoId = pro.ProfissaoId,
                        Descricao = pro.Descricao,
                        DataInsert = pro.DataInsert,
                        Ativo = pro.Ativo,
                    }
                )
                .ToList();
            return listaPoco;
        }
        public override ProfissaoPoco ConvertTo(Profissao dominio)
        {
            return new ProfissaoPoco()
            {
                ProfissaoId = dominio.ProfissaoId,
                Descricao = dominio.Descricao,
                DataInsert = dominio.DataInsert,
                Ativo = dominio.Ativo,
            };
        }

        public override Profissao ConvertTo(ProfissaoPoco poco)
        {
            return new Profissao()
            {
                ProfissaoId = poco.ProfissaoId,
                Descricao = poco.Descricao,
                DataInsert = poco.DataInsert,
                Ativo = poco.Ativo,
            };
        }

        public override ProfissaoPoco Delete(int chave)
        {
            Profissao del = this.genrepo.Delete(chave);
            ProfissaoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProfissaoPoco Delete(ProfissaoPoco poco)
        {
            Profissao del = this.genrepo.Delete(poco.ProfissaoId);
            ProfissaoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProfissaoPoco Edit(ProfissaoPoco poco)
        {
            Profissao editada = this.ConvertTo(poco);
            Profissao alterada = this.genrepo.Update(editada);
            ProfissaoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override ProfissaoPoco Read(int chave)
        {
            Profissao lida = this.genrepo.GetById(chave);
            ProfissaoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
