﻿using MVC_Core_Client.Models;
using Newtonsoft.Json;

namespace MVC_Core_Client.Infrastructure.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;

        public ContaCorrenteService(HttpClient httpClient, ApiConfig apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig;
        }


        public async Task<List<ContaCorrenteModel>> ObterContasCorrentesAsync()
        {
            var response = await _httpClient.GetAsync(_apiConfig.BaseUrl + "api/contas-correntes");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaContaCorrenteModel = JsonConvert.DeserializeObject<List<ContaCorrenteModel>>(content);
                return listaContaCorrenteModel;
            }
            else
            {
                // Lógica para tratar o caso de falha na chamada à API
                throw new Exception("Ocorreu um erro ao obter a lista de contas correntes.");
            }
        }
    }
}
