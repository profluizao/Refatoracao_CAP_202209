using Atacado.Poco.RH;
using Atacado.Servico.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/rh/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioServico servico;

        /// <summary>
        /// 
        /// </summary>
        public FuncionarioController() : base()
        {
            this.servico = new FuncionarioServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Funcionario.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<FuncionarioPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<FuncionarioPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }            
        }

        /// <summary>
        /// Lista o registro da tabela Funcionario de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:long}")]
        public ActionResult<FuncionarioPoco> GetById(long chave)
        {
            try
            {
                FuncionarioPoco poco = this.servico.PesquisarPorChave(chave);
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
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FuncionarioPoco> Post([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco novo = this.servico.Inserir(poco);
                return Ok(novo);
            }
            catch(Exception ex)
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
        public ActionResult<FuncionarioPoco> Put([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
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
        [HttpDelete("{chave:long}")]
        public ActionResult<FuncionarioPoco> DeleteById(long chave)
        {
            try
            {
                FuncionarioPoco delPoco = this.servico.Excluir(chave);
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
        public ActionResult<FuncionarioPoco> Delete([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco delPoco = this.servico.Excluir(poco.FuncionarioId);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
