using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace WebAppBot.Models.Commands
{
    public class StartCommand : IBotCommand
    {
        public  string Name => @"/start";

        public bool Contains(Message message)
        {
            var typeTxt = MessageType.Text;
            if (message == null) return false;
            if (message.Type != typeTxt)
                return false;

            return message.Text.Contains(this.Name);
        }

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, "Hallo I'm ASP.NET Core Bot", parseMode: ParseMode.Markdown);
        }
    }
}
