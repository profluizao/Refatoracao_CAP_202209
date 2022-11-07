using Atacado.Poco.RH;
using Atacado.Servico.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/rh/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioServico servico;

        /// <summary>
        /// 
        /// </summary>
        public FuncionarioController() : base()
        {
            this.servico = new FuncionarioServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Categoria.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<FuncionarioPoco> GetAll()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Lista o registro da tabela Categoria de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public FuncionarioPoco GetById(int chave)
        {
            return this.servico.Read(chave);
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public FuncionarioPoco Post([FromBody] FuncionarioPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public FuncionarioPoco Put([FromBody] FuncionarioPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public FuncionarioPoco DeleteById(int chave)
        {
            return this.servico.Delete(chave);
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public FuncionarioPoco Delete([FromBody] FuncionarioPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
