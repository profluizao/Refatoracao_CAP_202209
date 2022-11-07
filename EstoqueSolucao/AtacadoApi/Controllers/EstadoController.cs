using Atacado.Poco.Geral;
using Atacado.Servico.Geral;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/geral/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private EstadoServico servico;

        public EstadoController() : base()
        {
            this.servico = new EstadoServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Categoria.
        /// </summary>
        /// <returns>Uma lista com todos os registros.</returns>
        [HttpGet]
        public List<EstadoPoco> GetAll()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Lista o registro da tabela Categoria de acordo com a chave informada
        /// </summary>
        /// <param name="chave">chave primária da tabela</param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public EstadoPoco GetById(int chave)
        {
            return this.servico.Read(chave);
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco">instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPost]
        public EstadoPoco Post([FromBody] EstadoPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco">instância passada como parâmetro</param>
        /// <returns></returns
        [HttpPut]
        public EstadoPoco Put([FromBody] EstadoPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave informada
        /// </summary>
        /// <param name="chave">chave primária da tabela</param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public EstadoPoco DeleteById(int chave)
        {
            return this.servico.Delete(chave);
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco">instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpDelete]
        public EstadoPoco Delete([FromBody] EstadoPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
