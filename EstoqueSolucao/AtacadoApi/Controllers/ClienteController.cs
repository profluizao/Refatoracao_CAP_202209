using Atacado.Poco.Estoque;
using Atacado.Poco.Geral;
using Atacado.Servico.Geral;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/geral/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteServico servico;

        /// <summary>
        /// 
        /// </summary>
        public ClienteController() : base()
        {
            this.servico = new ClienteServico();
        }

        /// <summary>
        /// Lista todos os clientes da tabela 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ClientePoco> GetAll()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Lista o cliente de acordo com o codigo informado 
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ClientePoco GetById(int chave)
        {
            return this.servico.Read(chave);
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ClientePoco Post([FromBody] ClientePoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ClientePoco Put([FromBody] ClientePoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ClientePoco DeleteById(int chave)
        {
            return this.servico.Delete(chave);
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ClientePoco Delete([FromBody] ClientePoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
