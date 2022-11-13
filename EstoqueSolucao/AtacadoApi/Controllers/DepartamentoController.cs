using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Servico.RH;
using Atacado.Poco.RH;
using System;


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
        public ActionResult<List<DepartamentoPoco>> GetAll()
        {
            try
            {
                List<DepartamentoPoco> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
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
        public ActionResult<DepartamentoPoco> GetById(int chave)
        {
            try
            {
                DepartamentoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
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
        public ActionResult<DepartamentoPoco> Post([FromBody] DepartamentoPoco poco)
        {
            try
            {
                DepartamentoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
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
        public ActionResult<DepartamentoPoco> Put([FromBody] DepartamentoPoco poco)
        {
            try
            {
                DepartamentoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
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
        public ActionResult<DepartamentoPoco> DeleteById(int chave)
        {
            try
            {
                DepartamentoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
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
        public ActionResult<DepartamentoPoco> Delete([FromBody] DepartamentoPoco poco)
        {
            try
            {
                DepartamentoPoco novoPoco = this.servico.Excluir(poco.DepartamentoId);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
