using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repositorio.Base;
using System.Linq.Expressions;
using Atacado.Poco.Geral;
using System.Net;
using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;


namespace Atacado.Servico.Geral
{
    public class MunicipioServico : BaseServico<MunicipioPoco, Municipio>
    {
        private GenericRepository<Municipio> genrepo;

        public MunicipioServico() : base()
        {
            this.genrepo = new GenericRepository<Municipio>();
        }
        public override MunicipioPoco Add(MunicipioPoco poco)
        {
            Municipio nova = this.ConvertTo(poco);
            Municipio criada = this.genrepo.Insert(nova);
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
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
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
            Municipio del = this.genrepo.Delete(chave);
            MunicipioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override MunicipioPoco Delete(MunicipioPoco poco)
        {
            Municipio del = this.genrepo.Delete(poco.CodigoMunicipio);
            MunicipioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override MunicipioPoco Edit(MunicipioPoco poco)
        {
            Municipio editada = this.ConvertTo(poco);
            Municipio alterada = this.genrepo.Insert(editada);
            MunicipioPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override MunicipioPoco Read(int chave)
        {
            Municipio lida = this.genrepo.GetById(chave);
            MunicipioPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
