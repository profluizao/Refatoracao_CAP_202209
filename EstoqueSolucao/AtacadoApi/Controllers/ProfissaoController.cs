using Microsoft.AspNetCore.Mvc;
using Atacado.Poco.RH;
using Atacado.Servico.RH;
using Atacado.Poco.Estoque;
using System;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/rh/[controller]")]
    [ApiController]
    public class ProfissaoController : ControllerBase
    {
        private ProfissaoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public ProfissaoController() : base()
        {
            this.servico = new ProfissaoServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Categoria.
        /// </summary>
        /// <returns>Uma lista com todos os registros.</returns>
        [HttpGet]
        public ActionResult<List<ProfissaoPoco>> GetAll()
        {
            try
            {
                List<ProfissaoPoco> lista = this.servico.Browse();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o registro da tabela Categoria de acordo com a chave informada
        /// </summary>
        /// <param name="chave">chave primária da tabela</param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<ProfissaoPoco> GetById(int chave)
        {
            try
            {
                ProfissaoPoco readPoco = this.servico.Read(chave);
                return Ok(readPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco">instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ProfissaoPoco> Post([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco addPoco = this.servico.Add(poco);
                return Ok(addPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco">instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ProfissaoPoco> Put([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco editPoco = this.servico.Edit(poco);
                return Ok(editPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave informada
        /// </summary>
        /// <param name="chave">chave primária da tabela</param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<ProfissaoPoco> DeleteById(int chave)
        {
            try
            {
                ProfissaoPoco delPoco = this.servico.Delete(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco">instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<ProfissaoPoco> Delete([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco delPoco = this.servico.Delete(poco);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
