using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using Atacado.Repositorio.Base;
using Atacado.Servico.Base;

namespace Atacado.Servico.Geral
{
    public class InstituicaoBancariaServico : BaseServico<InstituicaoBancariaPoco, InstituicaoBancaria>
    {
        private GenericRepository<InstituicaoBancaria> genrepo;

        public InstituicaoBancariaServico() : base()
        {
            this.genrepo = new GenericRepository<InstituicaoBancaria>();
        }
        public override InstituicaoBancariaPoco Add(InstituicaoBancariaPoco poco)
        {
            InstituicaoBancaria nova = this.ConvertTo(poco);
            InstituicaoBancaria criada = this.genrepo.Insert(nova);
            return this.ConvertTo(criada);
        }

        public override List<InstituicaoBancariaPoco> Browse()
        {
            return this.Browse(null);
        }
        public override List<InstituicaoBancariaPoco> Browse(Expression<Func<InstituicaoBancaria, bool>> predicate = null)
        {
            List<InstituicaoBancariaPoco> listaPoco;
            IQueryable<InstituicaoBancaria> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }

            listaPoco = query.Select(ins =>
                    new InstituicaoBancariaPoco()
                    {
                        InstituicaoBancariaId = ins.InstituicaoBancariaId,
                        CodigoBanco = ins.CodigoBanco,
                        Descricao = ins.Descricao,
                        SiteWww = ins.SiteWww,
                        DataInsert = ins.DataInsert,
                        Ativo = ins.Ativo
                    }
                )
                .ToList();
            return listaPoco;
        }

        public override InstituicaoBancariaPoco ConvertTo(InstituicaoBancaria dominio)
        {
            return new InstituicaoBancariaPoco()
            {
                InstituicaoBancariaId = dominio.InstituicaoBancariaId,
                CodigoBanco = dominio.CodigoBanco,
                Descricao = dominio.Descricao,
                SiteWww = dominio.SiteWww,
                DataInsert = dominio.DataInsert,
                Ativo = dominio.Ativo
            };
        }

        public override InstituicaoBancaria ConvertTo(InstituicaoBancariaPoco poco)
        {
            return new InstituicaoBancaria()
            {
                InstituicaoBancariaId = poco.InstituicaoBancariaId,
                CodigoBanco = poco.CodigoBanco,
                Descricao = poco.Descricao,
                SiteWww = poco.SiteWww,
                DataInsert = poco.DataInsert,
                Ativo = poco.Ativo
            };
        }

        public override InstituicaoBancariaPoco Delete(int chave)
        {
            InstituicaoBancaria del = this.genrepo.Delete(chave);
            InstituicaoBancariaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override InstituicaoBancariaPoco Delete(InstituicaoBancariaPoco poco)
        {
            InstituicaoBancaria del = this.genrepo.Delete(poco.InstituicaoBancariaId);
            InstituicaoBancariaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override InstituicaoBancariaPoco Edit(InstituicaoBancariaPoco poco)
        {
            InstituicaoBancaria editada = this.ConvertTo(poco);
            InstituicaoBancaria alterada = this.genrepo.Update(editada);
            InstituicaoBancariaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override InstituicaoBancariaPoco Read(int chave)
        {
            InstituicaoBancaria lida = this.genrepo.GetById(chave);
            InstituicaoBancariaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
