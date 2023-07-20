using Microsoft.AspNetCore.Mvc;
using MVC_Core_Client.Infrastructure.Services;

namespace MVC_Core_Client.Controllers
{
    public class IdempotenciaController : Controller
    {
        private readonly IIdempotenciaService _idempotenciaService;

        public IdempotenciaController(IIdempotenciaService idempotenciaService)
        {
            _idempotenciaService = idempotenciaService;
        }


        public async Task<ActionResult> Index()
        {
            try
            {
                var listaIdempotencias = await _idempotenciaService.ObterIdempotenciasAsync();

                return View(listaIdempotencias);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao pesquisar as idempotencias.");
            }
        }

    }
}
