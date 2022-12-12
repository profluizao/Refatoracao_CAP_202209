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
    public class PontoParadaController : ControllerBase
    {
        private PontoParadaService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public PontoParadaController(ViajeFacilContexto context) : base()
        {
            this.servico = new PontoParadaService(context);
        }

        /// <summary>
        /// Lista todos os registros de Ponto Parada por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<PontoParadaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<PontoParadaPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros de Ponto Parada por chave Rota.
        /// </summary>
        /// <param name="rotacod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorRota/{rotacod:long}")]
        public ActionResult<List<PontoParadaPoco>> GetByRota(long rotacod)
        {
            try
            {
                List<PontoParadaPoco> listaPoco = this.servico.Consultar(par => par.CodigoRota == rotacod).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Ponto Parada
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:long}")]
        public ActionResult<PontoParadaPoco> GetById(long chave)
        {
            try
            {
                PontoParadaPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Ponto Parada.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<PontoParadaPoco> Post([FromBody] PontoParadaPoco poco)
        {
            try
            {
                PontoParadaPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Ponto Parada.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<PontoParadaPoco> Put([FromBody] PontoParadaPoco poco)
        {
            try
            {
                PontoParadaPoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<PontoParadaPoco> DeleteById(long chave)
        {
            try
            {
                PontoParadaPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}