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
        /// Listar todos os registros da tabela Categoria.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<FuncionarioPoco>> GetAll()
        {
            try
            {
                List<FuncionarioPoco> lista = this.servico.Browse();
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            
        }

        /// <summary>
        /// Lista o registro da tabela Categoria de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<FuncionarioPoco> GetById(int chave)
        {
            try
            {
                FuncionarioPoco poco = this.servico.Read(chave);
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
                FuncionarioPoco novo = this.servico.Add(poco);
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
                FuncionarioPoco atPoco = this.servico.Edit(poco);
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
        [HttpDelete("{chave:int}")]
        public ActionResult<FuncionarioPoco> DeleteById(int chave)
        {
            try
            {
                FuncionarioPoco delPoco = this.servico.Delete(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString);
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
                FuncionarioPoco delPoco = this.servico.Delete(poco);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString);
            }
        }
    }
}
