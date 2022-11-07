using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Servico.Geral;
using Atacado.Poco.Geral;

namespace AtacadoApi.Controllers
{
    [Route("api/geral/[controller]")]
    [ApiController]
    public class InstituicaoBancariaController : ControllerBase
    {
        private InstituicaoBancariaServico servico;

        public InstituicaoBancariaController() : base()
        {
            this.servico = new InstituicaoBancariaServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Instituicão Bancaria
        /// </summary>
        /// <returns>Uma lista com todos os registros</returns>
        [HttpGet]
        public List<InstituicaoBancariaPoco> GetAll()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Lista o registro da tabela Instituição Bancária de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public InstituicaoBancariaPoco GetById(int chave)
        {
           return this.servico.Read(chave);
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPost]
        public InstituicaoBancariaPoco Post([FromBody] InstituicaoBancariaPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPut]
        public InstituicaoBancariaPoco Put([FromBody] InstituicaoBancariaPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpDelete]
        public InstituicaoBancariaPoco DeleteById(int chave)
        {
            return this.servico.Delete(chave);
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpDelete]
        public InstituicaoBancariaPoco Delete([FromBody] InstituicaoBancariaPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
