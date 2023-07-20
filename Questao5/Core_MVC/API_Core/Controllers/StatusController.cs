using Microsoft.AspNetCore.Mvc;

namespace API_Core.Controllers
{
    [Route("api/statusapi")]
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            string message = "API funcionando e conectada. Data e hora atual: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return Ok(message);
        }
    }
}
