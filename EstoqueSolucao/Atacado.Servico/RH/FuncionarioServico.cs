using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.RH;
using Atacado.Repositorio.RH;
using System.Linq.Expressions;
using Atacado.Repositorio.Base;

namespace Atacado.Servico.RH
{
    public class FuncionarioServico : BaseServico<FuncionarioPoco, Funcionario>
    {
        private GenericRepository<Funcionario> genrepo;

        public FuncionarioServico() : base()
        {
            this.genrepo = new GenericRepository<Funcionario>();
        }
        public override FuncionarioPoco Add(FuncionarioPoco poco)
        {
            Funcionario nova = this.ConvertTo(poco);
            Funcionario criada = this.genrepo.Insert(nova);
            return this.ConvertTo(criada);
        }
        public override List<FuncionarioPoco> Browse()
        {
            return this.Browse(null);
        }

        public override List<FuncionarioPoco> Browse(Expression<Func<Funcionario, bool>> predicate = null)
        {
            List<FuncionarioPoco> listaPoco;
            IQueryable<Funcionario> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }

            listaPoco = query.Select(fun =>
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
            return listaPoco;
        }
        public override FuncionarioPoco ConvertTo(Funcionario dominio)
        {
            return new FuncionarioPoco()
            {
                FuncionarioId = dominio.FuncionarioId,
                Matricula = dominio.Matricula,
                Nome = dominio.Nome,
                Sobrenome = dominio.Sobrenome,
                Sexo = dominio.Sexo,
                DataNascimento = dominio.DataNascimento,
                Email = dominio.Email,
                Ctps = dominio.Ctps,
                CtpsNum = dominio.CtpsNum,
                CtpsSerie = dominio.CtpsSerie,
                DataAdmissao = dominio.DataAdmissao,
                Ativo = dominio.Ativo
            };
        }

        public override Funcionario ConvertTo(FuncionarioPoco poco)
        {
            return new Funcionario()
            {
                FuncionarioId = poco.FuncionarioId,
                Matricula = poco.Matricula,
                Nome = poco.Nome,
                Sobrenome = poco.Sobrenome,
                Sexo = poco.Sexo,
                DataNascimento = poco.DataNascimento,
                Email = poco.Email,
                Ctps = poco.Ctps,
                CtpsNum = poco.CtpsNum,
                CtpsSerie = poco.CtpsSerie,
                Ativo = poco.Ativo
            };
        }

        public override FuncionarioPoco Delete(int chave)
        {
            Funcionario del = this.genrepo.Delete(chave);
            FuncionarioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override FuncionarioPoco Delete(FuncionarioPoco poco)
        {
            Funcionario del = this.genrepo.Delete(poco.FuncionarioId);
            FuncionarioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override FuncionarioPoco Edit(FuncionarioPoco poco)
        {
            Funcionario editada = this.ConvertTo(poco);
            Funcionario alterada = this.genrepo.Update(editada);
            FuncionarioPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override FuncionarioPoco Read(int chave)
        {
            Funcionario lida = this.genrepo.GetById(chave);
            FuncionarioPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
