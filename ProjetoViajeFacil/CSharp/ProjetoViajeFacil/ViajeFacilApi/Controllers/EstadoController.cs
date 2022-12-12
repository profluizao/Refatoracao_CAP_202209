using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.Dominio.EF;
using ViajeFacil.Poco;
using ViajeFacil.Poco.Viagem;
using ViajeFacil.Service.Viagem;

namespace ViajeFacilApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/viagem/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private EstadoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EstadoController(ViajeFacilContexto context) : base()
        {
            this.servico = new EstadoService(context);
        }

        /// <summary>
        /// Lista todos os registros de Estado por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<EstadoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EstadoPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros de Cidade por chave Região.
        /// </summary>
        /// <param name="regiaocod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorRegiao/{regiaocod:long}")]
        public ActionResult<List<EstadoPoco>> GetByRegiao(long regiaocod)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Consultar(cid => cid.CodigoRegiao == regiaocod).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna o registro de acordo com a sigla do Estado
        /// </summary>
        /// <param name="siglaUF"> Informar a Sigla Estado. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("porSigla/{siglaUF}")]
        public ActionResult<List<EstadoPoco>> GetBySigla(string siglaUF)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Consultar(name => name.SiglaUF == siglaUF).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna o registro de acordo com o nome do Estado
        /// </summary>
        /// <param name="NomeCompleto"> Nome Completo para Pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("porNome/{NomeCompleto}")]
        public ActionResult<List<EstadoPoco>> GetByNome(string NomeCompleto)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Consultar(name => name.Nome == NomeCompleto).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Estado.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:long}")]
        public ActionResult<EstadoPoco> GetById(long chave)
        {
            try
            {
                EstadoPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Estado.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<EstadoPoco> Post([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Estado.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<EstadoPoco> Put([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<EstadoPoco> DeleteById(long chave)
        {
            try
            {
                EstadoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}