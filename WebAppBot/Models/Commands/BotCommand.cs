using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WebAppBot.Models.Commands
{
    public interface  IBotCommand
    {
        Task Execute(Message message, TelegramBotClient client);

          bool Contains(Message message);
    }
}
