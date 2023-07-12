using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Questao5_Data.Domain.Entities;
using Questao5_Data.Infrastructure.Database.CommandStore.Requests;
using Questao5_Data.Infrastructure.Database.QueryStore.Requests;
using System.Text;

namespace MVC_Core_Client.Controllers
{
    public class ContaCorrenteController : Controller
    {
        private readonly IMovimentacaoQuery _movimentacaoQuery;
        private readonly IContaCorrenteQuery _contaCorrenteQuery;

        public ContaCorrenteController(IMovimentacaoQuery movimentacaoQuery,
                               IContaCorrenteQuery contaCorrenteQuery)
        {
            _movimentacaoQuery = movimentacaoQuery;
            _contaCorrenteQuery = contaCorrenteQuery;
        }


        public IActionResult Index()
        {
            List<ContaCorrente> listaContaCorrentes = new List<ContaCorrente>();
            listaContaCorrentes = this._contaCorrenteQuery.GetAllContasCorrentes().ToList();
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
                    IdMovimentacao = Guid.NewGuid().ToString().ToUpper(),
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
                    using (var httpClient = new HttpClient())
                    {
                        // Convertendo o objeto movimentacao em JSON
                        string jsonContent = JsonConvert.SerializeObject(movimentacao);

                        // Criando o conteúdo da requisição
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        // Fazendo a chamada para a API
                        HttpResponseMessage response = await httpClient.PostAsync("https://localhost:44358/api/movimentacoes", content);

                        // Verificando se a requisição foi bem-sucedida
                        if (response.IsSuccessStatusCode)
                        {
                            // Redirecionando para a ação "Index"
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            // Lidar com o caso de erro na requisição
                            // ...
                        }
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
