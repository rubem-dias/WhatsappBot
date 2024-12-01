namespace WhatsappBot.Infraestructure.HttpClients
{
    public class WhatsAppHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly WhatsAppConfiguration _config;

        public WhatsAppHttpClient(HttpClient httpClient, WhatsAppConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task SendWhatsAppMessageAsync(string phoneNumber, string message)
        {
            var requestUrl = $"{_config.ApiUrl}/{_config.FromNumberId}/messages";
            var payload = new
            {
                messaging_product = "whatsapp",
                to = phoneNumber,
                type = "text",
                text = new { body = message }
            };

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config.AccessToken);

            var response = await _httpClient.PostAsJsonAsync(requestUrl, payload);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao enviar mensagem: {error}");
            }
        }
    }
}
