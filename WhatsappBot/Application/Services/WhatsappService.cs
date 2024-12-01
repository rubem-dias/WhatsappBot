using WhatsappBot.Application.DTOs;
using WhatsappBot.Application.Interfaces;
using WhatsappBot.Infraestructure.HttpClients;

namespace WhatsappBot.Application.Services
{
    public class WhatsappService : IWhatsappAppService
    {
        private readonly WhatsAppHttpClient _httpClient;

        public WhatsappService(WhatsAppHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendWhatsAppMessageAsync(SendMessageDto messageDto)
        {
            await _httpClient.SendWhatsAppMessageAsync(messageDto!.PhoneNumber!, messageDto!.Message!);
        }
    }
}
