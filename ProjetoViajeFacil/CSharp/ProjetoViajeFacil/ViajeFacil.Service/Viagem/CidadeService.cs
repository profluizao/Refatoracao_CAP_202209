using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajeFacil.Service.Base;
using ViajeFacil.Dominio.EF;
using ViajeFacil.Poco;


namespace ViajeFacil.Service.Viagem
{
    public class CidadeService : GenericService <Cidade,CidadePoco>
    {
        public CidadeService(ViajeFacilContexto contexto) : base(contexto)
        { }

        public override List<CidadePoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Cidade> query;
            if(skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take,skip);
            }
            return this.ConverterPara(query);
        }

        public override List<CidadePoco> Consultar(System.Linq.Expressions.Expression<Func<Cidade, bool>>? predicate = null)
        {
            IQueryable<Cidade> query;
            if(predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return this.ConverterPara(query);
        }

        public override List<CidadePoco> Vasculhar(int? take = null, int? skip = null, System.Linq.Expressions.Expression<Func<Cidade, bool>>? predicate = null)
        {
            IQueryable<Cidade> query;
            if (skip == null)
            {
                if (predicate == null)
                {
                    query = this.genrepo.Browseable(null);
                }
                else
                {
                    query = this.genrepo.Browseable(predicate);
                }
            }
            else
            {
                if (predicate == null)
                {
                    query = this.genrepo.GetAll(take, skip);
                }
                else
                {
                    query = this.genrepo.Searchable(take, skip, predicate);
                }
            }
            return this.ConverterPara(query);
        }

        public override List<CidadePoco> ConverterPara(IQueryable<Cidade> query)
        {
            return query.Select(cid =>
            new CidadePoco()
            {
                CodigoCidade = cid.CodigoCidade,
                Nome = cid.Nome,
                CodigoIbge7 = cid.CodigoIBGE7,
                SiglaUf = cid.SiglaUF,
                CodigoEstado = cid.CodigoEstado
            }
            )
                .ToList();
        }
    }
}
