using Atacado.Poco.Estoque;
using Atacado.Poco.Geral;
using Atacado.Servico.Geral;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<List<ClientePoco>> GetAll()
        {
            try
            {
                List <ClientePoco> lista = this.servico.Browse();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o cliente de acordo com o codigo informado 
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<ClientePoco> GetById(int chave)
        {
            try
            {
                ClientePoco poco = this.servico.Read(chave);
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
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ClientePoco> Post([FromBody] ClientePoco poco)
        {
            try
            {
                ClientePoco novoPoco = this.servico.Add(poco);
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
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ClientePoco> Put([FromBody] ClientePoco poco)
        {
            try
            {
                ClientePoco novoPoco = this.servico.Edit(poco);
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
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<ClientePoco> DeleteById(int chave)
        {
            try
            {
                ClientePoco poco = this.servico.Delete(chave);
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
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<ClientePoco> Delete([FromBody] ClientePoco poco)
        {
            try
            {
                ClientePoco novoPoco = this.servico.Delete(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
