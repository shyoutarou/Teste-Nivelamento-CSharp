using Newtonsoft.Json;
using Questao5_Data.Domain.Entities;
using System.Net.Http;
using System.Text;

namespace MVC_Core_Client.Infrastructure.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly HttpClient _httpClient;

        public MovimentacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> EditarMovimentacaoAsync(Movimentacao movimentacao)
        {
            var jsonContent = JsonConvert.SerializeObject(movimentacao);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44358/api/movimentacoes", content);

            return response.IsSuccessStatusCode;

        }
    }
}
