using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebAppBot.Models.Commands
{
    public class ReplyCommand : IBotCommand
    {
        public string Name => "";//some name to trigger command

        public bool Contains(Message message)
        {
            if (message == null) return false;
            if (message.Type != MessageType.Text) return false;
            return true;
        }

        public async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, $"Hello {message.Chat.FirstName}", parseMode: ParseMode.Markdown);
        }
    }
}
