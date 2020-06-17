using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebAppBot.Models.Commands
{
    public class ReplyCommand : MyBotCommand
    {
        public override string Name => "";//some name to trigger command

        public override bool Contains(Message message)
        {
            if (message == null) return false;
            if (message.Type != MessageType.Text) return false;
            return true;
        }

        public override async Task<Message> Execute(Message message,CallbackQuery query)
        {
            var chatId = message.Chat.Id;
            return await Bot.BotClient.SendTextMessageAsync(chatId, $"Hello {message.Chat.FirstName}", parseMode: ParseMode.Markdown);
        }
    }
}
