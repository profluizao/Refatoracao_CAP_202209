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
        public ActionResult<List<ProdutoPoco>> GetAll(int? take = null,int? skip = null)
        {
            try
            {
                List<ProdutoPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
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
                List<ProdutoPoco> list = this.servico.Consultar(cat => cat.CodigoCategoria == catid).ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
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
                List<ProdutoPoco> list = this.servico.Consultar(sub => sub.CodigoSubcategoria == subid).ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
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
                List<ProdutoPoco> list = this.servico.Consultar(pro => (pro.CodigoCategoria == catid) && (pro.CodigoSubcategoria == subid)).ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
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
                ProdutoPoco list = this.servico.PesquisarPorChave(chave);
                return Ok(list);
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
        public ActionResult<ProdutoPoco> Post([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco list = this.servico.Inserir(poco);
                return Ok(list);
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
        public ActionResult<ProdutoPoco> Put([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco list = this.servico.Alterar(poco);
                return Ok(list);
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
        public ActionResult<ProdutoPoco> DeleteById(int chave)
        {
            try
            {
                ProdutoPoco list = this.servico.Excluir(chave);
                return Ok(list);
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
        public ActionResult<ProdutoPoco> Delete([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco list = this.servico.Excluir(poco.Codigo);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
