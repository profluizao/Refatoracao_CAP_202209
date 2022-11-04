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
    public class MunicipioServico : BaseServico<MunicipioPoco, Municipio>
    {
        private MunicipioRepo repo;

        public MunicipioServico() : base()
        {
            this.repo = new MunicipioRepo();
        }
        public override MunicipioPoco Add(MunicipioPoco poco)
        {
            Municipio nova = this.ConvertTo(poco);
            Municipio criada = this.repo.Create(nova);
            return this.ConvertTo(criada);
        }

        public override List<MunicipioPoco> Browse()
        {
            return this.Browse(null);
        }
        public override List<MunicipioPoco> Browse(Expression<Func<Municipio, bool>> predicate = null)
        {
            List<MunicipioPoco> listaPoco;
            IQueryable<Municipio> query;
            if (predicate == null)
            {
                query = this.repo.Read(null);
            }
            else
            {
                query = this.repo.Read(predicate);
            }

            listaPoco = query.Select(mun =>
                    new MunicipioPoco()
                    {
                        CodigoMunicipio = mun.CodigoMunicipio,
                        NomeMunicipio = mun.NomeMunicipio,
                        CodigoIbge6 = mun.CodigoIbge6,
                        CodigoIbge7 = mun.CodigoIbge7,
                        Cep = mun.Cep,
                        CodigoUf = mun.CodigoUf,
                        SiglaUf = mun.SiglaUf,
                        Regiao = mun.Regiao,
                        Populacao = mun.Populacao,
                        Porte = mun.Porte,
                        DataInclusao = mun.DataInclusao
                    }
                )
                .ToList();
            return listaPoco;
        }

        public override MunicipioPoco ConvertTo(Municipio dominio)
        {
            return new MunicipioPoco()
            {
                CodigoMunicipio = dominio.CodigoMunicipio,
                NomeMunicipio = dominio.NomeMunicipio,
                CodigoIbge6 = dominio.CodigoIbge6,
                CodigoIbge7 = dominio.CodigoIbge7,
                Cep = dominio.Cep,
                CodigoUf = dominio.CodigoUf,
                SiglaUf = dominio.SiglaUf,
                Regiao = dominio.Regiao,
                Populacao = dominio.Populacao,
                Porte = dominio.Porte,
                DataInclusao = dominio.DataInclusao
            };
        }

        public override Municipio ConvertTo(MunicipioPoco poco)
        {
            return new Municipio()
            {
                CodigoMunicipio = poco.CodigoMunicipio,
                NomeMunicipio = poco.NomeMunicipio,
                CodigoIbge6 = poco.CodigoIbge6,
                CodigoIbge7 = poco.CodigoIbge7,
                Cep = poco.Cep,
                CodigoUf = poco.CodigoUf,
                SiglaUf = poco.SiglaUf,
                Regiao = poco.Regiao,
                Populacao = poco.Populacao,
                Porte = poco.Porte,
                DataInclusao = poco.DataInclusao
            };
        }

        public override MunicipioPoco Delete(int chave)
        {
            Municipio del = this.repo.Delete(chave);
            MunicipioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override MunicipioPoco Delete(MunicipioPoco poco)
        {
            Municipio del = this.repo.Delete(poco.CodigoMunicipio);
            MunicipioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override MunicipioPoco Edit(MunicipioPoco poco)
        {
            Municipio editada = this.ConvertTo(poco);
            Municipio alterada = this.repo.Update(editada);
            MunicipioPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override MunicipioPoco Read(int chave)
        {
            Municipio lida = this.repo.Read(chave);
            MunicipioPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
