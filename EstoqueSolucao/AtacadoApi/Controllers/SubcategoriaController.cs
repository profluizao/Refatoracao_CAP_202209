using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;
using System.Runtime.CompilerServices;
using Atacado.Poco.RH;
using System;

namespace AtacadoApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private SubcategoriaServico servico;

        /// <summary>
        /// 
        /// </summary>
        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Subcategoria.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<SubcategoriaPoco>> GetAll()
        {
            try
            {
                List<SubcategoriaPoco> lista = this.servico.Browse();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Subcategoria de acordo com o código de Categoria informado.
        /// </summary>
        /// <param name="catid">Código da categoria (chave estrangeira) da tabela Subcategoria</param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public ActionResult<List<SubcategoriaPoco>> GetPorCategoria(int catid)
        {
            try
            {
                List<SubcategoriaPoco> lista = this.servico.Browse(sub => sub.CodigoCategoria == catid).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o registro da tabela Subcategoria de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave">chave primária da tabela</param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<SubcategoriaPoco> GetById(int chave)
        {
            try
            {
                SubcategoriaPoco readPoco = this.servico.Read(chave);
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
        public ActionResult<SubcategoriaPoco> Post([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco addPoco = this.servico.Add(poco);
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
        public ActionResult<SubcategoriaPoco> Put([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco editPoco = this.servico.Edit(poco);
                return Ok(editPoco);
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
        public ActionResult<SubcategoriaPoco> DeleteById(int chave)
        {
            try
            {
                SubcategoriaPoco delPoco = this.servico.Delete(chave);
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
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<SubcategoriaPoco> Delete([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco delPoco = this.servico.Delete(poco);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
