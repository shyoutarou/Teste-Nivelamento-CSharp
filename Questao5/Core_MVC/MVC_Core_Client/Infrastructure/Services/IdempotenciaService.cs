using MVC_Core_Client.Models;
using Newtonsoft.Json;
using Questao5_Data.Domain.Entities;
using System.Text;

namespace MVC_Core_Client.Infrastructure.Services
{
    public class IdempotenciaService : IIdempotenciaService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;

        public IdempotenciaService(HttpClient httpClient, ApiConfig apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig;
        }

        public Task<bool> EditarIdempotenciaAsync(Idempotencia idempotencia)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<IdempotenciaModel>> ObterIdempotenciasAsync()
        {
            var response = await _httpClient.GetAsync(_apiConfig.BaseUrl + "api/idempotencias");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaidempotenciasModel = JsonConvert.DeserializeObject<List<IdempotenciaModel>>(content);
                return listaidempotenciasModel;
            }
            else
            {
                // Lógica para tratar o caso de falha na chamada à API
                throw new Exception("Ocorreu um erro ao obter a lista de contas correntes.");
            }
        }
    }
}
