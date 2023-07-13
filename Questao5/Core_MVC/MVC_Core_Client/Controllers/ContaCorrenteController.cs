using Microsoft.AspNetCore.Mvc;
using MVC_Core_Client.Infrastructure.Services;
using MVC_Core_Client.Models;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;

namespace MVC_Core_Client.Controllers
{
    public class ContaCorrenteController : Controller
    {
        private readonly IMovimentacaoQuery _movimentacaoQuery;
        private readonly IContaCorrenteQuery _contaCorrenteQuery;
        private readonly IMovimentacaoService _movimentacaoService;

        public ContaCorrenteController(IMovimentacaoQuery movimentacaoQuery, 
            IContaCorrenteQuery contaCorrenteQuery, 
            IMovimentacaoService movimentacaoService)
        {
            _movimentacaoQuery = movimentacaoQuery;
            _contaCorrenteQuery = contaCorrenteQuery;
            _movimentacaoService = movimentacaoService;
        }


        public async Task<IActionResult> Index()
        {
            var listaContaCorrentes = await _contaCorrenteQuery.GetAllContasCorrentesAsync();

            var listaContaCorrenteModel = listaContaCorrentes.Select(x => new ContaCorrenteModel
            {
                IdContaCorrente = x.IdContaCorrente,
                Numero = x.Numero,
                Nome = x.Nome,
                Ativo = x.Ativo,
                Saldo = x.Saldo,
                UltimaDataMovimento = x.UltimaDataMovimento
            }).ToList();

            return View(listaContaCorrentes);
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
