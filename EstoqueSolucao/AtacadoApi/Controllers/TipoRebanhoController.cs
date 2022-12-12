using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Servico.Pecuaria;
using Atacado.DB.EF.Database;
using Atacado.Poco.Pecuaria;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/pecuaria/[controller]")]
    [ApiController]
    public class TipoRebanhoController : ControllerBase
    {
        private TipoRebanhoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public TipoRebanhoController(ProjetoAcademiaContext context) : base()
        {
            this.servico = new TipoRebanhoServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoRebanhoPoco>> GetAll()
        {
            try
            {
                List<TipoRebanhoPoco> listaPoco = this.servico.Listar();
                return Ok(listaPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Tipo Rebanho pelo código
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<TipoRebanhoPoco> GetById(int chave)
        {
            try
            {
                TipoRebanhoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo registro na tabela 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TipoRebanhoPoco> Post([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco nova = this.servico.Inserir(poco);
                return Ok(nova);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza os dados da tabela 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<TipoRebanhoPoco> Put([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro por codigo informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<TipoRebanhoPoco> DeleteById(int codigo)
        {
            try
            {
                TipoRebanhoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
