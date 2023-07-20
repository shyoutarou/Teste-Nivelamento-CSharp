using Microsoft.AspNetCore.Mvc;
using MVC_Core_Client.Infrastructure.Services;
using MVC_Core_Client.Models;
using Questao5_Data.Domain.Entities;

namespace MVC_Core_Client.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacoesController(IMovimentacaoService movimentacaoService
            )
        {
            _movimentacaoService = movimentacaoService;
        }


        public async Task<ActionResult> Index()
        {
            try
            {
                var listaMovimentacao = await _movimentacaoService.ObterMovimentacoesAsync();

                return View(listaMovimentacao);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao pesquisar as contas.");
            }
        }
    }
}
