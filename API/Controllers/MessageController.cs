using Communication;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route(ApiRoutes.Base)]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet(ApiRoutes.Messages.GetMessages)]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _messageService.GetMessages();
            return Ok(messages);
        }
    }
}