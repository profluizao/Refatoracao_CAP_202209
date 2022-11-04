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
    public class ClienteRepo : BaseRepositorio<Cliente>
    {
        private ProjetoAcademiaContext contexto;

        public ClienteRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Cliente Create(Cliente instancia)
        {
            this.contexto.Clientes.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override Cliente Delete(int chave)
        {
            Cliente del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Clientes.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }
        }

        public override Cliente Delete(Cliente instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override Cliente Read(int chave)
        {
            return this.contexto.Clientes.SingleOrDefault(cli => cli.Codigo == chave);
        }

        public override IQueryable<Cliente> Read(Expression<Func<Cliente, bool>> predicate = null)
        {
            if(predicate == null)
            {
                return this.contexto.Clientes.AsQueryable();
            }
            else
            {
                return this.contexto.Clientes.Where(predicate).AsQueryable();
            }
        }

        public override List<Cliente> Read()
        {
            return this.contexto.Clientes.ToList();
        }

        public override Cliente Update(Cliente instancia)
        {
            Cliente atu = this.Read(instancia.Codigo);
            if(atu == null)
            {
                return null;
            }
            else
            {
                atu.Nome = instancia.Nome;
                atu.RazaoSocial = instancia.RazaoSocial;
                atu.NomeFantasia = instancia.NomeFantasia;
                atu.Documento = instancia.Documento;
                atu.Telefone = instancia.Telefone;
                atu.Email = instancia.Email;
                atu.TipoPessoa = instancia.TipoPessoa;
                atu.Endereco = instancia.Endereco;
                atu.Ativo = instancia.Ativo;
                atu.DataInclusao = instancia.DataInclusao;
                atu.DataAlteracao = instancia.DataAlteracao;
                atu.DataExclusao = instancia.DataExclusao;
                this.contexto.SaveChanges();
                return atu;
            }
        }
    }
}
