using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HttpTelegBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly TelegramBotClient _client
            = new TelegramBotClient(BotSettings.Key);

        [HttpGet]
        public string Get()
        {
            return "Bot working";
        }
        // POST: api/Bot
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Update update)
        {
            if (update == null) return BadRequest(); ;
            var message = update.Message;
            if (message?.Type == MessageType.Text)
            {
                return Ok(await _client.SendTextMessageAsync(message.Chat.Id, message.Text));

            }

            return NotFound();
        }


    }
}