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
using System.Runtime.CompilerServices;
using System.Globalization;
using Atacado.Poco.Geral;

namespace Atacado.Servico.Geral
{
    public class ClienteServico : GenericService<Cliente, ClientePoco>
    {
        public override List<ClientePoco> Consultar(Expression<Func<Cliente, bool>>? predicate = null)
        {
            IQueryable<Cliente> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<ClientePoco> listaPoco = query.Select(cli =>
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
    }
}
