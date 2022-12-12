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
    public class ParticipanteEventoController : ControllerBase
    {
        private ParticipanteEventoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ParticipanteEventoController(ViajeFacilContexto context) : base()
        {
            this.servico = new ParticipanteEventoService(context);
        }

        /// <summary>
        /// Lista todos os registros de Participante Evento por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<ParticipanteEventoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ParticipanteEventoPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros de Partipante Evento por chave Evento.
        /// </summary>
        /// <param name="partcod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorEvento/{partcod:long}")]
        public ActionResult<List<ParticipanteEventoPoco>> GetByEvento(long partcod)
        {
            try
            {
                List<ParticipanteEventoPoco> listaPoco = this.servico.Consultar(par => par.CodigoEvento == partcod).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros de Partipante Evento por chave Usuario.
        /// </summary>
        /// <param name="usuariocod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorUsuario/{usuariocod:long}")]
        public ActionResult<List<ParticipanteEventoPoco>> GetByUsuario(long usuariocod)
        {
            try
            {
                List<ParticipanteEventoPoco> listaPoco = this.servico.Consultar(par => par.CodigoUsuario == usuariocod).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Participante Evento.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:long}")]
        public ActionResult<ParticipanteEventoPoco> GetById(long chave)
        {
            try
            {
                ParticipanteEventoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Participante Evento.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<ParticipanteEventoPoco> Post([FromBody] ParticipanteEventoPoco poco)
        {
            try
            {
                ParticipanteEventoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Participante Evento.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<ParticipanteEventoPoco> Put([FromBody] ParticipanteEventoPoco poco)
        {
            try
            {
                ParticipanteEventoPoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<ParticipanteEventoPoco> DeleteById(long chave)
        {
            try
            {
                ParticipanteEventoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}