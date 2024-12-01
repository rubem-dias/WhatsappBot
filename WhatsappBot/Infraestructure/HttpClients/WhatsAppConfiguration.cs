namespace WhatsappBot.Infraestructure.HttpClients
{
    public class WhatsAppConfiguration
    {
        public string? ApiUrl { get; set; } = "https://graph.facebook.com/v16.0";
        public string? AccessToken { get; set; }
        public string? FromNumberId { get; set; }
    }
}
