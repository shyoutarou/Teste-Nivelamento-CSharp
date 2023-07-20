using API_Core.Application.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5_Data.Domain.Entities;

namespace API_Core.Controllers
{
    [ApiController]
    [Route("api/idempotencias")]
    public class IdempotenciaController : Controller
    {
        private readonly IMediator _mediator;


        public IdempotenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtém todas as idempotencias.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Idempotencia> lista_idempotencias = await _mediator.Send(new GetIdempotenciaRequest());

                //IEnumerable<Movimentacao> movimentacoes = await _movimentacaoQuery.GetMovimentacoesAsync();
                return Ok(lista_idempotencias);
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Ocorreu um erro ao obter as movimentações.");
            }
        }

    }
}
