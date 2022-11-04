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
    public class MunicipioRepo : BaseRepositorio<Municipio>
    {
        private ProjetoAcademiaContext contexto;

        public MunicipioRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Municipio Create(Municipio instancia)
        {
            this.contexto.Municipios.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override Municipio Delete(int chave)
        {
            Municipio del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Municipios.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }
        }

        public override Municipio Delete(Municipio instancia)
        {
            return this.Delete(instancia.CodigoMunicipio);
        }

        public override Municipio Read(int chave)
        {
            return this.contexto.Municipios.SingleOrDefault(mun => mun.CodigoMunicipio == chave);
        }

        public override IQueryable<Municipio> Read(Expression<Func<Municipio, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.contexto.Municipios.AsQueryable();
            }
            else
            {
                return this.contexto.Municipios.Where(predicate).AsQueryable();
            }
        }

        public override List<Municipio> Read()
        {
            return this.contexto.Municipios.ToList();
        }

        public override Municipio Update(Municipio instancia)
        {
            Municipio atu = this.Read(instancia.CodigoMunicipio);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.NomeMunicipio = instancia.NomeMunicipio;
                atu.CodigoIbge6 = instancia.CodigoIbge6;
                atu.CodigoIbge7 = instancia.CodigoIbge7;
                atu.Cep = instancia.Cep;
                atu.CodigoUf = instancia.CodigoUf;
                atu.SiglaUf = instancia.SiglaUf;
                atu.Regiao = instancia.Regiao;
                atu.Populacao = instancia.Populacao;
                atu.Porte = instancia.Porte;
                atu.DataInclusao = instancia.DataInclusao;
                this.contexto.SaveChanges();
                return atu;
            }
        }
    }
}
