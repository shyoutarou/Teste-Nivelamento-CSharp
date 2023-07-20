public class StatusCheckerService : BackgroundService
{
    private readonly ILogger<StatusCheckerService> _logger;
    private readonly string _apiUrl;
    private readonly HttpClient _httpClient;

    public StatusCheckerService(ILogger<StatusCheckerService> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _apiUrl = "https://localhost:44358/api/statusapi"; // Substitua pela URL correta da sua API.
        _httpClient = httpClientFactory.CreateClient();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                string message = await GetApiStatus();
                _logger.LogInformation(message);

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao verificar o status da API.");
            }
        }
    }

    private async Task<string> GetApiStatus()
    {
        var response = await _httpClient.GetAsync(_apiUrl);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            string message = "API funcionando e conectada. Data e hora atual: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            return message;
        }
        return "Erro ao obter o status da API.";
    }
}