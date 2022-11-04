using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repositorio.Estoque;
using System.Linq.Expressions;
using Atacado.Poco.Geral;
using System.Net;
using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using Atacado.Repositorio.Geral;

namespace Atacado.Servico.Geral
{
    public class InstituicaoBancariaServico : BaseServico<InstituicaoBancariaPoco, InstituicaoBancaria>
    {
        private InstituicaoBancariaRepo repo;

        public InstituicaoBancariaServico() : base()
        {
            this.repo = new InstituicaoBancariaRepo();
        }
        public override InstituicaoBancariaPoco Add(InstituicaoBancariaPoco poco)
        {
            InstituicaoBancaria nova = this.ConvertTo(poco);
            InstituicaoBancaria criada = this.repo.Create(nova);
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
                query = this.repo.Read(null);
            }
            else
            {
                query = this.repo.Read(predicate);
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
            InstituicaoBancaria del = this.repo.Delete(chave);
            InstituicaoBancariaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override InstituicaoBancariaPoco Delete(InstituicaoBancariaPoco poco)
        {
            InstituicaoBancaria del = this.repo.Delete(poco.InstituicaoBancariaId);
            InstituicaoBancariaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override InstituicaoBancariaPoco Edit(InstituicaoBancariaPoco poco)
        {
            InstituicaoBancaria editada = this.ConvertTo(poco);
            InstituicaoBancaria alterada = this.repo.Update(editada);
            InstituicaoBancariaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override InstituicaoBancariaPoco Read(int chave)
        {
            InstituicaoBancaria lida = this.repo.Read(chave);
            InstituicaoBancariaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
