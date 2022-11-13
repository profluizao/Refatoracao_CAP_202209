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


namespace Atacado.Servico.Geral
{
    public class MunicipioServico : GenericService<Municipio, MunicipioPoco>
    {
        public override List<MunicipioPoco> Consultar(Expression<Func<Municipio, bool>>? predicate = null)
        {
            IQueryable<Municipio> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return this.ConverterPara(query);
        }

        public override List<MunicipioPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Municipio> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return this.ConverterPara(query);
        }

        public override MunicipioPoco ConverterPara(Municipio dominio)
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

        public override Municipio ConverterPara(MunicipioPoco poco)
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

        public override List<MunicipioPoco> ConverterPara(IQueryable<Municipio> query)
        {
            return query.Select(mun =>
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
        }
    }
}
