using ApiMediatR.Handlers.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;

namespace API_Core.Controllers
{
    [ApiController]
    [Route("api/contas-correntes")]
    public class ContasCorrentesController : Controller
    {
        private readonly IContaCorrenteCommand _contaCorrenteCommand;
        private readonly IContaCorrenteQuery _contaCorrenteQuery;
        private readonly IMediator _mediator;

        public ContasCorrentesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtém todas as contas correntes.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<ContaCorrente> contasCorrentes = await _mediator.Send(new GetContasCorrentesRequest() );

                //IEnumerable<ContaCorrente> contasCorrentes = await _contaCorrenteQuery.GetAllContasCorrentesAsync();
                return Ok(contasCorrentes);
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Ocorreu um erro ao obter as contas correntes.");
            }
        }

        /// <summary>
        /// Obtém uma conta corrente por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaCorrente>> Get(string id)
        {
            try
            {
                ContaCorrente contaCorrente = await _contaCorrenteQuery.GetContaCorrenteByIdAsync(id);
                if (contaCorrente == null)
                {
                    return NotFound();
                }
                return contaCorrente;
            }
            catch (Exception ex)
            {
                // Log do erro
                return BadRequest("Ocorreu um erro ao retornar a conta corrente.");
            }
        }

        /// <summary>
        /// Adiciona uma nova conta corrente.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                await _contaCorrenteCommand.AddContaCorrenteAsync(contaCorrente);
                return CreatedAtAction(nameof(Get), new { id = contaCorrente.IdContaCorrente }, contaCorrente);
            }
            catch (Exception ex)
            {
                // Log do erro
                return BadRequest("Ocorreu um erro ao adicionar a conta corrente.");
            }
        }

        /// <summary>
        /// Atualiza uma conta corrente existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                if (id != contaCorrente.IdContaCorrente)
                {
                    return BadRequest();
                }
                bool updated = await _contaCorrenteCommand.UpdateContaCorrenteAsync(contaCorrente);
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
        /// Exclui uma conta corrente existente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                ContaCorrente contaCorrente = await _contaCorrenteQuery.GetContaCorrenteByIdAsync(id);
                if (contaCorrente == null)
                {
                    return NotFound();
                }
                await _contaCorrenteCommand.DeleteContaCorrenteAsync(id);
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
