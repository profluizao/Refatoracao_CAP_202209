using LinqKit;
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
    public class CidadeController : ControllerBase
    {
        private CidadeService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CidadeController(ViajeFacilContexto context) : base()
        {
            this.servico = new CidadeService(context);
        }

        /// <summary>
        /// Lista todos os registros de Cidade por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<CidadePoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<CidadePoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista todos os registros de Cidade por Paginação e Sigla UF.
        /// </summary>
        /// <param name="porSigla"> Informar a Sigla UF. </param>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns></returns>
        [HttpGet("{porSigla}")]
        public ActionResult<List<CidadePoco>> GetBySigla(string porSigla, int? take = null, int? skip = null)
        {
            try
            {
                List<CidadePoco> listPoco;
                var predicate = PredicateBuilder.New<Cidade>(true);
                if (take == null) //OPCIONAL
                {
                    if (skip != null) //OPCIONAL
                    {
                        return BadRequest("Informe o parâmetro Take e Skip.");
                    }
                    else
                    {
                        predicate = predicate.And(s => s.SiglaUf == porSigla);
                        listPoco = this.servico.Consultar(predicate);
                        return Ok(listPoco);
                    }
                }
                else
                {
                    if (skip == null) //OPCIONAL
                    {
                        return BadRequest("Informe o parâmetro Take e Skip.");
                    }
                    else
                    {
                        predicate = predicate.And(s => s.SiglaUf == porSigla);
                        listPoco = this.servico.Vasculhar(take, skip, predicate);
                        return Ok(listPoco);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a pesquisa pela sigla e pela chave informada
        /// </summary>
        /// <param name="porSigla"></param>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{porSigla}/{chave:long}")]
        public ActionResult<CidadePoco> GetBySiglaById(string porSigla, long chave)
        {
            try
            {
                List<CidadePoco> listaPoco;
                var predicado = PredicateBuilder.New<Cidade>(true);
                predicado = predicado.And(s => s.SiglaUF == porSigla);
                predicado = predicado.And(s => s.CodigoCidade == chave);
                listaPoco = this.servico.Consultar(predicado);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        ///  Lista os registro usando a chave de Cidade.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:long}")]
        public ActionResult<CidadePoco> GetById(long chave)
        {
            try
            {
                CidadePoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Cidade.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<CidadePoco> Post([FromBody] CidadePoco poco)
        {
            try
            {
                CidadePoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Cidade.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<CidadePoco> Put([FromBody] CidadePoco poco)
        {
            try
            {
                CidadePoco novoPoco = this.servico.Alterar(poco);
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
        public ActionResult<CidadePoco> DeleteById(long chave)
        {
            try
            {
                CidadePoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}