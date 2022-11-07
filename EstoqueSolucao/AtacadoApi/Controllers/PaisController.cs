using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Geral;
using Atacado.Servico.Geral;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/geral/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private PaisServico servico;

        /// <summary>
        /// 
        /// </summary>
        public PaisController() : base()
        {
            this.servico = new PaisServico();
        }

        /// <summary>
        /// Lista todos os registros da tabela Pais
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PaisPoco> GetAll()
        {
            return this.servico.Browse();
        }
        
        /// <summary>
        /// Lista o registro da tabela Pais de acordo com a Id
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public PaisPoco GetById(int chave)
        {
            return this.servico.Read(chave);
        }

        /// <summary>
        /// Cria um novo registro de Pais
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public PaisPoco Post([FromBody] PaisPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Altera um registro dentro de Pais
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public PaisPoco Put([FromBody] PaisPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com o Id
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public PaisPoco DeleteById(int chave)
        { 
            return this.servico.Delete(chave);
        }

        /// <summary>
        /// Realiza a exclusão de um registro na tabela Pais
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public PaisPoco Delete([FromBody] PaisPoco poco)
        {
            return this.servico.Delete(poco);
        }

    }
}
