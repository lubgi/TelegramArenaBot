using System.Threading.Tasks;
using ArenaTelegramBotAzure.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace ArenaTelegramBotAzure.Controllers
{
    public class WebhookController : ControllerBase
    {
        

        [HttpPost]
        public async Task<IActionResult> Post(
                                                [FromServices] HandleUpdateService handleUpdateService,
                                                [FromBody] Update update)
        {
            await handleUpdateService.EchoAsync(update);
            return Ok();
        }
    }
}