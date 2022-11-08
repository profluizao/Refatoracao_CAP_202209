using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Geral;
using Atacado.Servico.Geral;
using System;

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
        public ActionResult<List<PaisPoco>> GetAll()
        {
            try
            {
                List<PaisPoco> result = this.servico.Browse();
                return Ok();
            }
            catch
            {
                return BadRequest();
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
                PaisPoco result = this.servico.Read(chave);
                return Ok();
            }
            catch
            {
                return BadRequest();
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
                PaisPoco result = this.servico.Add(poco);
                return Ok();
            }
            catch
            {
                return BadRequest();
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
                PaisPoco result = this.servico.Edit(poco);
                return Ok();
            }
            catch
            {
                return BadRequest();
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
                PaisPoco result = this.servico.Delete(chave);
                return Ok();
            }
            catch
            {
                return BadRequest();
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
                PaisPoco result = this.servico.Delete(poco);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
