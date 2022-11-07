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
    public class MunicipioController : ControllerBase
    {
        private MunicipioServico servico;

        /// <summary>
        /// 
        /// </summary>
        public MunicipioController() : base()
        {
            this.servico = new MunicipioServico();
        }

        /// <summary>
        /// Lista todos os registros da tabela Municipio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MunicipioPoco> GetAll()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Lista o registro da tabela Municipio de acordo com a Id
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public MunicipioPoco GetById(int chave)
        {
            return this.servico.Read(chave);
        }

        /// <summary>
        /// Cria um novo registro de Municipio
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public MunicipioPoco Post([FromBody] MunicipioPoco poco)
        {
            return this.servico.Add(poco);
        }
        
        /// <summary>
        /// Altera um registro dentro de Municipio
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public MunicipioPoco Put([FromBody] MunicipioPoco poco)
        {
            return this.servico.Edit(poco);
        }
        
        /// <summary>
        /// Realiza a exclusão de um registro de acordo com o Id
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public MunicipioPoco DeleteById(int chave)
        {
            return this.servico.Delete(chave);
        }
        
        /// <summary>
        /// Realiza a exclusão de um registro na tabela Municipio
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public MunicipioPoco Delete([FromBody] MunicipioPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
