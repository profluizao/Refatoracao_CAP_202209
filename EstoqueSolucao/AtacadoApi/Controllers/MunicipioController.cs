﻿using Microsoft.AspNetCore.Http;
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
        public ActionResult<List<MunicipioPoco>> GetAll()
        {
            try
            {
                List<MunicipioPoco> lista = this.servico.Browse();
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o registro da tabela Municipio de acordo com a Id
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<MunicipioPoco> GetById(int chave)
        {
            try
            {
                MunicipioPoco poco = this.servico.Read(chave);
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
        public ActionResult<MunicipioPoco> Post([FromBody] MunicipioPoco poco)
        {
            try
            {
                MunicipioPoco novoPoco = this.servico.Add(poco);
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
        public ActionResult<MunicipioPoco> Put([FromBody] MunicipioPoco poco)
        {
            try
            {
                MunicipioPoco novoPoco = this.servico.Edit(poco);
                return Ok(novoPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com o Id
        /// </summary>
        /// <param name="chave">Chave primária da tabela</param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<MunicipioPoco> DeleteById(int chave)
        {
            try
            {
                MunicipioPoco delPoco = this.servico.Delete(chave);
                return Ok(delPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro na tabela Municipio
        /// </summary>
        /// <param name="poco">Instância passada como parâmetro</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<MunicipioPoco> Delete([FromBody] MunicipioPoco poco)
        {
            try
            {
                MunicipioPoco delPoco = this.servico.Delete(poco);
                return Ok(delPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
