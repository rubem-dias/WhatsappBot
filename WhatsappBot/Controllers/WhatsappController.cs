using Microsoft.AspNetCore.Mvc;
using WhatsappBot.Application.DTOs;
using WhatsappBot.Application.Interfaces;

namespace WhatsappBot.Controllers
{
    [ApiController]
    [Route("api/whatsapp")]
    public class WhatsAppController : ControllerBase
    {
        private readonly IWhatsappAppService _whatsAppService;

        public WhatsAppController(IWhatsappAppService whatsAppService)
        {
            _whatsAppService = whatsAppService;
        }

        /// <summary>
        /// Envia uma mensagem pelo WhatsApp.
        /// </summary>
        /// <param name="messageDto">Dados da mensagem.</param>
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto messageDto)
        {
            await _whatsAppService.SendWhatsAppMessageAsync(messageDto);
            return Ok(new { Message = "Mensagem enviada com sucesso!" });
        }
    }
}
