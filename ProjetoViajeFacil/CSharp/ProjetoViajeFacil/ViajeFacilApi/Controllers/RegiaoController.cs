using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.Dominio.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service.Viagem;

namespace ViajeFacilApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/viagem/[controller]")]
    [ApiController]
    public class RegiaoController : ControllerBase
    {
        public RegiaoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RegiaoController(ViajeFacilContexto context) : base()
        {
            this.servico = new RegiaoService(context);
        }

        /// <summary>
        /// Lista todos os registros de Região por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<RegiaoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<RegiaoPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros de Região por País.
        /// </summary>
        /// <param name="paiscod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorPais/{paiscod:long}")]
        public ActionResult<List<RegiaoPoco>> GetByPais(long paiscod)
        {
            try
            {
                List<RegiaoPoco> listaPoco = this.servico.Consultar(reg => reg.CodigoPais == paiscod).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Região.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:long}")]
        public ActionResult<RegiaoPoco> GetById(long chave)
        {
            try
            {
                RegiaoPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Região.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<RegiaoPoco> Post([FromBody] RegiaoPoco poco)
        {
            try
            {
                RegiaoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Região.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<RegiaoPoco> Put([FromBody] RegiaoPoco poco)
        {
            try
            {
                RegiaoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente no recurso, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:long}")]
        public ActionResult<RegiaoPoco> DeleteById(long chave)
        {
            try
            {
                RegiaoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}