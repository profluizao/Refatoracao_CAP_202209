using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Servico.Geral;
using Atacado.Poco.Geral;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/geral/[controller]")]
    [ApiController]
    public class InstituicaoBancariaController : ControllerBase
    {
        private InstituicaoBancariaServico servico;

        /// <summary>
        /// 
        /// </summary>
        public InstituicaoBancariaController() : base()
        {
            this.servico = new InstituicaoBancariaServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Instituicão Bancaria
        /// </summary>
        /// <returns>Uma lista com todos os registros</returns>
        [HttpGet]
        public ActionResult<List<InstituicaoBancariaPoco>> GetAll()
        {
            try
            {
                List<InstituicaoBancariaPoco> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            } 
        }

        /// <summary>
        /// Lista o registro da tabela Instituição Bancária de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<InstituicaoBancariaPoco> GetById(int chave)
        {
            try
            {
                InstituicaoBancariaPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }   
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<InstituicaoBancariaPoco> Post([FromBody] InstituicaoBancariaPoco poco)
        {
            try
            {
                InstituicaoBancariaPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<InstituicaoBancariaPoco> Put([FromBody] InstituicaoBancariaPoco poco)
        {
            try
            {
                InstituicaoBancariaPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<InstituicaoBancariaPoco> DeleteById(int chave)
        {
            try
            {
                InstituicaoBancariaPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<InstituicaoBancariaPoco> Delete([FromBody] InstituicaoBancariaPoco poco)
        {
            try
            {
                InstituicaoBancariaPoco delPoco = this.servico.Excluir(poco.CodigoBanco);
                return Ok(delPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
