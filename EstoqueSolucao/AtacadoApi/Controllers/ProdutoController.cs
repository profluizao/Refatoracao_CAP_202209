using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;
using System;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public ProdutoController() : base()
        {
            this.servico = new ProdutoServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Produto.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProdutoPoco>> GetAll()
        {
            try
            {
                List<ProdutoPoco> list = this.servico.Browse();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Produto de acordo com o código de Categoria informado.
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorCategoria(int catid)
        {
            try
            {
                List<ProdutoPoco> list = this.servico.Browse(cat => cat.CodigoCategoria == catid).ToList();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }   

        /// <summary>
        /// Listar todos os registros da tabela Produto de acordo com o código de Subcategoria informado.
        /// </summary>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorSubcategoria/{subid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorSubcategoria(int subid)
        {
             try
            {
                List<ProdutoPoco> list = this.servico.Browse(sub => sub.CodigoSubcategoria == subid).ToList();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Lista todos os registros de acordo com os códigos de Categoria e Subcategoria informados.
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}/PorSubcategoria/{subid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorCategoriaPorSubcategoria(int catid, int subid)
        {
            try
            {
                List<ProdutoPoco> list = this.servico.Browse(pro => (pro.CodigoCategoria == catid) && (pro.CodigoSubcategoria == subid)).ToList();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Lista o registro da tabela Produto de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<ProdutoPoco> GetById(int chave)
        {
            try
            {
                ProdutoPoco list = this.servico.Read(chave);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Realiza a criação de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ProdutoPoco> Post([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco list = this.servico.Add(poco);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Realiza a alteração de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ProdutoPoco> Put([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco list = this.servico.Edit(poco);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<ProdutoPoco> DeleteById(int chave)
        {
            try
            {
                ProdutoPoco list = this.servico.Delete(chave);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro através de uma instância
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<ProdutoPoco> Delete([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco list = this.servico.Delete(poco);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
