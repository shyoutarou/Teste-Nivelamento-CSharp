using MVC_Core_Client.Models;
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

        public async Task<List<MovimentacaoModel>> ObterMovimentacoesAsync()
        {
            var response = await _httpClient.GetAsync(_apiConfig.BaseUrl + "api/movimentacoes");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaMovimentacaoModel = JsonConvert.DeserializeObject<List<MovimentacaoModel>>(content);
                return listaMovimentacaoModel;
            }
            else
            {
                // Lógica para tratar o caso de falha na chamada à API
                throw new Exception("Ocorreu um erro ao obter a lista de contas correntes.");
            }
        }
    }
}
