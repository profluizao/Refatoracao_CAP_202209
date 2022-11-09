using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Atacado.Repositorio.Base;

namespace Atacado.Servico.Geral
{
    public class ClienteServico : BaseServico<ClientePoco, Cliente>
    {
        private GenericRepository<Cliente> genrepo;

        public ClienteServico() : base()
        {
            this.genrepo = new GenericRepository<Cliente>();
        }
        public override ClientePoco Add(ClientePoco poco)
        {
            Cliente nova = this.ConvertTo(poco);
            Cliente criada = this.genrepo.Insert(nova);
            return this.ConvertTo(criada);
        }

        public override List<ClientePoco> Browse()
        {
            return this.Browse(null);
        }
        public override List<ClientePoco> Browse(Expression<Func<Cliente, bool>> predicate = null)
        {
            List<ClientePoco> listaPoco;
            IQueryable<Cliente> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }

            listaPoco = query.Select(cli =>
                    new ClientePoco()
                    {
                        Codigo = cli.Codigo,
                        Nome = cli.Nome,
                        RazaoSocial = cli.RazaoSocial,
                        NomeFantasia = cli.NomeFantasia,
                        Documento = cli.Documento,
                        Telefone = cli.Telefone,
                        Email = cli.Email,
                        TipoPessoa = cli.TipoPessoa,
                        Endereco = cli.Endereco,
                        Ativo = cli.Ativo,
                        DataInclusao = cli.DataInclusao,
                        DataAlteracao = cli.DataAlteracao,
                        DataExclusao = cli.DataExclusao
                    }
                )
                .ToList();
            return listaPoco;
        }
        public override ClientePoco ConvertTo(Cliente dominio)
        {
            return new ClientePoco()
            {
                Codigo=dominio.Codigo,
                Nome = dominio.Nome,
                RazaoSocial = dominio.RazaoSocial,
                NomeFantasia = dominio.NomeFantasia,
                Documento = dominio.Documento,
                Telefone = dominio.Telefone,
                Email = dominio.Email,
                TipoPessoa = dominio.TipoPessoa,
                Endereco = dominio.Endereco,
                Ativo = dominio.Ativo,
                DataInclusao = dominio.DataInclusao,
                DataAlteracao = dominio.DataAlteracao,
                DataExclusao = dominio.DataExclusao
            };
        }

        public override Cliente ConvertTo(ClientePoco poco)
        {
            return new Cliente()
            {
                Codigo = poco.Codigo,
                Nome = poco.Nome,
                RazaoSocial = poco.RazaoSocial,
                NomeFantasia = poco.NomeFantasia,
                Documento = poco.Documento,
                Telefone = poco.Telefone,
                Email = poco.Email,
                TipoPessoa = poco.TipoPessoa,
                Endereco = poco.Endereco,
                Ativo = poco.Ativo,
                DataInclusao = poco.DataInclusao,
                DataAlteracao = poco.DataAlteracao,
                DataExclusao = poco.DataExclusao
            };
        }

        public override ClientePoco Delete(int chave)
        {
            Cliente del = this.genrepo.Delete(chave);
            ClientePoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ClientePoco Delete(ClientePoco poco)
        {
            Cliente del = this.genrepo.Delete(poco.Codigo);
            ClientePoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ClientePoco Edit(ClientePoco poco)
        {
            Cliente editada = this.ConvertTo(poco);
            Cliente alterada = this.genrepo.Update(editada);
            ClientePoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override ClientePoco Read(int chave)
        {
            Cliente lida = this.genrepo.GetById(chave);
            ClientePoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
