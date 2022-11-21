using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Geral;
using Atacado.Servico.Geral;
using System;
using Atacado.DB.EF.Database;

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
        public PaisController(ProjetoAcademiaContext context) : base()
        {
            this.servico = new PaisServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela Pais
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PaisPoco>> GetAll()
        {
            try
            {
                List<PaisPoco> result = this.servico.Listar();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        
        /// <summary>
        /// Lista o registro da tabela Pais de acordo com a Id
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<PaisPoco> GetById(int chave)
        {
            try
            {
                PaisPoco result = this.servico.PesquisarPorChave(chave);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo registro de Pais
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PaisPoco> Post([FromBody] PaisPoco poco)
        {
            try
            {
                PaisPoco result = this.servico.Inserir(poco);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um registro dentro de Pais
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<PaisPoco> Put([FromBody] PaisPoco poco)
        {
            try
            {
                PaisPoco result = this.servico.Alterar(poco);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com o Id
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<PaisPoco> DeleteById(int chave)
        {
            try
            {
                PaisPoco result = this.servico.Excluir(chave);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro na tabela Pais
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<PaisPoco> Delete([FromBody] PaisPoco poco)
        {
            try
            {
                PaisPoco result = this.servico.Excluir(poco.PaisId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
