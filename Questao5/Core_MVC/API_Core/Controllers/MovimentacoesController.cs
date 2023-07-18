using API_Core.Application.Queries.Requests;
using ApiMediatR.Handlers.Request;
using MediatR;
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
        private readonly IMediator _mediator;


        public MovimentacoesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtém todas as movimentações.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Movimentacao> movimentacoes = await _mediator.Send(new GetMovimentacoesRequest());

                //IEnumerable<Movimentacao> movimentacoes = await _movimentacaoQuery.GetMovimentacoesAsync();
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
        public async Task<ActionResult<Movimentacao>> Get(int id)
        {
            try
            {
                Movimentacao movimentacao = await _movimentacaoQuery.GetMovimentacaoByIdAsync(id);
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
        public async Task<IActionResult> Post([FromBody] Movimentacao movimentacao)
        {
            try
            {
                await _mediator.Send(new EditarMovimentacaoRequest { movimentacao = movimentacao });

                return CreatedAtAction(nameof(Get), new { id = movimentacao.IdMovimento }, movimentacao);
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
        public async Task<IActionResult> Put(string id, [FromBody] Movimentacao movimentacao)
        {
            try
            {
                if (id != movimentacao.IdMovimento)
                {
                    return BadRequest();
                }
                bool updated = await _movimentacaoCommand.UpdateMovimentacaoAsync(movimentacao);
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
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<Movimentacao> patch)
        {
            try
            {
                Movimentacao movimentacao = await _movimentacaoQuery.GetMovimentacaoByIdAsync(id);
                if (movimentacao != null)
                {
                    patch.ApplyTo(movimentacao);
                    await _movimentacaoCommand.UpdateMovimentacaoAsync(movimentacao);
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
        public async Task<IActionResult> DeleteMovimentacao(int id)
        {
            try
            {
                Movimentacao movimentacao = await _movimentacaoQuery.GetMovimentacaoByIdAsync(id);
                if (movimentacao == null)
                {
                    return NotFound();
                }
                await _movimentacaoCommand.DeleteMovimentacaoAsync(id);
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
