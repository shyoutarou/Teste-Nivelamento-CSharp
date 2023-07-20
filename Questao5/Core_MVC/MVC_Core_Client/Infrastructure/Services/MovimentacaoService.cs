using MVC_Core_Client.Models;
using Newtonsoft.Json;
using Questao5_Data.Domain.Entities;
using System.ComponentModel;
using System.Globalization;
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
            //var jsonSettings = new JsonSerializerSettings
            //{
            //    Culture = new CultureInfo("pt-BR")
            //};

            //var jsonContent = JsonConvert.SerializeObject(movimentacao, Formatting.None, jsonSettings);

            var jsonContent = JsonConvert.SerializeObject(movimentacao);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_apiConfig.BaseUrl + "api/movimentacoes", content);


                if (!response.IsSuccessStatusCode)
                {
                    // A requisição não foi bem-sucedida, aqui você pode obter o conteúdo da resposta para obter mais detalhes do erro
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro na requisição HTTP: {response.StatusCode} - {response.ReasonPhrase}");
                    Console.WriteLine($"Detalhes da resposta: {responseContent}");
                    return false;
                }

                response.EnsureSuccessStatusCode(); // Isso lança uma exceção se a resposta não for bem-sucedida

                return true;
            }
            catch (HttpRequestException ex)
            {
                // A requisição HTTP falhou, aqui você pode examinar a exceção para entender o motivo do erro
                // Por exemplo, você pode imprimir a mensagem de erro na saída ou logar em algum arquivo
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Tratamento genérico de outras exceções, caso ocorra algum erro inesperado
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            return false; // Retorna false para indicar que houve falha no envio

        }


        //public class DecimalConverter : JsonConverter
        //{
        //    private readonly CultureInfo _culture;

        //    public DecimalConverter(CultureInfo culture)
        //    {
        //        _culture = culture;
        //    }

        //    public override bool CanConvert(Type objectType)
        //    {
        //        return objectType == typeof(decimal) || objectType == typeof(decimal?);
        //    }

        //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //    {
        //        writer.WriteValue(Convert.ToDecimal(value).ToString("N2", _culture));
        //    }

        //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}


        //public async Task<bool> EditarMovimentacaoAsync(Movimentacao movimentacao)
        //{
        //    var jsonSettings = new JsonSerializerSettings
        //    {
        //        Converters = { new DecimalConverter(new CultureInfo("pt-BR")) },
        //        Formatting = Formatting.None
        //    };

        //    var jsonContent = JsonConvert.SerializeObject(movimentacao, jsonSettings);
        //    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync(_apiConfig.BaseUrl + "api/movimentacoes", content);

        //    return response.IsSuccessStatusCode;
        //}


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
