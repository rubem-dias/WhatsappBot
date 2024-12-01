using WhatsappBot.Application.DTOs;

namespace WhatsappBot.Application.Interfaces
{
    public interface IWhatsappAppService
    {
        Task SendWhatsAppMessageAsync(SendMessageDto messageDto);
    }
}
