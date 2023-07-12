using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;

namespace API_Core.Controllers
{
    [ApiController]
    [Route("api/movimentacoes")]
    public class MovimentacoesController : Controller
    {
        private readonly IMovimentacaoCommand _movimentacaoCommand;
        private readonly IContaCorrenteCommand _contaCorrenteCommand;
        private readonly IMovimentacaoQuery _movimentacaoQuery;
        private readonly IContaCorrenteQuery _contaCorrenteQuery;

        public MovimentacoesController(IMovimentacaoCommand movimentacaoCommand,
                                       IContaCorrenteCommand contaCorrenteCommand,
                                       IMovimentacaoQuery movimentacaoQuery,
                                       IContaCorrenteQuery contaCorrenteQuery)
        {
            _movimentacaoCommand = movimentacaoCommand;
            _contaCorrenteCommand = contaCorrenteCommand;
            _movimentacaoQuery = movimentacaoQuery;
            _contaCorrenteQuery = contaCorrenteQuery;
        }

        /// <summary>
        /// Obtém todas as movimentações.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Movimentacao> movimentacoes = _movimentacaoQuery.GetMovimentacoes();
                return Ok(movimentacoes);
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Ocorreu um erro ao obter as movimentações.");
            }
        }

        /// <summary>
        /// Obtém uma movimentação por ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Movimentacao> Get(int id)
        {
            try
            {
                Movimentacao movimentacao = _movimentacaoQuery.GetMovimentacaoById(id);
                if (movimentacao == null)
                {
                    return NotFound();
                }
                return movimentacao;
            }
            catch (Exception ex)
            {
                // Log do erro
                return BadRequest("Ocorreu um erro ao retornar a movimentação.");
            }
        }

        /// <summary>
        /// Adiciona uma nova movimentação.
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] Movimentacao movimentacao)
        {
            try
            {
                _movimentacaoCommand.AddMovimentacao(movimentacao);
                return CreatedAtAction(nameof(Get), new { id = movimentacao.IdMovimentacao }, movimentacao);
            }
            catch (Exception ex)
            {
                // Log do erro
                return BadRequest("Ocorreu um erro ao adicionar a movimentação.");
            }
        }

        /// <summary>
        /// Atualiza uma movimentação existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Movimentacao movimentacao)
        {
            try
            {
                if (id != movimentacao.IdMovimentacao)
                {
                    return BadRequest();
                }
                bool updated = _movimentacaoCommand.UpdateMovimentacao(movimentacao);
                if (!updated)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log do erro
                return BadRequest();
            }
        }

        /// <summary>
        /// Aplica um patch em uma movimentação.
        /// </summary>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Movimentacao> patch)
        {
            try
            {
                Movimentacao movimentacao = _movimentacaoQuery.GetMovimentacaoById(id);
                if (movimentacao != null)
                {
                    patch.ApplyTo(movimentacao);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Ocorreu um erro ao aplicar o patch na movimentação.");
            }
        }

        /// <summary>
        /// Exclui uma movimentação existente.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteMovimentacao(int id)
        {
            try
            {
                Movimentacao movimentacao = _movimentacaoQuery.GetMovimentacaoById(id);
                if (movimentacao == null)
                {
                    return NotFound();
                }
                _movimentacaoCommand.DeleteMovimentacao(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log do erro
                return BadRequest();
            }
        }
    }
}
