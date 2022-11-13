using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.RH;
using Atacado.Repositorio.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Atacado.Poco.Estoque;

namespace Atacado.Servico.RH
{
    public class FuncionarioServico : GenericService<Funcionario, FuncionarioPoco>
    {
        public override List<FuncionarioPoco> Consultar(Expression<Func<Funcionario, bool>>? predicate = null)
        {
            IQueryable<Funcionario> query;
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

        public override List<FuncionarioPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Funcionario> query;
            if(skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return this.ConverterPara(query);
        }

        public override FuncionarioPoco ConverterPara(Funcionario obj)
        {
            return new FuncionarioPoco()
            {
                FuncionarioId = obj.FuncionarioId,
                Matricula = obj.Matricula,
                Nome = obj.Nome,
                Sobrenome = obj.Sobrenome,
                Sexo = obj.Sexo,
                DataNascimento = obj.DataNascimento,
                Email = obj.Email,
                Ctps = obj.Ctps,
                CtpsNum = obj.CtpsNum,
                CtpsSerie = obj.CtpsSerie,
                DataAdmissao = obj.DataAdmissao,
                Ativo = obj.Ativo
            };
        }

        public override Funcionario ConverterPara(FuncionarioPoco obj)
        {
            return new Funcionario()
            {
                FuncionarioId = obj.FuncionarioId,
                Matricula = obj.Matricula,
                Nome = obj.Nome,
                Sobrenome = obj.Sobrenome,
                Sexo = obj.Sexo,
                DataNascimento = obj.DataNascimento,
                Email = obj.Email,
                Ctps = obj.Ctps,
                CtpsNum = obj.CtpsNum,
                CtpsSerie = obj.CtpsSerie,
                DataAdmissao = obj.DataAdmissao,
                Ativo = obj.Ativo
            };
        }

        public override List<FuncionarioPoco> ConverterPara(IQueryable<Funcionario> query)
        {
            return query.Select(fun =>
                    new FuncionarioPoco()
                    {
                        FuncionarioId = fun.FuncionarioId,
                        Matricula = fun.Matricula,
                        Nome = fun.Nome,
                        Sobrenome = fun.Sobrenome,
                        Sexo = fun.Sexo,
                        DataNascimento = fun.DataNascimento,
                        Email = fun.Email,
                        Ctps = fun.Ctps,
                        CtpsNum = fun.CtpsNum,
                        CtpsSerie = fun.CtpsSerie,
                        DataAdmissao = fun.DataAdmissao,
                        Ativo = fun.Ativo
                    }
            )
            .ToList();
        }
    }
}
