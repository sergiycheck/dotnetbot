using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebAppBot.Models.Commands
{
    public class ButtonCommands : IBotCommand
    {
        public string Name => "/buttons";//some name to trigger command
        public bool Contains(Message message)
        {
            var typeTxt = MessageType.Text;
            if (message == null) return false;
            if (message.Type != typeTxt)
                return false;

            return message.Text.Contains(this.Name);
        }

        public Task Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
