using MVC_Core_Client.Models;

namespace MVC_Core_Client.Infrastructure.Services
{
    public interface IContaCorrenteService
    {
        Task<List<ContaCorrenteModel>> ObterContasCorrentesAsync();
    }
}
