using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Servico.RH;
using Atacado.Poco.RH;


namespace AtacadoApi.Controllers
{
    [Route("api/rh/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private DepartamentoServico servico;

        public DepartamentoController() : base()
        {
            this.servico = new DepartamentoServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Instituicão Bancaria
        /// </summary>
        /// <returns>Uma lista com todos os registros</returns>
        [HttpGet]
        public List<DepartamentoPoco> GetAll()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Lista o registro da tabela Instituição Bancária de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public DepartamentoPoco GetById(int chave)
        {
            return this.servico.Read(chave);
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPost]
        public DepartamentoPoco Post([FromBody] DepartamentoPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPut]
        public DepartamentoPoco Put([FromBody] DepartamentoPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public DepartamentoPoco DeleteById(int chave)
        {
            return this.servico.Delete(chave);
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpDelete]
        public DepartamentoPoco Delete([FromBody] DepartamentoPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
