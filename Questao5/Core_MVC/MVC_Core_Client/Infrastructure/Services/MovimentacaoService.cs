using Newtonsoft.Json;
using Questao5_Data.Domain.Entities;
using System.Net.Http;
using System.Text;

namespace MVC_Core_Client.Infrastructure.Services
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;

        public MovimentacaoService(HttpClient httpClient, ApiConfig apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig;
        }

        public async Task<bool> EditarMovimentacaoAsync(Movimentacao movimentacao)
        {
            var jsonContent = JsonConvert.SerializeObject(movimentacao);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiConfig.BaseUrl + "api/movimentacoes", content);

            return response.IsSuccessStatusCode;

        }
    }
}
