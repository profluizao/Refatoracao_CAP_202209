using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.DB.EF.Database;
using Atacado.Repositorio.Base;
using System.Linq.Expressions;

namespace Atacado.Repositorio.RH
{
    public class FuncionarioRepo : BaseRepositorioLong<Funcionario>
    {
        private ProjetoAcademiaContext contexto;

        public FuncionarioRepo() : base()
        {
            this.contexto = new ProjetoAcademiaContext();
        }

        public override Funcionario Create(Funcionario instancia)
        {
            this.contexto.Funcionarios.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }

        public override Funcionario Delete(long chave)
        {
            Funcionario del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }
        }

        public override Funcionario Delete(Funcionario instancia)
        {
            return this.Delete(instancia.FuncionarioId);
        }

        public override Funcionario Read(long chave)
        {
            return this.contexto.Funcionarios.SingleOrDefault(fun => fun.FuncionarioId == chave);
        }

        public override IQueryable<Funcionario> Read(Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.contexto.Funcionarios.AsQueryable();
            }
            else
            {
                return this.contexto.Funcionarios.Where(predicate).AsQueryable();
            }
        }

        public override List<Funcionario> Read()
        {
            return this.contexto.Funcionarios.ToList();
        }

        public override Funcionario Update(Funcionario instancia)
        {
            Funcionario atu = this.Read(instancia.FuncionarioId);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Matricula = instancia.Matricula;
                atu.Nome = instancia.Nome;
                atu.Sobrenome = instancia.Sobrenome;
                atu.Sexo = instancia.Sexo;
                atu.DataNascimento = instancia.DataNascimento;
                atu.Email = instancia.Email;
                atu.Ctps = instancia.Ctps;
                atu.CtpsNum = instancia.CtpsNum;
                atu.CtpsSerie = instancia.CtpsSerie;
                atu.Ativo = instancia.Ativo;
                this.contexto.SaveChanges();
                return atu;
            }
        }
    }
}
