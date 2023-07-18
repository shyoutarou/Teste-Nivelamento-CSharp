using Microsoft.AspNetCore.Mvc;
using MVC_Core_Client.Infrastructure.Services;
using MVC_Core_Client.Models;
using Questao5_Data.Domain.Entities;

namespace MVC_Core_Client.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly IContaCorrenteService _contaCorrenteService;
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacoesController(IContaCorrenteService contaCorrenteService,
            IMovimentacaoService movimentacaoService
            )
        {
            _contaCorrenteService = contaCorrenteService;
            _movimentacaoService = movimentacaoService;
        }


        public async Task<ActionResult> Index()
        {
            try
            {
                var listaMovimentacao = await _movimentacaoService.ObterMovimentacoesAsync();

                //var listaMovimentacaoModel = listaMovimentacao.Select(x => new ContaCorrenteModel
                //{
                //    IdContaCorrente = x.IdContaCorrente,
                //    Numero = x.Numero,
                //    Nome = x.Nome,
                //    Ativo = x.Ativo,
                //    Saldo = x.Saldo,
                //    UltimaDataMovimento = x.UltimaDataMovimento
                //}).ToList();

                return View(listaMovimentacao);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao pesquisar as contas.");
            }
        }

        public ActionResult Editar(string id)
        {

            try
            {
                if (id == null)
                {
                    return BadRequest("Ocorreu um erro ao retornar a conta.");
                }

                var movimentacao = new Movimentacao()
                {
                    IdMovimento = Guid.NewGuid().ToString().ToUpper(),
                    IdContaCorrente = id
                };

                return View(movimentacao);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao retornar a conta.");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(Movimentacao movimentacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sucesso = await _movimentacaoService.EditarMovimentacaoAsync(movimentacao);

                    if (sucesso)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return BadRequest("Ocorreu um erro ao editar a conta.");
                    }
                }

                return View(movimentacao);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao editar a conta.");
            }
        }
    }
}
