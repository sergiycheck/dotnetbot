using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebAppBot.Models;

namespace WebAppBot.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {


        public MessageController()
        {
            var task = Task.Run(async()=>await Bot.GetBotClientAsync());
            task.Wait();

        }

        [HttpPost("update")]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null) return Ok(null);
            
            var commands = Bot.Commands;
            var message = update.Message;
            var callBack = update.CallbackQuery;


            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    return Ok(await command.Execute(message,callBack));
                }

                if (command.Contains(callBack))
                {
                    return Ok(await command.Execute(message, callBack));
                }
                
                
            }
            return NotFound();
        }

    }
}