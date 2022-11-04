using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Geral;
using Atacado.Repositorio.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Geral
{
    public class ClienteServico : BaseServico<ClientePoco, Cliente>
    {
        private ClienteRepo repo;

        public ClienteServico() : base()
        {
            this.repo = new ClienteRepo();
        }
        public override ClientePoco Add(ClientePoco poco)
        {
            Cliente nova = this.ConvertTo(poco);
            Cliente criada = this.repo.Create(nova);
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
                query = this.repo.Read(null);
            }
            else
            {
                query = this.repo.Read(predicate);
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
            Cliente del = this.repo.Delete(chave);
            ClientePoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ClientePoco Delete(ClientePoco poco)
        {
            Cliente del = this.repo.Delete(poco.Codigo);
            ClientePoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ClientePoco Edit(ClientePoco poco)
        {
            Cliente editada = this.ConvertTo(poco);
            Cliente alterada = this.repo.Update(editada);
            ClientePoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override ClientePoco Read(int chave)
        {
            Cliente lida = this.repo.Read(chave);
            ClientePoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
